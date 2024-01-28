using ArchiWorkshop.Domains.Abstractions.Results;
using MediatR;
using Microsoft.Extensions.Logging;

// ILogger
//  - Microsoft.Extensions.Logging.Abstractions
namespace ArchiWorkshop.Applications.Abstractions.Pipelines;

//public sealed class LoggingPipeline<TRequest, TResponse>(ILogger<LoggingPipeline<TRequest, TResponse>> logger)
public sealed class LoggingPipeline<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IResult
{
    private readonly ILogger<LoggingPipeline<TRequest, TResponse>> _logger;

    public LoggingPipeline(ILogger<LoggingPipeline<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request,
                                        RequestHandlerDelegate<TResponse> next,
                                        CancellationToken cancellationToken)
    {
        _logger.LogInformation("테스트");
        _logger.LogStartingRequest(typeof(TRequest).Name, DateTime.UtcNow);

        var result = await next();

        if (result.IsSuccess)
        {
            _logger.LogCompletingRequest(typeof(TRequest).Name, DateTime.UtcNow);
            return result;
        }

        if (result is IValidationResult validationResult)
        {
            _logger.LogFailedRequestBasedOnValidationErrors(typeof(TRequest).Name, validationResult.ValidationErrors, DateTime.UtcNow);
            return result;
        }

        _logger.LogFailedRequestBasedOnSingleError(typeof(TRequest).Name, result.Error, DateTime.UtcNow);
        return result;
    }
}