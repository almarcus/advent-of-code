namespace UnitTests;
using AOC2024;
using Utilities;
using Xunit.Abstractions;

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

}
