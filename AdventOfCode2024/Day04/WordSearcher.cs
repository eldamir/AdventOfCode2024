using System.ComponentModel;

namespace AdventOfCode2024.Day04;

public class WordSearcher
{
    public int SearchWords(string wordToSearch, LetterMap map)
    {
        char[] letters = wordToSearch.ToCharArray();
        int occurrences = 0;
        
        for (int column = 0; column < map.Columns; column++)
        {
            for (int row = 0; row < map.Rows; row++)
            {
                occurrences += SearchWord(letters, map, row, column);
            }
        }
        
        return occurrences;
    }

    public int SearchIntersectingWords(string wordToSearch, LetterMap map)
    {
        if (wordToSearch.Length % 2 == 0)
        {
            throw new ArgumentException("wordToSearch must have an odd number of characters");
        }
        char[] letters = wordToSearch.ToCharArray();
        char[] reverseLetters = letters.Reverse().ToArray();
        int occurrences = 0;
        
        for (int row = 0; row < map.Rows; row++)
        {
            for (int column = 0; column < map.Columns; column++)
            {
                bool match = SearchWord(letters, map, row, column, Direction.RightDown) == 1;
                bool reverseMatch = SearchWord(reverseLetters, map, row, column, Direction.RightDown) == 1;
                if (match || reverseMatch)
                {
                    // Matches in one direction. Check if there is an intersecting match
                    int offset = wordToSearch.Length / 2 + 1;
                    bool intersectingMatch = SearchWord(letters, map, row, column + offset, Direction.LeftDown) == 1;
                    bool reverseIntersectingMatch = SearchWord(reverseLetters, map, row, column + offset, Direction.LeftDown) == 1;
                    if (intersectingMatch || reverseIntersectingMatch)
                    {
                        occurrences += 1;
                    }
                }
            }
        }
        
        return occurrences;
    }

    private int SearchWord(char[] wordToSearch, LetterMap map, int row, int column)
    {
        // If the first letter doesn't match, return early
        try
        {
            if (map.GetLetter(row, column) != wordToSearch[0]) return 0;
        }
        catch (ArgumentOutOfRangeException)
        {
            return 0;
        }
        
        int occurrences = 0;
        occurrences += SearchWord(wordToSearch, map, row, column, Direction.Left);
        occurrences += SearchWord(wordToSearch, map, row, column, Direction.Right);
        occurrences += SearchWord(wordToSearch, map, row, column, Direction.Up);
        occurrences += SearchWord(wordToSearch, map, row, column, Direction.Down);
        occurrences += SearchWord(wordToSearch, map, row, column, Direction.LeftUp);
        occurrences += SearchWord(wordToSearch, map, row, column, Direction.LeftDown);
        occurrences += SearchWord(wordToSearch, map, row, column, Direction.RightUp);
        occurrences += SearchWord(wordToSearch, map, row, column, Direction.RightDown);
        return occurrences;
    }

    private int SearchWord(char[] wordToSearch, LetterMap map, int row, int column, Direction direction)
    {
        var iterator = new Iterator2D(direction, row, column);
        foreach (var letter in wordToSearch)
        {
            try
            {
                if (map.GetLetter(iterator.Row, iterator.Column) != letter) return 0;
                iterator.Advance();

            }
            catch (ArgumentOutOfRangeException)
            {
                return 0;
            }
        }

        return 1;
    }

    private enum Direction { Left, Right, Up, Down, LeftUp, RightUp, LeftDown, RightDown }

    private class Iterator2D(Direction direction, int row, int column)
    {
        private int _column = column;
        private int _row = row;
        public int Row => _row;
        public int Column => _column;

        public void Advance()
        {
            switch (direction)
            {
                case Direction.Left:
                case Direction.LeftDown:
                case Direction.LeftUp:
                    _column--;
                    break;
                case Direction.Right:
                case Direction.RightDown:
                case Direction.RightUp:
                    _column++;
                    break;
            }

            switch (direction)
            {
                case Direction.Up:
                case Direction.LeftUp:
                case Direction.RightUp:
                    _row--;
                    break;
                case Direction.Down:
                case Direction.LeftDown:
                case Direction.RightDown:
                    _row++;
                    break;
            }
        }
    }
}