namespace AOC2024;

public class Day2(string input)
{
    private readonly Data _puzzle = new Data(input);
    
    public int SolvePart1() => _puzzle.Reports.Count(r => r.IsSafe);

    public int SolvePart2()
    {
        var safeReports = 0;
        foreach (var report in _puzzle.Reports)
        {
            if (report.IsSafe) safeReports++;
            else
            {
                for (var i = 0; i < report.Levels.Count; i++)
                {
                    var newLevels = new List<int>(report.Levels);
                    newLevels.RemoveAt(i);
                    var reportWithRemovedIndex = new Report(newLevels);
                    
                    if (!reportWithRemovedIndex.IsSafe) continue;
                    
                    safeReports++;
                    break;
                }
            }
        }

        return safeReports;
    }

    private class Data(string input)
    {
        public List<Report> Reports { get; } = input.Split(Environment.NewLine).Select(x => new Report(x)).ToList();
    }

    public class Report
    {
        public List<int> Levels { get; }

        private List<int> LevelSteps
        {
            get
            {
                var steps = new List<int>();
                var lastLevel = Levels.First();
                for (var i = 1; i < Levels.Count; i++)
                {
                    var diff = lastLevel - Levels[i];
                    steps.Add(diff);
                    lastLevel = Levels[i];
                }
                
                return steps;
            }
        }

        private int MaxLevelDifference => LevelSteps.Max(Math.Abs);
        private int MinLevelDifference => LevelSteps.Min(Math.Abs);

        private bool AllIncreasingOrDecreasing => LevelSteps.TrueForAll(x => x < 0) || LevelSteps.TrueForAll(x => x > 0);

        public bool IsSafe => AllIncreasingOrDecreasing && MaxLevelDifference <= 3 && MinLevelDifference >= 1;

        public Report(string input) => Levels = input.Split(' ').Select(int.Parse).ToList();
        public Report(List<int> levels) => Levels = levels;
    }
}
