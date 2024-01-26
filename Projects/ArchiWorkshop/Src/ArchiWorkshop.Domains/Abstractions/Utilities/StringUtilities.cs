using System.Buffers;

namespace ArchiWorkshop.Domains.Abstractions.Utilities;

public static class StringUtilities
{
    public static readonly char[] IllegalCharacters =
        ['!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '\'', '"', '[', ']', ';', ':', '\\', '|', '/', '.', ',', '>', '<', '?', '-', '_', '+', '+', '~', '`'];

    // The New Best Way To Search for Values in .NET 8: SearchValues.Create
    // https://www.youtube.com/watch?v=IzDMg916t98
    // https://learn.microsoft.com/ko-kr/dotnet/api/system.buffers.searchvalues-1?view=net-8.0
    private static readonly SearchValues<char> _illeagalCharacterSearchValues = SearchValues.Create(IllegalCharacters);

    public static bool IsNullOrEmptyOrWhiteSpace(this string? input)
    {
        return string.IsNullOrWhiteSpace(input);
    }

    public static bool ContainsIllegalCharacter(this string input)
    {
        return input.AsSpan().IndexOfAny(_illeagalCharacterSearchValues) is not -1;
    }
}
