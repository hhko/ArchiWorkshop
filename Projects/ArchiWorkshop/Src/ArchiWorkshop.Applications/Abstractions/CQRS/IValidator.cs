using ArchiWorkshop.Domains.Abstractions.BaseTypes;
using ArchiWorkshop.Domains.Abstractions.Results;

namespace ArchiWorkshop.Applications.Abstractions.CQRS;

public interface IValidator
{
    bool IsValid { get; }
    bool IsInvalid { get; }

    // Validation 수행
    IValidator If(bool condition, Error thenError);
    IValidator Validate<TValueObject>(Result<TValueObject> result)
        where TValueObject : ValueObject;
    IValidator Validate<TValueObject>(ValidationResult<TValueObject> validationResult)
        where TValueObject : ValueObject;

    // ValidationResult 객체 생성
    ValidationResult Failure();
    ValidationResult<TResponse> Failure<TResponse>()
            where TResponse : IResponse;
}