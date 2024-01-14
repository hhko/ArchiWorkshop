using ArchiWorkshop.Domains.Abstractions.BaseTypes;

namespace ArchiWorkshop.Domains.Abstractions.Results;

public static class ErrorUtilities
{
    public static ValidationResult<TValueObject> CreateValidationResult<TValueObject>(
        this ICollection<Error> errors,
        Func<TValueObject> createValueObject) where TValueObject : ValueObject
    {
        if (errors is null)
        {
            throw new ArgumentNullException($"{nameof(errors)} must not be null");
        }

        if (errors.Count != 0)
        {
            return ValidationResult<TValueObject>.WithErrors(errors.ToArray());
        }

        return ValidationResult<TValueObject>.WithoutErrors(createValueObject.Invoke());
    }

    public static IList<Error> If(
        this IList<Error> errors,
        bool condition,
        Error error)
    {
        if (condition is true)
        {
            errors.Add(error);
        }

        return errors;
    }

    public static IList<Error> UseValidation<TValue>(
        this IList<Error> errors,
        Func<IList<Error>, TValue, IList<Error>> validationSegment,
        TValue valueUnderValidation)
    {
        return validationSegment(errors, valueUnderValidation);
    }

    public static IList<Error> UseValidation<TValue>(
        this IList<Error> errors,
        Func<TValue, IList<Error>> validationSegment,
        TValue valueUnderValidation)
    {
        var errorsToAdd = validationSegment(valueUnderValidation);

        foreach (var errorToAdd in errorsToAdd)
        {
            errorsToAdd.Add(errorToAdd);
        }

        return errors;
    }
}
