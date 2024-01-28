using ArchiWorkshop.Applications.Abstractions.CQRS;
using ArchiWorkshop.Domains.Abstractions.BaseTypes;
using ArchiWorkshop.Domains.Abstractions.Results;
using ArchiWorkshop.Domains.Abstractions.Utilities;

namespace ArchiWorkshop.Adapters.Infrastructure.Validators;

public class Validator : IValidator
{
    private readonly List<Error> _errors = [];
    public bool IsValid => _errors.IsNullOrEmpty();
    public bool IsInvalid => !IsValid;

    public IValidator If(bool condition, Error thenError)
    {
        if (condition is true)
        {
            _errors.Add(thenError);
        }

        return this;
    }

    public IValidator Validate<TValueObject>(Result<TValueObject> result)
        where TValueObject : ValueObject
    {
        if (result.IsFailure)
        {
            _errors.Add(result.Error);
        }

        return this;
    }

    public IValidator Validate<TValueObject>(ValidationResult<TValueObject> validationResult)
        where TValueObject : ValueObject
    {
        if (validationResult.IsFailure)
        {
            _errors.AddRange(validationResult.ValidationErrors);
        }

        return this;
    }

    public ValidationResult Failure()
    {
        if (IsValid)
        {
            throw new InvalidOperationException("Validation was successful, but Failure was called");
        }

        return ValidationResult.WithErrors(_errors.ToArray());
    }

    public ValidationResult<TResponse> Failure<TResponse>()
        where TResponse : IResponse
    {
        if (IsValid)
        {
            throw new InvalidOperationException("Validation was successful, but Failure was called");
        }

        return ValidationResult<TResponse>.WithErrors(_errors.ToArray());
    }
}
