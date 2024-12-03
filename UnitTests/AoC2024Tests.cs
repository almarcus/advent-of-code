namespace UnitTests;
using AOC2024;
using Utilities;

public class AoC2024Tests
{

    private readonly ITestOutputHelper output;

    public AoC2024Tests(ITestOutputHelper output)
    {
        this.output = output;
    }
    
    [Theory]
    [InlineData(@"2024/Inputs/Day1Example.txt", 11, 31)]
    [InlineData(@"2024/Inputs/Day1.txt", 2196996, 23655822)]
    public void Day1Solutions(string filename, int expectedPart1Result, int expectedPart2Result)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day1(input);

        var part1 = problem.SolvePart1();
        var part2 = problem.SolvePart2();
        Assert.Equal(expectedPart1Result, part1);
        Assert.Equal(expectedPart2Result, problem.SolvePart2());
    }
    
    [Theory]
    [InlineData(@"2024/Inputs/Day2Example.txt", 2, 4)]
    [InlineData(@"2024/Inputs/Day2.txt", 334, 400)]
    public void Day2Solutions(string filename, int expectedPart1Result, int expectedPart2Result)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day2(input);

        var part1 = problem.SolvePart1();
        var part2 = problem.SolvePart2();
        Assert.Equal(expectedPart1Result, part1);
        Assert.Equal(expectedPart2Result, problem.SolvePart2());
    }

    [Theory]
    [InlineData("7 6 4 2 1", true)]
    [InlineData("1 2 7 8 9", false)]
    [InlineData("9 7 6 2 1", false)]
    [InlineData("1 3 2 4 5", false)]
    [InlineData("8 6 4 4 1", false)]
    [InlineData("1 3 6 7 9", true)]
    public void Day2SafeUnsafeTests(string input, bool expectedSafe)
    {
        Day2.Report report = new Day2.Report(input);
        Assert.Equal(expectedSafe, report.IsSafe);
    }
    
    

}
