namespace AdventOfCode2024.Day03;

public class Program
{
    public int SumOfAllMultiplications(List<BaseInstruction> instructions)
    {
        bool doMultiplication = true;
        return instructions
            .Cast<ArithmeticInstruction>()
            .Select(instruction => instruction.left * instruction.right)
            .Sum();
    }
    
    public int SumOfAllMultiplicationsWithConditionals(List<BaseInstruction> instructions)
    {
        bool doMultiplication = true;
        return instructions
            .Select(instruction =>
            {
                if (instruction is Do)
                {
                    doMultiplication = true;
                } else if (instruction is Dont)
                {
                    doMultiplication = false;
                } else if (instruction is ArithmeticInstruction arithmeticInstruction && doMultiplication)
                {
                    return arithmeticInstruction.left * arithmeticInstruction.right;
                }

                return 0;
            })
            .Sum();
    }
}