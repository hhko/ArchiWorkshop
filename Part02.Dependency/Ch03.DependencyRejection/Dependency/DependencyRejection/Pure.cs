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
        return string.Compare(first, second) switch
        {
            > 0 => ComparisonResult.Bigger,
            < 0 => ComparisonResult.Smaller,
            _ => ComparisonResult.Equal
        };
    }
}
