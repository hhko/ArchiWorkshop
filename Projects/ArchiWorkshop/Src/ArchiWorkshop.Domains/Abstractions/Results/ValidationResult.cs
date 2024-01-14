namespace ArchiWorkshop.Domains.Abstractions.Results;

public sealed class ValidationResult : Result, IValidationResult
{
    // 캐시 목적으로 사용한다
    private static readonly ValidationResult _successValidationResult = new();

    private ValidationResult(Error[] validationErrors)
        : base(Error.ValidationError)
    {
        ValidationErrors = validationErrors;
    }

    private ValidationResult()
        : base(Error.None)
    {
        ValidationErrors = Array.Empty<Error>();
    }

    public Error[] ValidationErrors { get; }

    //public static ValidationResult WithErrors(ICollection<Error> validationErrors)
    //{
    //    return new ValidationResult(validationErrors.ToArray());
    //}
    public static ValidationResult WithErrors(Error[] validationErrors)
    {
        return new ValidationResult(validationErrors);
    }

    public static ValidationResult WithoutErrors()
    {
        return _successValidationResult;
    }
}

public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    private ValidationResult(Error[] validationErrors)
        : base(default, Error.ValidationError)
    {
        ValidationErrors = validationErrors;
    }

    private ValidationResult(TValue? value)
        : base(value, Error.None)
    {
        ValidationErrors = Array.Empty<Error>();
    }

    public Error[] ValidationErrors { get; }

    public static ValidationResult<TValue> WithErrors(Error[] validationErrors)
    {
        return new ValidationResult<TValue>(validationErrors);
    }

    public static ValidationResult<TValue> WithoutErrors(TValue? value)
    {
        return new ValidationResult<TValue>(value);
    }
}

