namespace AOC2019;

public class Day1
{
    public static int CalculateFuel(int mass, bool accountForFuel)
    {
        var fuelNeeded = (int)(Math.Floor(mass/3.0)-2);
        if(accountForFuel)
        {
            if(fuelNeeded > 0)
                return fuelNeeded + CalculateFuel(fuelNeeded, true);
            else
                return 0;
        }
        else
            return fuelNeeded;
    }

    public static int Solve(string input, bool accountForFuel)
    {
        List<int> masses = input.Split(Environment.NewLine).Select(int.Parse).ToList();
        return masses.Sum(x => CalculateFuel(x, accountForFuel));
    }
}
