namespace AdventOfCode2024.Day01;

public class Parser
{
    public static Tuple<List<int>,List<int>> Parse(string testInput)
    {
        List<int> leftList = new();
        List<int> rightList = new();
        var lines = testInput
            .Trim()
            .Split("\n");

        foreach (var line in lines)
        {
            var parts = line.Split("   ");
            leftList.Add(int.Parse(parts[0]));
            rightList.Add(int.Parse(parts[1]));
        }
        
        return new Tuple<List<int>, List<int>>(leftList, rightList);
    }
}