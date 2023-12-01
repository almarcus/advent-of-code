namespace UnitTests;
using AOC2019;
using Utilities;
using Xunit.Abstractions;

public class AoC2019Tests
{

    private readonly ITestOutputHelper output;

    public AoC2019Tests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [InlineData(@"2023/Inputs/Day1Example1.txt", false, 142)] // Part 1
    [InlineData(@"2023/Inputs/Day1.txt", false, 55621)] // Part 1
    [InlineData(@"2023/Inputs/Day1Example2.txt", true, 281)] // Part 2
    [InlineData(@"2023/Inputs/Day1.txt", true, 53592)] // Part 2
    public void Day1Solutions(string filename, bool translateSpelledOutNumbers, int expectedResult)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day1(input, translateSpelledOutNumbers);
        Assert.Equal(expectedResult, problem.Solve());
    }
}