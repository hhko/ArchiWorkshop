using static DependencyRejection.Pure;

Console.WriteLine("Enter the first value");
string? first = Console.ReadLine();
Console.WriteLine("Enter the second value");
string? second = Console.ReadLine();

ComparisonResult comparisonResult = CompareTwoStrings(first, second);

string output = comparisonResult switch
{
    ComparisonResult.Bigger => "The first value is bigger",
    ComparisonResult.Smaller => "The first value is smaller",
    ComparisonResult.Equal => "The values are equal",
    _ => throw new NotSupportedException()
};
Console.WriteLine(output);
