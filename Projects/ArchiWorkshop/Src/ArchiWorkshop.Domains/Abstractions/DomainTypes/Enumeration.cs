using System.Reflection;

namespace ArchiWorkshop.Domains.Abstractions.DomainTypes;

public abstract class Enumeration<TEnum> 
    : IEquatable<Enumeration<TEnum>>
    , IComparable<Enumeration<TEnum>>
    where TEnum : Enumeration<TEnum>
{
    private static readonly string EnumerationName = typeof(TEnum).Name;
    private static readonly Lazy<Dictionary<int, TEnum>> EnumerationsDictionary =
        new(() => CreateEnumerationDictionary(typeof(TEnum)));

    protected Enumeration(int id, string name)
        : this()
    {
        Id = id;
        Name = name;
    }

    protected Enumeration()
    {
        Id = default;
        Name = string.Empty;
    }

    public static IReadOnlyCollection<TEnum> List => EnumerationsDictionary.Value.Values.ToList().AsReadOnly();
    public static IReadOnlyCollection<int> Ids => EnumerationsDictionary.Value.Keys.ToList().AsReadOnly();

    public int Id { get; protected init; }

    public string Name { get; protected init; }

    public virtual bool Equals(Enumeration<TEnum>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return other.Id.Equals(Id);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Enumeration<TEnum> otherValue)
        {
            return false;
        }

        return otherValue.Id.Equals(Id);
    }

    public static bool operator ==(Enumeration<TEnum>? first, Enumeration<TEnum>? second)
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

    public static bool operator !=(Enumeration<TEnum> first, Enumeration<TEnum> second)
    {
        return !(first == second);
    }

    public int CompareTo(Enumeration<TEnum>? other)
    {
        return other is null
            ? 1
            : Id.CompareTo(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * 37;
    }

    public static TEnum? FromId(int id)
    {
        var isValueInDictionary = EnumerationsDictionary
            .Value
            .TryGetValue(id, out TEnum? enumeration);

        return isValueInDictionary
            ? enumeration
            //: throw new EnumerationNotFoundException(EnumerationName, id);
            : null;
    }

    public static TEnum? FromName(string name)
    {
        return EnumerationsDictionary
            .Value
            .Values
            .SingleOrDefault(x => x.Name == name);
    }

    public static bool Contains(int id)
    {
        return EnumerationsDictionary
            .Value
            .ContainsKey(id);
    }

    public static HashSet<string> GetNames()
    {
        return List
            .Select(p => p.Name)
            .ToHashSet();
    }

    // 상속 받은 클래스로부터 IEnumerable<TEnum>과 Dictionary<int, TEnum> 객체를 생성한다.
    private static Dictionary<int, TEnum> CreateEnumerationDictionary(Type enumType)
    {
        return GetFieldsForType(enumType)
            .ToDictionary(t => t.Id);
    }

    private static IEnumerable<TEnum> GetFieldsForType(Type enumType)
    {
        return enumType
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fieldInfo => enumType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo => (TEnum)fieldInfo.GetValue(default)!);

        //return enumType
        //    .GetProperties(BindingFlags.Public | BindingFlags.Instance)
        //    .Where(propertyInfo => typeof(TProperty).IsAssignableFrom(propertyInfo.PropertyType))
        //    .Select(propertyInfo => (TProperty) propertyInfo.GetValue(new Person())!);
    }
}