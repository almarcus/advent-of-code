namespace AOC2024;

public class Day1(string input)
{

    private (List<int> FirstColumn, List<int> SecondColumn) ParseInput(string input)
    {
        List<int> firstColumn = [];
        List<int> secondColumn = [];
        var lines =  input.Split(Environment.NewLine);
        foreach (var line in lines)
        {
            var numbers = line.Split("   ").Select(int.Parse).ToList();
            firstColumn.Add(numbers[0]);
            secondColumn.Add(numbers[1]);
        }
        
        return (firstColumn, secondColumn);
    }
    
    public int SolvePart1()
    {
        var (firstColumn, secondColumn) = ParseInput(input);

        firstColumn.Sort();
        secondColumn.Sort();

        var zipped = firstColumn.Zip(secondColumn);

        var summedDiffs = zipped.Sum(tuple => Math.Abs(tuple.First - tuple.Second));

        return summedDiffs;
    }

    public int SolvePart2()
    {
        var (firstColumn, secondColumn) = ParseInput(input);
        
        var secondColumnOccurrences = secondColumn.CountBy(x => x);
        var newSum = firstColumn.Sum(x => x * secondColumnOccurrences.FirstOrDefault(y => y.Key == x).Value);
        
        return newSum;
    }
}
