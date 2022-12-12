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

        Assert.Equal(2, problem.Solve(false));
        Assert.Equal(4, problem.Solve(true));
    }

    [Fact]
    public void Day4Solution()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day4.txt");

        var problem = new Day4(input);

        Assert.Equal(1000, problem.ElfPairs.Count);
        
        Assert.Equal(550, problem.Solve(false));
        Assert.Equal(931, problem.Solve(true));
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb",7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz",5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg",6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg",10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw",11)]
    public void Day6Example(string input, int expectedResult)
    {
        Assert.Equal(expectedResult, Day6.Solve(input, 4));
    }

    [Fact]
    public void Day6Solution()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day6.txt");

        Assert.Equal(1833, Day6.Solve(input, 4));
        Assert.Equal(3425, Day6.Solve(input, 14));
    }

    [Fact]
    public void Day8Example()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day8Example.txt");

        var problem = new Day8(input);

        Assert.Equal(21, problem.CalculateVisibleTrees());
        Assert.Equal(8, problem.CalculateScenicScore());

    }

    [Fact]
    public void Day8Solution()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day8.txt");

        var problem = new Day8(input);

        Assert.Equal(1705, problem.CalculateVisibleTrees());
        Assert.Equal(371200, problem.CalculateScenicScore());
    }    

    [Theory]
    [InlineData(2,13)]
    [InlineData(10,1)]
    public void Day9Example1(int knots, int expectedResult)
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day9Example1.txt");

        var problem = new Day9(input, knots);

        Assert.Equal(expectedResult,problem.Solve());
    }

    [Fact]
    public void Day9Example2()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day9Example2.txt");

        var problem = new Day9(input, 10);

        Assert.Equal(36, problem.Solve());
    }

    [Fact]
    public void Day9aSolution()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day9.txt");

        var problem = new Day9(input, 2);

        Assert.Equal(6311,problem.Solve());
    }

    [Fact]
    public void Day9bSolution()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day9.txt");

        var problem = new Day9(input, 10);

        
        Assert.Equal(2482,problem.Solve());
    }

    [Theory]
    [InlineData(1,1)]
    [InlineData(2,1)]
    [InlineData(3,4)]
    [InlineData(4,4)]
    [InlineData(5,-1)]
    public void Day10Example1(int cyclesToRun, int expectedXValue)
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day10Example1.txt");

        var problem = new Day10(input);

        Assert.Equal(expectedXValue, problem.CalculateXValue(cyclesToRun));
    }

    [Theory]
    [InlineData(20,420)]
    [InlineData(60,1140)]
    [InlineData(100,1800)]
    [InlineData(140,2940)]
    [InlineData(180,2880)]
    [InlineData(220,3960)]
    public void Day10Example2(int cycle, int expectedSignalStrength)
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day10Example2.txt");

        var problem = new Day10(input);

        Assert.Equal(expectedSignalStrength, problem.CalculateSignalStrength(cycle));

        Assert.Equal(13140, problem.Solve());
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(20, true)]
    [InlineData(30, false)]
    [InlineData(40, false)]
    [InlineData(50, false)]
    [InlineData(60, true)]
    [InlineData(100, true)]
    [InlineData(140, true)]
    [InlineData(180, true)]
    [InlineData(220, true)]
    public void Day10CheckSpecialCycle(int cycle, bool expectedSpecialIndicator)
    {
        Assert.Equal(expectedSpecialIndicator, Day10.IsSpecialCycle(cycle));
    }

    [Fact]
    public void Day10Solution()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day10.txt");

        var problem = new Day10(input);

        Assert.Equal(14820, problem.Solve());

    }
    
    
}