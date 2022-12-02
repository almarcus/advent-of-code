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

    [Fact]
    public void Day2aExample()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day2aExample.txt");

        var problem = new Day2(input);

        Assert.Equal(15, problem.Solve());
    }

    [Fact]
    public void Day2aSolution()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day2.txt");

        var problem = new Day2(input);

        Assert.Equal(11386, problem.Solve());
    }

    [Fact]
    public void Day2bExample()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day2aExample.txt");

        var problem = new Day2(input, false);

        Assert.Equal(12, problem.Solve());
    }

    [Fact]
    public void Day2bSolution()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day2.txt");

        var problem = new Day2(input, false);

        Assert.Equal(13600, problem.Solve());
    }
}