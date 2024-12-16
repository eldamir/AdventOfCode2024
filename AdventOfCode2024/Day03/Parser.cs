using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day03;

public class Parser
{
    static readonly string pattern = @"mul\((\d+),(\d+)\)";
    static readonly string patternWithConditionals = @"(?:mul\((\d+),(\d+)\))|do\(\)|don't\(\)";
    public static List<BaseInstruction> Parse(string input, bool withConditionals)
    {
        var matches = Regex.Matches(input, withConditionals ? patternWithConditionals : pattern);
        return matches
            .Select<Match, BaseInstruction>(match =>
                {
                    if (match.Groups[0].Value == "don't()")
                    {
                        return new Dont();
                    }

                    if (match.Groups[0].Value == "do()")
                    {
                        return new Do();
                    }
                    
                    return new ArithmeticInstruction(
                        int.Parse(match.Groups[1].Value),
                        int.Parse(match.Groups[2].Value)
                    );
                }
            )
            .ToList();
    }
}