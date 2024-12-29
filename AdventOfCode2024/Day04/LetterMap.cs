namespace AdventOfCode2024.Day04;

public class LetterMap
{
    private readonly List<List<char>> _map;

    public LetterMap()
    {
        _map = new();
    }

    public int Columns => _map[0].Count;
    public int Rows => _map.Count;

    public void AddRow(List<char> row)
    {
        _map.Add(row);
    }

    public char GetLetter(int row, int column)
    {
        return _map[row][column];
    }
}