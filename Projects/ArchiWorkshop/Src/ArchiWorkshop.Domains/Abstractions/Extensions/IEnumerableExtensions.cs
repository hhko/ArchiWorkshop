namespace ArchiWorkshop.Domains.Abstractions.Extensions;

public static class IEnumerableUtilities
{
    public static string Join<TValue>(this IEnumerable<TValue> items, char separator)
    {
        return string.Join(separator, items);
    }

    public static string Join<TValue>(this IEnumerable<TValue> items, string separator)
    {
        return string.Join(separator, items);
    }
}
