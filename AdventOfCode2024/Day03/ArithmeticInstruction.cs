namespace AdventOfCode2024.Day03;

public record BaseInstruction;

public record Do : BaseInstruction;

public record Dont : BaseInstruction;
public record ArithmeticInstruction(int left, int right) : BaseInstruction;
