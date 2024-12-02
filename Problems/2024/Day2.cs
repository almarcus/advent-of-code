namespace AOC2024;

public class Day2(string input)
{
    private Data Puzzle = new Data(input);
    
    public int SolvePart1() => Puzzle.Reports.Count(r => r.IsSafe);

    public class Data(string input)
    {
        public List<Report> Reports { get; } = input.Split(Environment.NewLine).Select(x => new Report(x)).ToList();
    }

    public class Report(string line)
    {
        public List<int> Levels { get; set; } = line.Split(' ').Select(int.Parse).ToList();

        public List<int> LevelSteps
        {
            get
            {
                List<int> steps = new List<int>();
                var lastLevel = Levels.First();
                for (int i = 1; i < Levels.Count; i++)
                {
                    var diff = lastLevel - Levels[i];
                    steps.Add(diff);
                    lastLevel = Levels[i];
                }
                
                return steps;
            }
        }
        public int MaxLevelDifference => LevelSteps.Max(x => Math.Abs(x));
        public int MinLevelDifference => LevelSteps.Min(x => Math.Abs(x));

        public bool AllIncreasingOrDecreasing => LevelSteps.TrueForAll(x => x < 0) || LevelSteps.TrueForAll(x => x > 0);

        public bool IsSafe => AllIncreasingOrDecreasing && MaxLevelDifference <= 3 && MinLevelDifference >= 1;

    }
}
