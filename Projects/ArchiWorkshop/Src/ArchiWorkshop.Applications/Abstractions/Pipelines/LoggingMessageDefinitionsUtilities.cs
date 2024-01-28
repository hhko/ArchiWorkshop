using ArchiWorkshop.Domains.Abstractions.Results;
using MediatR;
using Microsoft.Extensions.Logging;

// ILogger
//  - Microsoft.Extensions.Logging.Abstractions
namespace ArchiWorkshop.Applications.Abstractions.Pipelines;

public static partial class LoggingMessageDefinitionsUtilities
{
    [LoggerMessage
    (
        EventId = 1,
        EventName = $"StartingRequest in {nameof(LoggingPipeline<IRequest<IResult>, IResult>)}",
        Level = LogLevel.Information,
        Message = "Starting request {RequestName}, {DateTimeUtc}",
        SkipEnabledCheck = false
    )]
    public static partial void LogStartingRequest(this ILogger logger, string requestName, DateTime dateTimeUtc);

    [LoggerMessage
    (
        EventId = 2,
        EventName = $"CompletingRequest in {nameof(LoggingPipeline<IRequest<IResult>, IResult>)}",
        Level = LogLevel.Information,
        Message = "Request completed {requestName}, {DateTimeUtc}",
        SkipEnabledCheck = false
    )]
    public static partial void LogCompletingRequest(this ILogger logger, string requestName, DateTime dateTimeUtc);

    [LoggerMessage
    (
        EventId = 3,
        EventName = $"FailedRequestBasedOnSingleError in {nameof(LoggingPipeline<IRequest<IResult>, IResult>)}",
        Level = LogLevel.Error,
        Message = "Request failed {RequestName}, {Error}, {DateTimeUtc}",
        SkipEnabledCheck = true
    )]
    public static partial void LogFailedRequestBasedOnSingleError(this ILogger logger, string requestName, Error error, DateTime dateTimeUtc);

    [LoggerMessage
    (
        EventId = 4,
        EventName = $"FailedRequestBasedOnValidationErrors in {nameof(LoggingPipeline<IRequest<IResult>, IResult>)}",
        Level = LogLevel.Error,
        Message = "Request failed {RequestName}, {ValidationErrors}, {DateTimeUtc}",
        SkipEnabledCheck = true
    )]
    public static partial void LogFailedRequestBasedOnValidationErrors(this ILogger logger, string requestName, Error[] validationErrors, DateTime dateTimeUtc);
}