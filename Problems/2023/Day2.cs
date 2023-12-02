namespace AOC2023;

public class Day2
{
    public List<Game> Games { get; set; } = new List<Game>();

    public Day2(string input)
    {
        foreach (var line in input.Split(Environment.NewLine))
        {
            var gameInfo = line.Split(":");

            var game = new Game()
            {
                Number = int.Parse(gameInfo[0].Substring(5)) // "Game 1" -> 1
            };

            foreach (var gameSetInfo in gameInfo[1].Split(";"))
            {
                var gameSet = new GameSet();
                foreach (var cubesInfo in gameSetInfo.Split(","))
                {
                    foreach (var cubeInfo in cubesInfo.Split(" "))
                    {
                        var cubes = new Cubes()
                        {
                            Number = int.Parse(cubeInfo[0].ToString()),
                            CubeColor = cubeInfo[1].ToString() switch
                            {
                                "blue" => Cubes.Color.Blue,
                                "red" => Cubes.Color.Red,
                                "green" => Cubes.Color.Green,
                                _ => throw new Exception("Invalid color")
                            }
                        };
                    }
                }

                game.GameSets.Add(gameSet);
            }
        }
    }

    public int Solve(List<Cubes> cubes)
    {
        return Games.Where(g => g.Test(cubes)).Sum(g => g.Number);
    }

    public class Game
    {
        public int Number { get; set; }
        public List<GameSet> GameSets { get; set; }

        public Game()
        {
        }

        public bool Test(List<Cubes> cubes)
        {
            foreach (var gameSet in GameSets)
            {
                foreach (var cube in gameSet.Cubes)
                {
                    var matchingTestCube = cubes.FirstOrDefault(c => c.CubeColor == cube.CubeColor);
                    if (matchingTestCube.Number < cube.Number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    public class GameSet
    {
        public List<Cubes> Cubes { get; set; } = new List<Cubes>();
        public GameSet()
        {
        }
    }

    public class Cubes
    {
        public enum Color
        {
            Blue,
            Red,
            Green,
        }

        public int Number { get; set; }

        public Color CubeColor { get; set; }

        public Cubes(Color color, int number)
        {
            CubeColor = color;
            Number = number;
        }

        public Cubes()
        {
        }
    }
}
