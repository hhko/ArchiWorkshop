namespace DependencyRetention;

internal sealed class Impure
{
    public static void CompareTwoStrings()
    {
        Console.WriteLine("Enter the first value");
        string? first = Console.ReadLine();
        Console.WriteLine("Enter the second value");
        string? second = Console.ReadLine();

        int compare = string.Compare(first, second);
        if (compare > 0)
            Console.WriteLine("The first value is bigger");
        else if (compare < 0)
            Console.WriteLine("The first value is smaller");
        else
            Console.WriteLine("The values are equal");
    }
}
