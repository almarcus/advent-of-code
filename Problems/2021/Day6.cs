namespace AOC2021;

public class Day6
{
    List<Lanternfish> lanternFish = new();

    List<long> lanternFishGroups = new();

    public Day6(string input)
    {
        for (int i = -1; i<= 8; i++)
        {
            lanternFishGroups.Add(0);
        }
        
        foreach (var fish in input.Split(',').Select(x => new Lanternfish(Int32.Parse(x))).ToList())
        {
            lanternFishGroups[fish.cycleDay]++;
        }
    }

    private string PrintLantern => string.Join(',',lanternFish.Select(x => x.cycleDay).ToList());

    public long Solve(int days)
    {
        for (int i=1; i<=days; i++)
        {
            PassDay();
        }

        return lanternFishGroups.Sum();
    }

    private void PassDay()
    {
        long numberToAdd = lanternFishGroups[0];

        lanternFishGroups = lanternFishGroups.GetRange(1,8);
        lanternFishGroups.Add(numberToAdd);
        lanternFishGroups[6] += numberToAdd;
    }
}

public class Lanternfish
{
    public int cycleDay;

    public Lanternfish(int cycleDay=8)
    {
        this.cycleDay = cycleDay;
    }

}