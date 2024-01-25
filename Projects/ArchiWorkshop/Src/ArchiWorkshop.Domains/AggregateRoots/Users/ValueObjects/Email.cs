using System.Text.RegularExpressions;
using ArchiWorkshop.Domains.Abstractions.BaseTypes;
using ArchiWorkshop.Domains.Abstractions.Results;
using ArchiWorkshop.Domains.Abstractions.Utilities;
using static System.Text.RegularExpressions.RegexOptions;
using static ArchiWorkshop.Domains.Abstractions.Utilities.ListUtilities;
using static ArchiWorkshop.Domains.AggregateRoots.Users.Errors.DomainErrors;

namespace ArchiWorkshop.Domains.AggregateRoots.Users.ValueObjects;

public class Email : ValueObject
{
    public const int MaxLength = 40;

    private static readonly Regex _regex = new(@"^([a-zA-Z])([a-zA-Z0-9]+)\.?([a-zA-Z0-9]+)@([a-z]+)\.[a-z]{2,3}$", Compiled | CultureInvariant | Singleline, TimeSpan.FromMilliseconds(100));

    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static ValidationResult<Email> Create(string email)
    {
        var errors = Validate(email);
        return errors.CreateValidationResult(() => new Email(email));
    }

    public static IList<Error> Validate(string email)
    {
        return EmptyList<Error>()
            .If(email.IsNullOrEmptyOrWhiteSpace(), EmailError.Empty)
            .If(email.Length > MaxLength, EmailError.TooLong)
            .If(_regex.NotMatch(email), EmailError.Invalid);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
