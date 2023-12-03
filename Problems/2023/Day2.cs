using System.Text.RegularExpressions;

namespace AOC2023;

public class Day2
{
    List<Game> Games { get; set; } = new List<Game>();

    public Day2(string input)
    {
        foreach (var game in input.Split("\n"))
        {
            Games.Add(new Game(game));
        }
    }

    public int Solve1(int testBlue, int testGreen, int testRed) => Games.Where(g => g.IsPossible(testBlue, testGreen, testRed)).Sum(g => g.Number);
    public int Solve2() => Games.Sum(g => g.Power);
    public class Game
    {
        public int Number { get; set; }
        public List<GameSet> GameSets { get; set; } = new List<GameSet>();

        public bool IsPossible(int testBlue, int testGreen, int testRed) => GameSets.All(gs => gs.IsPossible(testBlue, testGreen, testRed));

        public int MinBlue => GameSets.Max(gs => gs.BlueCubes);
        public int MinGreen => GameSets.Max(gs => gs.GreenCubes);
        public int MinRed => GameSets.Max(gs => gs.RedCubes);

        public int Power => MinBlue * MinGreen * MinRed;

        public Game(string input)
        {
            var gameMatch = Regex.Match(input, @"Game (\d+): (.*)");
            Number = int.Parse(gameMatch.Groups[1].Value);
            var gameSets = gameMatch.Groups[2].Value.Split(';');
            foreach (var gameSet in gameSets)
            {
                GameSets.Add(new GameSet(gameSet));
            }
        }
    }

    public class GameSet
    {
        public int RedCubes { get; set; } = 0;
        public int GreenCubes { get; set; } = 0;
        public int BlueCubes { get; set; } = 0;

        public GameSet(string input)
        {
            var blueMatch = Regex.Match(input, @"(\d+) blue");
            var greenMatch = Regex.Match(input, @"(\d+) green");
            var redMatch = Regex.Match(input, @"(\d+) red");


            BlueCubes = blueMatch.Success ? int.Parse(blueMatch.Groups[1].Value) : 0;
            GreenCubes = greenMatch.Success ? int.Parse(greenMatch.Groups[1].Value) : 0;
            RedCubes = redMatch.Success ? int.Parse(redMatch.Groups[1].Value) : 0;
        }

        public GameSet(int blueCubes, int greenCubes, int redCubes)
        {
            GreenCubes = greenCubes;
            BlueCubes = blueCubes;
            RedCubes = redCubes;
        }

        public bool IsPossible(int testBlue, int testGreen, int testRed)
        {
            return BlueCubes <= testBlue && GreenCubes <= testGreen && RedCubes <= testRed;
        }
    }
}
