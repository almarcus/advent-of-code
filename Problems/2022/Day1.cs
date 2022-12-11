namespace AOC2022;

public class Day1
{
    List<Elf> elves = new();

    public Day1(string input)
    {
        foreach (var foodList in input.Split("\n\n"))
        {
            elves.Add(new Elf(foodList));
        }
    }

    public int Solve(int numberOfElvesToCheck)
    {
        return elves.OrderByDescending(x => x.TotalCalories).Take(numberOfElvesToCheck).Sum(x => x.TotalCalories);
    }

    class Elf
    {
        List<int> foodCalories = new();

        public int TotalCalories => foodCalories.Sum();

        public Elf(string foodCarried)
        {
            foodCalories = foodCarried.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();
        }
    }
}

