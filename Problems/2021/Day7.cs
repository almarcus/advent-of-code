namespace AOC2021;

public class Day7
{
    List<int> initialPositions = new();

    Dictionary<int,int> positionAndCost = new();

    public Day7(string input)
    {
        initialPositions = input.Split(',').Select(x => int.Parse(x)).ToList();
    }

    public int Solve()
    {
        for (int potentialFinal = initialPositions.Min(); potentialFinal<=initialPositions.Max(); potentialFinal++)
        {
            positionAndCost[potentialFinal] = initialPositions.Select(x => Math.Abs(x-potentialFinal)).Sum();
        }

        return positionAndCost.OrderBy(x => x.Value).First().Value;
    }
}