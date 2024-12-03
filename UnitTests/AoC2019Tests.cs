namespace UnitTests;
using AOC2019;
using Utilities;

public class AoC2019Tests
{

    private readonly ITestOutputHelper output;

    public AoC2019Tests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [InlineData(12, 2)]
    [InlineData(14, 2)]
    [InlineData(1969, 654)]
    [InlineData(100756, 33583)]
    public void FuelCalculationByMassTests(int mass, int expectedFuel)
    {
        Assert.Equal(expectedFuel, Day1.CalculateFuel(mass, false));
    }

    [Theory]
    [InlineData(12, 2)]
    [InlineData(1969, 966)]
    [InlineData(100756, 50346)]
    public void FuelCalculationByMassAccountForFuelTests(int mass, int expectedFuel)
    {
        Assert.Equal(expectedFuel, Day1.CalculateFuel(mass, true));
    }

    [Theory]
    [InlineData(@"2019/Inputs/Day1.txt", false, 3426455)] // Part 1
    [InlineData(@"2019/Inputs/Day1.txt", true, 5136807)] // Part 1
    public void Day1Solutions(string filename, bool accountForFuel, int expectedResult)
    {
        var input = Utility.ReadFile(filename);
        var requiredFuel = Day1.Solve(input, accountForFuel);

        Assert.Equal(expectedResult, requiredFuel);
    }
}