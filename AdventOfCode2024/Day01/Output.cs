namespace AdventOfCode2024.Day01;

public class Output
{
    public static void Main()
    {
        var lists = Parser.Parse(Input.Data);
        var result1 = new Calculator().CalculateDistance(lists.Item1, lists.Item2);
        Console.WriteLine($"Part1: Total distance is: {result1}");
        
        var result2 = new Calculator().CalculateSimilarityScore(lists.Item1, lists.Item2);
        Console.WriteLine($"Part2: Similarity score is: {result2}");
    }
}