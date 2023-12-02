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

    // [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1, (3+4+1+2+6+2), true)]
    // [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 2, (1+2+3+4+1+1+1), true)]
    // [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 3, (8+6+20+5+4+13+5+1),false)]
    // [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 4, (1+3+6+3+6+3+15+14), false)]
    // [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 5, (6+1+3+2+1+2), false)]
    
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

    public void Day2TestExamplePart1(int gameBlue, int gameGreen, int gameRed, int testBlue, int testGreen, int testRed, bool expectedIsPossible)
    {
        var gameSet = new Day2.GameSet(gameBlue, gameGreen, gameRed);
        var isPossible = gameSet.IsPossible(testBlue, testGreen, testRed);

        Assert.Equal(expectedIsPossible, isPossible);
    }

    // {
    //     List<Day2.Cubes> testCubes = new List<Day2.Cubes>()
    //     {
    //         new Day2.Cubes() { Number = 12, CubeColor = Day2.Cubes.Color.Red },
    //         new Day2.Cubes() { Number = 13, CubeColor = Day2.Cubes.Color.Green },
    //         new Day2.Cubes() { Number = 14, CubeColor = Day2.Cubes.Color.Blue },
    //     };
    //     var day2 = new Day2(input);
    //     Assert.Equal(expectedGameNumber, day2.Games[0].Number);
    //     var totalCubes = day2.Games[0].GameSets.Sum(gs => gs.Cubes.Count);
    //     Assert.Equal(expectedTotalCubes, totalCubes);
    //     Assert.Equal(gamePassesTest, day2.Games[0].Test(testCubes));
    // }

}
