using ArchiWorkshop.Domains.Abstractions.Results;
using ArchiWorkshop.Domains.AggregateRoots.Users.ValueObjects;

namespace ArchiWorkshop.Domains.AggregateRoots.Users.Errors;

public static partial class DomainErrors
{
    public static class UserNameError
    {
        public static readonly Error Empty = Error.New(
            $"{nameof(UserName)}.{nameof(Empty)}",
            $"{nameof(UserName)} name is Empty.");

        public static readonly Error TooLong = Error.New(
            $"{nameof(UserName)}.{nameof(TooLong)}",
            $"{nameof(UserName)} name must be at most {UserName.MaxLength} characters.");

        public static readonly Error ContainsIllegalCharacter = Error.New(
            $"{nameof(UserName)}.{nameof(ContainsIllegalCharacter)}",
            $"{nameof(UserName)} contains illegal character.");
    }
}
