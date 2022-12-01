namespace AOC2021;

public class Day7
{
    List<int> initialPositions = new();

    Dictionary<int,int> positionAndCost = new();

    public Day7(string input)
    {
        initialPositions = input.Split(',').Select(x => int.Parse(x)).ToList();
    }

    public static int CostToMove(int start, int end, bool multiplier = true)
    {
        int steps = Math.Abs(end-start);

        return multiplier ? (steps * (steps+1) ) / 2 : steps;
    }

    public int Solve(bool multiplier)
    {
        for (int potentialFinal = initialPositions.Min(); potentialFinal<=initialPositions.Max(); potentialFinal++)
        {
            positionAndCost[potentialFinal] = initialPositions.Select(x => CostToMove(x,potentialFinal,multiplier)).Sum();
        }

        return positionAndCost.OrderBy(x => x.Value).First().Value;
    }
}