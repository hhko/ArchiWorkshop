using ArchiWorkshop.Domains.Abstractions.Utilities;

namespace ArchiWorkshop.Domains.Abstractions.BaseTypes;

[Serializable]
public abstract class ValueObject : IEquatable<ValueObject>
{
    //public const string Value = nameof(Value);

    public abstract IEnumerable<object> GetAtomicValues();

    public bool Equals(ValueObject? other)
    {
        return other is not null 
            && ValuesAreEqual(other);
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject valueObject 
            && ValuesAreEqual(valueObject);
        
        //if (obj is null)
        //{
        //    return false;
        //}
        //
        //if (GetType() != obj.GetType())
        //{
        //    return false;
        //}
        //
        //if (obj is not ValueObject otherValueObject)
        //{
        //    return false;
        //}
        //
        //return ValuesAreEqual(otherValueObject);
    }

    private bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues()
            .SequenceEqual(other.GetAtomicValues());
    }

    public static bool operator ==(ValueObject? first, ValueObject? second)
    {
        if (first is null && second is null)
        {
            return true;
        }

        if (first is null || second is null)
        {
            return false;
        }

        return first.Equals(second);
    }

    public static bool operator !=(ValueObject? first, ValueObject? second)
    {
        return !(first == second);
    }

    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(
                default(int), 
                (hashcode, value) => HashCode.Combine(hashcode, value.GetHashCode()));
    }

    public override string ToString()
    {
        return GetAtomicValues()
            .Join(", ");
    }
}
