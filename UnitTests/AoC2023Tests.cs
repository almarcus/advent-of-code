namespace UnitTests;
using AOC2023;
using Utilities;
using Xunit.Abstractions;

public class AoC2023Tests
{

    private readonly ITestOutputHelper output;

    public AoC2023Tests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [InlineData(@"2023/Inputs/Day1Example.txt", 142)]
    // [InlineData(@"2023/Inputs/Day1Example.txt", 3, 45000)]
    // [InlineData(@"2023/Inputs/Day1.txt", 1, 71780)]
    // [InlineData(@"2023/Inputs/Day1.txt", 3, 212489)]
    public void Day1Solutions(string filename, int expectedResult)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day1(input);
        Assert.Equal(expectedResult, problem.Solve());
    }
}