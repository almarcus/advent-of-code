using System.Drawing;
using System.Runtime.InteropServices;
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

    [Theory]
    [InlineData("(0,0)",0,0)]
    [InlineData("(-1,0)",-1,0)]
    [InlineData("(0,-1)",0,-1)]
    [InlineData("(-9,-8)",-9,-8)]
    [InlineData("(8,9)",8,9)]
    [InlineData("(01,02)",1,2)]
    [InlineData("(-01,-02)",-1,-2)]
    public void TestValidPointConversions(string pointToParse, int x, int y)
    {
        Assert.Equal(new Point(x,y), Utility.ParsePoint(pointToParse));
    }

    [Theory]
    [InlineData('A', 27)]
    [InlineData('a', 1)]
    [InlineData('Z', 52)]
    [InlineData('z', 26)]
    public void TestCustomAsciiConverter(char input, int expectedValue)
    {
        Assert.Equal(expectedValue, input.Priority());
    }

    [Theory]
    [InlineData(1,3,3)]
    [InlineData(1,1,1)]
    [InlineData(0,1,2)]
    [InlineData(-3,3,7)]
    [InlineData(-3,-1,3)]
    public void TestRangeUtility(int start, int end, int expectedElements)
    {
        var range = Utility.Range(start, end);
        
        Assert.Equal(expectedElements, range.Count());
        Assert.Equal(start, range.First());
        Assert.Equal(end, range.Last());
    }

    [Theory]
    [InlineData(0,0,0)]
    [InlineData(5,12,13)]
    [InlineData(3,4,5)]
    [InlineData(0,3,3)]
    [InlineData(5,0,5)]
    [InlineData(-1,0,1)]
    [InlineData(0,-1,1)]
    public void TestMagnitude(int x, int y, double expectedMagnitude)
    {
        var point = new Point(x,y);

        Assert.Equal(expectedMagnitude, point.Magnitude());
    }

    [Theory]
    [InlineData(0,0,0,0,0)]
    [InlineData(0,0,1,0,1)]
    [InlineData(0,0,0,2,2)]
    [InlineData(3,0,0,0,3)]
    [InlineData(0,4,0,0,4)]
    [InlineData(1,1,4,5, 5)]
    public void TestDistanceTo(int x1, int y1, int x2, int y2, double expectedDistance)
    {
        var point1 = new Point(x1,y1);
        var point2 = new Point(x2,y2);
        
        Assert.Equal(expectedDistance, point1.DistanceTo(point2));
        Assert.Equal(expectedDistance, point2.DistanceTo(point1));
    }
    
    
}