using ArchiWorkshop.Domains.Abstractions.Results;
using FluentValidation;
using MediatR;

namespace ArchiWorkshop.Applications.Abstractions.Pipelines;

// CQRS Validation Pipeline with MediatR and FluentValidation
// https://code-maze.com/cqrs-mediatr-fluentvalidation/

// https://www.linkedin.com/pulse/advanced-features-mediatr-package-pipeline-behaviors/
public class FluentValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : class, IResult
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public FluentValidationPipeline(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any() is false)
        {
            return await next();
        }

        Error[] errors = _validators
            .Select(validator => validator.Validate(request))
            .SelectMany(validationResult => validationResult.Errors)
            .Where(validationFailure => validationFailure is not null)
            .Select(failure => Error.New(failure.PropertyName, failure.ErrorMessage))
            .Distinct()
            .ToArray();

        if (errors.Length is not 0)
        {
            return errors.CreateValidationResult<TResponse>();
        }

        return await next();
    }
}