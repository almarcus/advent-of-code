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
    [InlineData("123", "123")]
    [InlineData("aaa", "")]
    [InlineData("1a2b3c", "123")]
    [InlineData("one", "")]
    [InlineData("", "")]
    [InlineData("a1b", "1")]
    [InlineData("a1b2c3", "123")]
    [InlineData("one1two2three3", "123")]
    [InlineData("1abc2", "12")]
    [InlineData("pqr3stu8vwx", "38")]
    [InlineData("a1b2c3d4e5f", "12345")]
    [InlineData("treb7uchet", "7")]
    [InlineData("two1nine", "1")]
    [InlineData("eightwothree", "")]
    [InlineData("abcone2threexyz","2")]
    [InlineData("xtwone3four", "3")]
    [InlineData("4nineeightseven2", "42")]
    [InlineData("zoneight234", "234")]
    [InlineData("7pqrstsixteen", "7")]
    public void Day1TestParseInputNoTranslation(string input, string expectedConcatenatedNumbers)
    {
        var result = Day1.ParseInput(input, false);
        Assert.Equal(expectedConcatenatedNumbers, string.Join("", result));
    }

    [Theory]
    [InlineData("123", "123")]
    [InlineData("aaa", "")]
    [InlineData("1a2b3c", "123")]
    [InlineData("one", "1")]
    [InlineData("", "")]
    [InlineData("a1b", "1")]
    [InlineData("a1b2c3", "123")]
    [InlineData("one1two2three3", "112233")]
    [InlineData("1abc2", "12")]
    [InlineData("pqr3stu8vwx", "38")]
    [InlineData("a1b2c3d4e5f", "12345")]
    [InlineData("treb7uchet", "7")]
    [InlineData("two1nine", "219")]
    [InlineData("eightwothree", "823")]
    [InlineData("abcone2threexyz","123")]
    [InlineData("xtwone3four", "2134")]
    [InlineData("4nineeightseven2", "49872")]
    [InlineData("zoneight234", "18234")]
    [InlineData("7pqrstsixteen", "76")]
    public void Day1TestParseInputWithTranslation(string input, string expectedConcatenatedNumbers)
    {
        var result = Day1.ParseInput(input, true);
        Assert.Equal(expectedConcatenatedNumbers, string.Join("", result));
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

    [Theory]
    [InlineData(1, 0, 0, 0, 0, 0, false)]
    [InlineData(0, 1, 0, 0, 0, 0, false)]
    [InlineData(0, 0, 1, 0, 0, 0, false)]
    [InlineData(0, 0, 0, 1, 0, 0, true)]
    [InlineData(0, 0, 0, 0, 1, 0, true)]
    [InlineData(0, 0, 0, 0, 0, 1, true)]
    [InlineData(0, 0, 0, 1, 1, 1, true)]
    [InlineData(1, 1, 1, 0, 0, 0, false)]
    [InlineData(3, 0, 4, 14, 13, 12, true)]
    public void Day2TestSetPossibilitiesPart1(int gameBlue, int gameGreen, int gameRed, int testBlue, int testGreen, int testRed, bool expectedIsPossible)
    {
        var gameSet = new Day2.GameSet(gameBlue, gameGreen, gameRed);
        var isPossible = gameSet.IsPossible(testBlue, testGreen, testRed);

        Assert.Equal(expectedIsPossible, isPossible);
    }

    [Theory]
    [InlineData("3 blue, 4 red", 3, 0, 4)]
    [InlineData("1 red, 2 green, 6 blue", 6, 2, 1)]
    [InlineData("2 green", 0, 2, 0)]
    [InlineData("1 blue, 2 green", 1, 2, 0)]
    [InlineData("3 green, 4 blue, 1 red", 4, 3, 1)]
    [InlineData("1 green, 1 blue", 1, 1, 0)]
    [InlineData("8 green, 6 blue, 20 red", 6, 8, 20)]
    [InlineData("5 blue, 4 red, 13 green", 5, 13, 4)]
    [InlineData("5 green, 1 red", 0, 5, 1)]
    [InlineData("1 green, 3 red, 6 blue", 6, 1, 3)]
    [InlineData("3 green, 6 red", 0, 3, 6)]
    [InlineData("3 green, 15 blue, 14 red", 15, 3, 14)]
    [InlineData("6 red, 1 blue, 3 green", 1, 3, 6)]
    [InlineData("2 blue, 1 red, 2 green", 2, 2, 1)]
    public void Day2TestSetParsing(string input, int expectedBlue, int expectedGreen, int expectedRed)
    {
        var gameSet = new Day2.GameSet(input);
        Assert.Equal(expectedBlue, gameSet.BlueCubes);
        Assert.Equal(expectedGreen, gameSet.GreenCubes);
        Assert.Equal(expectedRed, gameSet.RedCubes);
    }

    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1, 3, (3+4+1+2+6+2))]
    [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 2, 3, (1+2+3+4+1+1+1))]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 3, 3, (8+6+20+5+4+13+5+1))]
    [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 4, 3, (1+3+6+3+6+3+15+14))]
    [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 5, 2, (6+1+3+2+1+2))]
    [InlineData("Game 6: 1 red, 2 green, 6 blue; 2 green", 6, 2, (1+2+6+2))]
    [InlineData("Game 7: 3 green, 4 blue, 1 red; 1 green, 1 blue", 7, 2, (3+4+1+1+1))]
    [InlineData("Game 8: 5 blue, 4 red, 13 green; 5 green, 1 red", 8, 2, (5+4+13+5+1))]
    [InlineData("Game 9: 3 green, 6 red; 3 green, 15 blue, 14 red", 9, 2, (3+6+3+15+14))]
    [InlineData("Game 10: 2 blue, 1 red, 2 green", 10, 1, (2+1+2))]
    public void Day2TestGameParsing(string input, int expectedNumber, int expectedSets, int expectedTotalCubes)
    {
        var game = new Day2.Game(input);
        Assert.Equal(expectedNumber, game.Number);
        Assert.Equal(expectedSets, game.GameSets.Count);
        Assert.Equal(expectedTotalCubes, game.GameSets.Sum(gs => gs.BlueCubes + gs.GreenCubes + gs.RedCubes));
    }

    [Theory]
    [InlineData(@"2023/Inputs/Day2Example.txt", 14, 13, 12, 8, 2286)] // Part 1
    [InlineData(@"2023/Inputs/Day2.txt", 14, 13, 12, 2593, 54699)] // Part 1
    public void Day2Solutions(string filename, int testBlue, int testGreen, int testRed, int expectedPart1Result, int expectedPart2Result)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day2(input);
        Assert.Equal(expectedPart1Result, problem.Solve1(testBlue, testGreen, testRed));
        Assert.Equal(expectedPart2Result, problem.Solve2());
    }

    [Theory]
    [InlineData(@"2023/Inputs/Day3Example.txt", 4361)]
    [InlineData(@"2023/Inputs/Day3.txt", 4361)]
    public void Day3Solutions(string filename, int expectedSolution)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day3(input);
        Assert.Equal(expectedSolution, problem.Solve());
    }

    [Theory]
    [InlineData("1!.2", 1)]
    [InlineData("1!2", 3)]
    [InlineData("1!2!3", 6)]
    [InlineData("1@", 1)]
    [InlineData("1#", 1)]
    [InlineData("1$", 1)]
    [InlineData("1%", 1)]
    [InlineData("1^", 1)]
    [InlineData("1&", 1)]
    [InlineData("1*", 1)]
    [InlineData("1(", 1)]
    [InlineData("1)", 1)]
    [InlineData("1_", 1)]
    [InlineData("1+", 1)]
    [InlineData("1=", 1)]
    [InlineData("1{", 1)]
    [InlineData("1}", 1)]
    [InlineData("1[", 1)]
    [InlineData("1]", 1)]
    [InlineData("1|", 1)]
    [InlineData("1:", 1)]
    [InlineData("1;", 1)]
    [InlineData("1'", 1)]
    [InlineData("1\"", 1)]
    [InlineData("1<", 1)]
    [InlineData("1>", 1)]
    [InlineData("1?", 1)]
    [InlineData("1/", 1)]
    [InlineData("1\\", 1)]
    [InlineData("1~", 1)]
    [InlineData("1`", 1)]
    [InlineData("1-", 1)]
    [InlineData("1.", 0)]
    [InlineData("1,", 1)]
    [InlineData(
@"........936..672.........846.922........359...332......582..856........................579..93......674..740.....243.156....................
...........%.........4=...*...*........*.......*......#....................806..481.........................*.......*.........900......$564.
.............520........624.965....143..405.....960.............273...651...*....*.........554....139@.....38...*.........58..*...392.......
", (936+846+922+359+332+582+740+243+156+4+806+481+900+564+624+965+405+960+139+38)
        )]
    

    public void Day3Examples(string input, int expectedSolution)
    {
        var problem = new Day3(input);
        Assert.Equal(expectedSolution, problem.Solve());
    }

}
