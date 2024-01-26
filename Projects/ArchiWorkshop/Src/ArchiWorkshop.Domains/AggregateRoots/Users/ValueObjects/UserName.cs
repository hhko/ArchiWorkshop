using ArchiWorkshop.Domains.Abstractions.BaseTypes;
using ArchiWorkshop.Domains.Abstractions.Results;
using ArchiWorkshop.Domains.Abstractions.Utilities;
using static ArchiWorkshop.Domains.Abstractions.Utilities.ListUtilities;
using static ArchiWorkshop.Domains.AggregateRoots.Users.Errors.DomainErrors;

namespace ArchiWorkshop.Domains.AggregateRoots.Users.ValueObjects;

public sealed class UserName : ValueObject
{
    public const int MaxLength = 30;

    private UserName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static ValidationResult<UserName> Create(string userName)
    {
        var errors = Validate(userName);
        return errors.CreateValidationResult(() => new UserName(userName));
    }

    public static IList<Error> Validate(string userName)
    {
        return EmptyList<Error>()
            .If(userName.IsNullOrEmptyOrWhiteSpace(), UserNameError.Empty)
            .If(userName.Length > MaxLength, UserNameError.TooLong)
            .If(userName.ContainsIllegalCharacter(), UserNameError.ContainsIllegalCharacter);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
