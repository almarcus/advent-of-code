namespace AOC2023;

public class Day2
{
    public List<Game> Games { get; set; } = new List<Game>();
    
    public Day1(string input)
    {
        foreach (var line in input.Split(Environment.NewLine))
        {
            var game = new Game();
            var gameInfo = line.Split(":");
            var game.Number = int.Parse(gameInfo[0].Substring(5)); // "Game 1" -> 1
            foreach(var gameSet in gameInfo[1].Split(";"))
            {
                var gameSet = new GameSet();
                foreach (var cubes in gameSet.Split(","))
                {
                    foreach (var cubeInfo in cubes.Split(" "))
                    {
                        var cube = new Cube()
                        {
                            Number = int.Parse(cubeInfo[0]),
                            Color = cubeInfo[1] switch
                            {
                                "blue" => Cubes.Color.Blue,
                                "red" => Cubes.Color.Red,
                                "green" => Cubes.Color.Green,
                                _ => throw new Exception("Invalid color")
                            }
                        }
                    }
                }
                
                game.GameSets.Add(gameSet);
            }
        }
    }

    public int Solve()
    {

    }

    class Game
    {
        public int Number { get; set; }
        public List<GameSet> GameSets { get; set; }

        public Game()
        {
        }
    }

    class GameSet
    {
        public List<Cube> Cubes { get; set; } = new List<Cube>();
        public GameSet()
        {
        }
    }

    class Cubes
    {
        public enum Color
        {
            Blue = "blue",
            Red = "red",
            Green = "green",
        }

        public int Number { get; set; }

        public Color Color { get; set; }

        public Cube(Color color, int number)
        {
            Color = color;
            Number = number;
        }
    }
}
