namespace UnitTests;
using AOC2022;
using Utilities;

public class AoC2022Tests
{
    [Fact]
    public void Day1aExample()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day1aExample.txt");

        var problem = new Day1(input);

        Assert.Equal(24000, problem.Solve(1));
    }

    [Fact]
    public void Day1Solution()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day1.txt");

        var problem = new Day1(input);

        Assert.Equal(71780, problem.Solve(1));
        Assert.Equal(212489, problem.Solve(3));
    }


}