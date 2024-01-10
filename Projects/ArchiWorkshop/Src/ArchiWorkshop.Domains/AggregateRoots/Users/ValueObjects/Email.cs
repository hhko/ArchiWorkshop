using ArchiWorkshop.Domains.Abstractions.BaseTypes;
using Microsoft.VisualBasic;

namespace ArchiWorkshop.Domains.AggregateRoots.Users.ValueObjects;

public class Email : ValueObject
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Email Create(string email)
    {
        return new Email(email);
    }
}
