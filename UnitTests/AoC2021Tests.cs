using AOC2021;
using Utilities;

namespace UnitTests;

public class AoC2021Tests
{
    #region Day1
    [Fact]
    public void Day1Part1Example1()
    {
        List<int> inputs = new List<int>{
                                        199,
                                        200,
                                        208,
                                        210,
                                        200,
                                        207,
                                        240,
                                        269,
                                        260,
                                        263
                                        };

        var problem = new Day1(inputs);
        Assert.Equal(7,problem.Solve());
    }

    [Fact]
    public void Day1Part1Example2()
    {
        List<int> inputs = new List<int>{
                                        1,
                                        2,
                                        3,
                                        4,
                                        5};

        var problem = new Day1(inputs);
        Assert.Equal(4,problem.Solve());    
    }

    [Fact]
    public void Day1Part2Example1()
    {
        List<int> inputs = new List<int>{
                                        199,
                                        200,
                                        208,
                                        210,
                                        200,
                                        207,
                                        240,
                                        269,
                                        260,
                                        263
                                        };
        var problem = new Day1(inputs);
        Assert.Equal(5, problem.Solve(3));
    }

    [Fact]
    public void Day1aSolution()
    {
        var lines = Utility.ReadLinesFromFile(@"2021/Inputs/Day1a.txt");
        var problem = new AOC2021.Day1(lines);
        Assert.Equal(1482, problem.Solve());
    }

    [Fact]
    public void Day1bSolution()
    {
        var lines = Utility.ReadLinesFromFile(@"2021/Inputs/Day1b.txt");
        var problem = new AOC2021.Day1(lines);
        Assert.Equal(1518, problem.Solve(3));
    }

    #endregion

    #region Day2
    [Fact]
    public void Day2aExample1()
    {
        var lines = Utility.ReadLinesFromFile(@"2021/Inputs/Day2.txt");

        Day2 problem = new Day2(lines);
        Assert.Equal(1746616,problem.Solve());
    }

    [Fact]
    public void Day2aSolution()
    {
        List<string> input = new List<string>
                                            {
                                            "forward 5",
                                            "down 5",
                                            "forward 8",
                                            "up 3",
                                            "down 8",
                                            "forward 2"
                                            };
        
        Day2 problem = new Day2(input);
        Assert.Equal(150,problem.Solve());
    }

    [Fact]
    public void Day2bExample1()
    {
        List<string> input = new List<string>
                                            {
                                            "forward 5",
                                            "down 5",
                                            "forward 8",
                                            "up 3",
                                            "down 8",
                                            "forward 2"
                                            };
        
        Day2 problem = new Day2(input);
        Assert.Equal(900,problem.Solve(true));
    }


    [Fact]
    public void Day2bSolution()
    {
        var lines = Utility.ReadLinesFromFile(@"2021/Inputs/Day2.txt");

        Day2 problem = new Day2(lines);
        Assert.Equal(1741971043,problem.Solve(true));
    }
    #endregion

    #region Day3
    
    [Theory]
    [InlineData("00000","11111")]
    [InlineData("11111","00000")]
    [InlineData("0","1")]
    [InlineData("10101","01010")]
    public void FlippedBitsTests(string inputBinary, string expectedFlippedBinary)
    {
        Assert.Equal(expectedFlippedBinary, Day3.FlipBits(inputBinary));
    }

    [Fact]
    public void MostCommonCharacterTest()
    {
        List<string> input = new List<string>
        {
            "0",
            "1"
        };

        Assert.Equal('1', Day3.GetMostCommonCharacterInPosition(input,0));
    }

    [Fact]
    public void Day3Example1()
    {
        List<string> input = new List<string>
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        Day3 problem = new Day3(input);

        Assert.Equal("10110",problem.gammaRateBinary);
        Assert.Equal("01001",problem.epsilonRateBinary);
        Assert.Equal(22,problem.gammaRate);
        Assert.Equal(9,problem.epsilonRate);
        Assert.Equal(198, problem.Solve().powerConsumption);
        Assert.Equal("10111", problem.oxygenGeneratorBinary);
        Assert.Equal("01010", problem.co2ScrubberBinary);
        Assert.Equal(23, problem.oxygenGeneratorRating);
        Assert.Equal(10, problem.co2ScrubberRating);
        Assert.Equal(230, problem.Solve().lifeSupportRating);
    }

    [Fact]
    public void Day3aSolution(){
        var lines = Utility.ReadLinesFromFile(@"2021/Inputs/Day3.txt");

        Day3 problem = new Day3(lines);

        Assert.Equal(3847100, problem.Solve().powerConsumption);
    }

    [Fact]
    public void Day3bSolution(){
        var lines = Utility.ReadLinesFromFile(@"2021/Inputs/Day3.txt");

        Day3 problem = new Day3(lines);

        Assert.Equal(4105235, problem.Solve().lifeSupportRating);
    }
    
    #endregion
}