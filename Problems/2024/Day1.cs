namespace AOC2024;

public class Day1(string input)
{
    private List<int> list1 = [];
    private List<int> list2 = [];

    private void parseInput(string input)
    {
        list1 = [];
        list2 = [];
        var lines =  input.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            var numbers = line.Split("   ").Select(int.Parse).ToList();
            list1.Add(numbers[0]);
            list2.Add(numbers[1]);
        }
    }
    
    public int SolvePart1()
    {
        parseInput(input);

        list1.Sort();
        list2.Sort();

        var zipped = list1.Zip(list2);

        var summedDiffs = zipped.Sum(tuple => Math.Abs(tuple.First - tuple.Second));

        return summedDiffs;
    }

    public int SolvePart2()
    {
        parseInput(input);
        var groupedCount = list2.CountBy(x => x);
        var newSum = list1.Sum(x => x * groupedCount.FirstOrDefault(y => y.Key == x).Value);
        
        return newSum;
    }
}
