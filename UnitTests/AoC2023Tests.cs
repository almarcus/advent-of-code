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
}