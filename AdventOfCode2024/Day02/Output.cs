namespace AdventOfCode2024.Day02;

public class Output
{
    
    public static void Main()
    {
        var result1 = new ReportAnalyser(Parser.Parse(Input.Data)).SafeReportCount;
        Console.WriteLine($"Part1 result: {result1}");
        
        var result2 = new ReportAnalyser(Parser.Parse(Input.Data), hasDampener: true).SafeReportCount;
        Console.WriteLine($"Part2 result: {result2}");
    }
}