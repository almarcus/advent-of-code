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
        var lines = Utility.ReadLinesFromFile(@"2021/Inputs/Day1.txt");
        var problem = new AOC2021.Day1(lines);
        Assert.Equal(1482, problem.Solve());
    }

    [Fact]
    public void Day1bSolution()
    {
        var lines = Utility.ReadLinesFromFile(@"2021/Inputs/Day1.txt");
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

    [Fact]
    public void Day4aExample1()
    {
string input = 
@"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
8  2 23  4 24
21  9 14 16  7
6 10  3 18  5
1 12 20 15 19

3 15  0  2 22
9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
2  0 12  3  7";

    Day4 problem = new Day4(input);

    Assert.Equal(3,problem.Boards.Count);
    Assert.Equal(4512, problem.Solve());
    }

    [Fact]
    public void Day4aCheckCorrectNumberOfBoards()
    {
        string input = Utility.ReadFile(@"2021/Inputs/Day4.txt");

        Day4 problem = new Day4(input);

        Assert.Equal(100,problem.Boards.Count);
    }

    [Fact]
    public void Day4aSolution()
    {
        string input = Utility.ReadFile(@"2021/Inputs/Day4.txt");

        Day4 problem = new Day4(input);

        Assert.Equal(33462, problem.Solve(true));
    }

    [Fact]
    public void Day4bSolution()
    {
        string input = Utility.ReadFile(@"2021/Inputs/Day4.txt");

        Day4 problem = new Day4(input);

        Assert.Equal(30070, problem.Solve(false));
    }

    [Fact]
    public void Day5aExample()
    {
        List<string> input = new()
        { 
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };

        var problem = new Day5(input);

        Assert.Equal(5,problem.Solve(true));
        Assert.Equal(12,problem.Solve(false));

    }

    [Fact]
    public void Day5aSolution()
    {
        List<string> input = Utility.ReadLinesFromFile(@"2021/Inputs/Day5.txt");


        var problem = new Day5(input);

        Assert.Equal(5197,problem.Solve(true));
        Assert.Equal(18605,problem.Solve(false));
    }

    [Theory]
    [InlineData(0, 5)]
    [InlineData(1, 5)]
    [InlineData(2, 6)]
    [InlineData(3, 7)]
    [InlineData(4,9)]
    [InlineData(5,10)]
    [InlineData(6,10)]
    [InlineData(7,10)]
    [InlineData(8,10)]
    [InlineData(9,11)]
    [InlineData(18, 26)]
    [InlineData(80, 5934)]
    public void Day6aExample(int days, int expectedFish)
    {
        string input = "3,4,3,1,2";

        var problem = new Day6(input);

        Assert.Equal(expectedFish, problem.Solve(days));

    }

    [Theory]
    [InlineData(80, 390923)]
    [InlineData(256, 1749945484935)]
    public void Day6aSolution(int days, long expectedFish)
    {
        string input = Utility.ReadFile(@"2021/Inputs/Day6.txt");

        var problem = new Day6(input);

        Assert.Equal(expectedFish,problem.Solve(days));
    }

    [Fact]
    public void Day7aExample()
    {
        string input = "16,1,2,0,4,2,7,1,2,14";

        var problem = new Day7(input);

        Assert.Equal(37, problem.Solve(false));
        Assert.Equal(168, problem.Solve(true));
    }

    [Fact]
    public void Day7Solution()
    {
        string input = Utility.ReadFile(@"2021/Inputs/Day7.txt");

        var problem = new Day7(input);

        Assert.Equal(356922, problem.Solve(false));
        Assert.Equal(100347031, problem.Solve(true));
    }    

    [Theory]
    [InlineData(16,5,66)]
    [InlineData(1,5,10)]
    [InlineData(2,5,6)]
    [InlineData(0,5,15)]
    [InlineData(4,5,1)]
    [InlineData(7,5,3)]
    [InlineData(14,5,45)]
    [InlineData(1,4,6)]
    public void CheckCostToMoveMultiplier(int start, int end, int expectedFuel)
    {
        Assert.Equal(expectedFuel, Day7.CostToMove(start,end,true));
    }
}