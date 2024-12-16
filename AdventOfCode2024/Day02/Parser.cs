namespace AdventOfCode2024.Day02;

public class Parser
{
    public static List<Report> Parse(string testInput)
    {
        return testInput
            .Split("\n")
            .Select((line) => new Report(line.Split(" ").Select(int.Parse).ToArray()))
            .ToList()
            ;
    }
}