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

    [Theory]
    [InlineData("aa",'a', 1)]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp",'p',16)]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",'L',38)]
    [InlineData("PmmdzqPrVvPwwTWBwg",'P',42)]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",'v',22)]
    [InlineData("ttgJtRGJQctTZtZT",'t',20)]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw",'s',19)]
    
    public void CheckRucksackProperties(string rucksackItems, char expectedCommonItem, int expectedPriority)
    {
        var rucksack = new Rucksack(rucksackItems);

        Assert.Equal(expectedCommonItem, rucksack.CommonItem);
        Assert.Equal(expectedPriority, rucksack.Priority);
    }

    [Fact]
    public void Day3aExample()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day3Example.txt");

        var problem = new Day3(input);

        Assert.Equal(157, problem.Solve());
    }

    [Fact]
    public void Day3bExample()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day3Example.txt");

        var problem = new Day3(input);

        Assert.Equal(70, problem.SolveWithBuckets(3));
    }


    [Fact]
    public void Day3Solution()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day3.txt");

        var problem = new Day3(input);

        Assert.Equal(7990, problem.Solve());
        Assert.Equal(2602, problem.SolveWithBuckets(3));
    }

    [Fact]
    public void Day4Example()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day4Example.txt");

        var problem = new Day4(input);

        Assert.Equal(6, problem.ElfPairs.Count);
        Assert.Equal(3, problem.ElfPairs[0].elf1.Sections.Count);
        Assert.Equal(3, problem.ElfPairs[0].elf2.Sections.Count);

        Assert.Equal(2, problem.Solve());
    }

    [Fact]
    public void Day4Solution()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day4.txt");

        var problem = new Day4(input);

        Assert.Equal(1000, problem.ElfPairs.Count);
        
        Assert.Equal(550, problem.Solve());
    }
}