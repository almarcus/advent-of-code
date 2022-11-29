using Utilities;
namespace UnitTests;

public class UtilityTests
{
    [Theory]
    [InlineData("2022.1", 2022,1)]
    [InlineData("2022.0", 2022,0)]
    [InlineData("1.10", 1,10)]
    [InlineData("01.02", 1,2)]
    public void TestValidAoCDates(string input, int expected_year, int expected_day)
    {
        (int test_year, int test_day) = Utility.ParseAoCDate(input);

        Assert.Equal(expected_year, test_year);
        Assert.Equal(expected_day, test_day);
    }

    [Theory]
    [InlineData("")]
    [InlineData("0")]
    [InlineData("0.0.")]
    [InlineData("0.0.0")]
    [InlineData(".0.0.0")]
    [InlineData(".")]
    [InlineData(".0")]
    [InlineData("0.")]
    [InlineData("a.b")]
    public void TestInvalidArgumentAoCDates(string input)
    {
        Assert.ThrowsAny<Exception>(() => Utility.ParseAoCDate(input));
    }
}