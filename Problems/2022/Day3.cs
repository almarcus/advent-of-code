using Utilities;

namespace AOC2022;

public class Day3
{
    public class Rucksack
{

    public string Items;
    public string CompartmentA => Items[..(Items.Length / 2)];
    public string CompartmentB => Items[(Items.Length / 2)..];

    public char CommonItem => CompartmentA.ToCharArray().Intersect(CompartmentB.ToCharArray()).FirstOrDefault();

    public int Priority => CommonItem.Priority();

    public Rucksack(string input) 
    {
        Items = input;
    }

}
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

    public int SolveWithBuckets(int bucketSize)
    {
        int totalPriority = 0;

        for (int i = 0; i< Rucksacks.Count; i += bucketSize)
        {
            var groupOfRucksacks = Rucksacks.GetRange(i, bucketSize);
            List<char> intersectList = new();

            foreach (var rucksack in groupOfRucksacks)
            {
                if (intersectList.Count == 0) intersectList = rucksack.Items.ToList();
                else intersectList = intersectList.Intersect(rucksack.Items.ToCharArray()).ToList();

            }

            totalPriority += intersectList.First().Priority();

        }
        return totalPriority;

    }

}