using AdventOfCode2024.Day02;

namespace Tests.Day02;

public class ReportAnalyserTests
{
    [Fact]
    public void TestReportAnalyserCountsSafeReports()
    {
        var testInput = @"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9";
        
        var reports = Parser.Parse(testInput);
        var reportAnalyser = new ReportAnalyser(reports);
        var safeReports = reportAnalyser.SafeReportCount;
        
        Assert.Equal(2, safeReports);
    }

    [Fact]
    public void TestReportAnalyserCountsSafeReportsWithDampener()
    {
        var testInput = @"7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9";
        
        var reports = Parser.Parse(testInput);
        var reportAnalyser = new ReportAnalyser(reports, hasDampener: true);
        var safeReports = reportAnalyser.SafeReportCount;
        
        Assert.Equal(4, safeReports);
    }
    
    [Fact]
    public void TestReportAnalyserCountsSafeReportsWithDampener_EdgeCase1()
    {
        // There is an edgecase, where we determine the state, but could
        // use the dampener to remove the deciding number and change the outcome:
        // In this case, we will decide that it is increasing because of the
        // number "8", but if we remove it, we have a valid decreasing list
        var testInput = @"7 8 6 5 4";
        
        var reports = Parser.Parse(testInput);
        var reportAnalyser = new ReportAnalyser(reports, hasDampener: true);
        var safeReports = reportAnalyser.SafeReportCount;
        
        Assert.Equal(1, safeReports);
    }
    
    [Fact]
    public void TestReportAnalyserCountsSafeReportsWithDampener_EdgeCase2()
    {
        // There is an edgecase, where we determine the state, but could
        // use the dampener to remove the deciding number and change the outcome:
        // In this case, we will decide that it is increasing because of the
        // number "8", but if we remove it, we have a valid decreasing list
        var testInput = @"7 6 8 9 10";
        
        var reports = Parser.Parse(testInput);
        var reportAnalyser = new ReportAnalyser(reports, hasDampener: true);
        var safeReports = reportAnalyser.SafeReportCount;
        
        Assert.Equal(1, safeReports);
    }
    
    [Fact]
    public void TestReportAnalyserCountsSafeReportsWithDampener_EdgeCase3()
    {
        // Safe, because the duplicated 5 can be removed
        var testInput = @"7 6 5 5 4";
        
        var reports = Parser.Parse(testInput);
        var reportAnalyser = new ReportAnalyser(reports, hasDampener: true);
        var safeReports = reportAnalyser.SafeReportCount;
        
        Assert.Equal(1, safeReports);
    }
    
    
    [Fact]
    public void TestReportAnalyserCountsSafeReportsWithDampener_EdgeCase4()
    {
        // Safe, because the first one can be removed
        var testInput = @"1 6 7 8 9";
        
        var reports = Parser.Parse(testInput);
        var reportAnalyser = new ReportAnalyser(reports, hasDampener: true);
        var safeReports = reportAnalyser.SafeReportCount;
        
        Assert.Equal(1, safeReports);
    }
}