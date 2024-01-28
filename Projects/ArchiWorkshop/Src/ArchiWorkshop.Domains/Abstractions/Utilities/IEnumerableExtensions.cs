namespace ArchiWorkshop.Domains.Abstractions.Utilities;

public static class IEnumerableUtilities
{
    public static string Join<TValue>(this IEnumerable<TValue> enumerable, char separator)
    {
        return string.Join(separator, enumerable);
    }

    public static string Join<TValue>(this IEnumerable<TValue> enumerable, string separator)
    {
        return string.Join(separator, enumerable);
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable != null)
        {
            return !enumerable.Any();
        }

        return true;
    }
}
