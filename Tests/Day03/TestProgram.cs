using System.Text.RegularExpressions;
using AdventOfCode2024.Day03;

namespace Tests.Day03;

public class TestProgram
{
    [Fact]
    public void TestParser()
    {
        var testInput = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        var instructions = Parser.Parse(testInput, false);
        Assert.Equal(4, instructions.Count);
        Assert.Equal(2, ((ArithmeticInstruction)instructions[0]).left);
        Assert.Equal(4, ((ArithmeticInstruction)instructions[0]).right);
        Assert.Equal(5, ((ArithmeticInstruction)instructions[1]).left);
        Assert.Equal(5, ((ArithmeticInstruction)instructions[1]).right);
        Assert.Equal(11, ((ArithmeticInstruction)instructions[2]).left);
        Assert.Equal(8, ((ArithmeticInstruction)instructions[2]).right);
        Assert.Equal(8, ((ArithmeticInstruction)instructions[3]).left);
        Assert.Equal(5, ((ArithmeticInstruction)instructions[3]).right);
    }

    [Fact]
    public void TestSumOfMultiplications()
    {
        var testInput = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
        var instructions = Parser.Parse(testInput, false);
        var result = new Program().SumOfAllMultiplications(instructions);
        Assert.Equal(161, result);
    }

    [Fact]
    public void TestSumOfMultiplicationsWithConditionals()
    {
        var testInput = "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))";
        var instructions = Parser.Parse(testInput, true);
        var result = new Program().SumOfAllMultiplicationsWithConditionals(instructions);
        Assert.Equal(48, result);
    }
}