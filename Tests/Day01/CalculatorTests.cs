using AdventOfCode2024.Day01;

namespace Tests.Day01;

public class CalculatorTests
{
    [Fact]
    public void CalculateDistance()
    {
        string testInput = @"3   4
4   3
2   5
1   3
3   9
3   3";
        
        Tuple<List<int>, List<int>> lists = Parser.Parse(testInput);
        
        var distance = new AdventOfCode2024.Day01.Calculator().CalculateDistance(lists.Item1, lists.Item2);
        Assert.Equal(11, distance);
    }

    [Fact]
    public void CalculateSimilarityScore()
    {
        string testInput = @"3   4
4   3
2   5
1   3
3   9
3   3";
        
        Tuple<List<int>, List<int>> lists = Parser.Parse(testInput);
        var similarityScore = new AdventOfCode2024.Day01.Calculator().CalculateSimilarityScore(lists.Item1, lists.Item2);
        Assert.Equal(31, similarityScore);
        
    }
}