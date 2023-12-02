namespace AOC2023;

public class Day2
{
    public class Game
    {
        public int Number { get; set; }
        public List<GameSet> GameSets { get; set; } = new List<GameSet>();

        public bool IsPossible(int testBlue, int testGreen, int testRed) => GameSets.All(gs => gs.IsPossible(testBlue, testGreen, testRed));

        public Game()
        {
        }
    }
    
    public class GameSet
    {
        public int RedCubes { get; set; } = 0;
        public int GreenCubes { get; set; } = 0;
        public int BlueCubes { get; set; } = 0;

        public GameSet(string input)
        {

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
