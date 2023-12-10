namespace DependencyRejection;

internal sealed class Pure
{
    public enum ComparisonResult
    {
        Bigger,
        Smaller,
        Equal
    }

    public static ComparisonResult CompareTwoStrings(string? first, string? second)
    {
        int compare = string.Compare(first, second);
        if (compare > 0)
            return ComparisonResult.Bigger;
        else if (compare < 0)
            return ComparisonResult.Smaller;
        else
            return ComparisonResult.Equal;
    }
}
