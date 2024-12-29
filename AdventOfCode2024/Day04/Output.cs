namespace AdventOfCode2024.Day04;

public class Output
{
    public static void Main()
    {
        var result1 = new WordSearcher().SearchWords("XMAS", Parser.Parse(Input.Data));
        Console.WriteLine($"Part1 result: {result1}");
        
        var result2 = new WordSearcher().SearchIntersectingWords("MAS", Parser.Parse(Input.Data));
        Console.WriteLine($"Part2 result: {result2}");
    }
}