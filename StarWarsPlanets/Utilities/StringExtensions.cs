namespace StarWarsPlanets.Utilities;

public static class StringExtensions
{
    public static int? ToIntOrNull(this string? input) => 
        int.TryParse(input, out var resultParsed) 
        ? resultParsed 
        : null;

    public static long? ToLongOrNull(this string? input) =>
        long.TryParse(input, out var resultParsed)
        ? resultParsed
        : null;
}
