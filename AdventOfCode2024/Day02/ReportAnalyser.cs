namespace AdventOfCode2024.Day02;

public class ReportAnalyser
{
    public int SafeReportCount => SafeReports.Count;
    private List<Report> SafeReports = new();
    
    public ReportAnalyser(List<Report> reports, bool hasDampener = false)
    {
        foreach (var report in reports)
        {
            bool isSafe = IsSafe(report.Numbers, withDampener: hasDampener);
            if (!isSafe && hasDampener)
            {
                // Try again but use the dampener to remove the 2nd value, which determined the
                // direction, since this may result in a safe report
                isSafe = IsSafe(report.Numbers.Where((value, index) => index != 1).ToArray(), withDampener: false);
            }

            if (!isSafe && hasDampener)
            {
                // Still not safe, but we can still try removing the first number
                isSafe = IsSafe(report.Numbers.Skip(1).ToArray(), withDampener: false);
            }
            if (isSafe)
            {
                SafeReports.Add(report);
            }
        }
    }

    private bool IsSafe(int[] numbers, bool withDampener)
    {
        var determinedState = ReportState.Undefined;
        int lastNumber = numbers.First();
        bool unsafeLevelRemoved = false;
        foreach (var number in numbers.Skip(1))
        {
            var state = ReportState.Undefined;
            if (number > lastNumber)
            {
                state = ReportState.Increasing;
            } else if (number < lastNumber)
            {
                state = ReportState.Decreasing;
            }
            if (determinedState == ReportState.Undefined)
            {
                determinedState = state;
            } else if (determinedState != state)
            {
                // Conflict of state!
                if (withDampener && !unsafeLevelRemoved)
                {
                    unsafeLevelRemoved = true;
                    continue;
                }
                return false;
            }

            var difference = Math.Abs(number - lastNumber);
            if (difference > 3 || difference < 1)
            {
                // too big or too small difference
                if (withDampener && !unsafeLevelRemoved)
                {
                    unsafeLevelRemoved = true;
                    continue;
                }
                return false;
            }
            
            // Prepare for next iteration
            lastNumber = number;
        }

        return true;
    }

    enum ReportState
    {
        Undefined,
        Increasing,
        Decreasing,
    }
}