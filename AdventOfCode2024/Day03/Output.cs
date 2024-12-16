namespace AdventOfCode2024.Day03;

public class Output
{
    public static void Main()
    {
        var result1 = new Program().SumOfAllMultiplications(Parser.Parse(Input.Data, false));
        Console.WriteLine($"Part1 result: {result1}");
        
        var result2 = new Program().SumOfAllMultiplicationsWithConditionals(Parser.Parse(Input.Data, true));
        Console.WriteLine($"Part2 result: {result2}");
    }
}