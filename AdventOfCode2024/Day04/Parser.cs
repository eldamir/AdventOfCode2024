namespace AdventOfCode2024.Day04;

public class Parser
{
    public static LetterMap Parse(string input)
    {
        var letterMap = new LetterMap();
        input.Trim()
            .Split('\n')
            .ToList()
            .ForEach(line => letterMap.AddRow(line.ToList()));

        return letterMap;
    }
}