namespace AdventOfCode2024.Day01;

public class Calculator
{
    public int CalculateDistance(List<int> leftList, List<int> rightList)
    {
        leftList.Sort();
        rightList.Sort();
        
        var totalDistance = 0;

        for (int i = 0; i < leftList.Count; i++)
        {
            int left = leftList[i];
            int right = rightList[i];
            int distance = Math.Abs(left - right);
            totalDistance += distance;
        }
        return totalDistance;
    }

    public int CalculateSimilarityScore(List<int> leftList, List<int> rightList)
    {
        leftList.Sort();
        rightList.Sort();
        
        var totalScore = 0;

        for (int i = 0; i < leftList.Count; i++)
        {
            int left = leftList[i];
            var occurrences = rightList.FindAll(x => x == left).Count;
            int score = left * occurrences;
            totalScore += score;
        }
        return totalScore;
    }
}