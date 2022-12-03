using Utilities;

namespace AOC2022;


public class Rucksack
{
    public string CompartmentA;
    public string CompartmentB;

    public char CommonItem => CompartmentA.ToCharArray().Intersect(CompartmentB.ToCharArray()).FirstOrDefault();

    public int Priority => CommonItem.Priority();

    public Rucksack(string input) 
    {
        CompartmentA = input[..(input.Length / 2)];
        CompartmentB = input[(input.Length / 2)..];
    }

}

public class Day3
{
    List<Rucksack> Rucksacks = new();

    public Day3(string input)
    {
        foreach (var rucksack in input.Split("\n")) 
            Rucksacks.Add(new Rucksack(rucksack));
    }

    public int Solve()
    {
        return Rucksacks.Sum(x => x.Priority);
    }

}