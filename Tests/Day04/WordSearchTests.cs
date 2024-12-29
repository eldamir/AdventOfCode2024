using AdventOfCode2024.Day04;

namespace Tests.Day04;

public class WordSearchTests
{
    [Fact]
    public void SearchWordsTest()
    {
        var input = @"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX";

        var map = Parser.Parse(input);
        var wordSearcher = new WordSearcher();
        int count = wordSearcher.SearchWords("XMAS", map);
        
        Assert.Equal(18, count);
    }

    [Fact]
    public void SearchIntersectingWordsTest()
    {
        var input = @"MMMSXXMASM
MSAMXMSMSA
AMXSXMAAMM
MSAMASMSMX
XMASAMXAMM
XXAMMXXAMA
SMSMSASXSS
SAXAMASAAA
MAMMMXMMMM
MXMXAXMASX";

        var map = Parser.Parse(input);
        var wordSearcher = new WordSearcher();
        int count = wordSearcher.SearchIntersectingWords("MAS", map);
        
        Assert.Equal(9, count);
    }
}