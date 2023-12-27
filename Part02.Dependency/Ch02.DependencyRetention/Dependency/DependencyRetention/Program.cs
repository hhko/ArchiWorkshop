Console.WriteLine("Enter the first value");
string? first = Console.ReadLine();
Console.WriteLine("Enter the second value");
string? second = Console.ReadLine();

int compare = string.Compare(first, second);

string output = compare switch
{
    > 0 => "The first value is bigger",
    < 0 => "The first value is smaller",
    _ => "The values are equal"
};
Console.WriteLine(output);