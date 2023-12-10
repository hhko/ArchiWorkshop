using DependencyRejection;
using static DependencyRejection.Pure;

Console.WriteLine("Enter the first value");
string? first = Console.ReadLine();
Console.WriteLine("Enter the second value");
string? second = Console.ReadLine();

ComparisonResult comparisonResult = CompareTwoStrings(first, second);

//switch comparisonResult 
Console.WriteLine("The first value is bigger");
Console.WriteLine("The first value is smaller");
Console.WriteLine("The values are equal");