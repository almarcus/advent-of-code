namespace AOC2022;

public enum Play
{
    Rock = 1,
    Paper,
    Scissors
}

public enum Result
{
    Loss = 0,
    Draw = 3,
    Win = 6
}


public class Player
{
    public Play Choice;
    public int Score;

    public Player() {}

    public Result DetermineResults(Play opponentPlay)
    {
        if(opponentPlay == Choice) return Result.Draw;
        else if (opponentPlay == Play.Rock)
        {
            if (Choice == Play.Paper) return Result.Win;
            else return Result.Loss;
        }
        else if (opponentPlay == Play.Paper)
        {
            if (Choice == Play.Scissors) return Result.Win;
            else return Result.Loss;
        }
        else if (opponentPlay == Play.Scissors)
        {
            if (Choice == Play.Rock) return Result.Win;
            else return Result.Loss;
        }
        else throw new InvalidOperationException();
    }
}

public class RockPaperScissorsGame
{
    public Player PlayerA;
    public Player PlayerB;

    public static Play WinsAgainst(Play input) =>
    input switch
    {
        Play.Rock => Play.Scissors,
        Play.Paper => Play.Rock,
        Play.Scissors => Play.Paper,
        _ => throw new NotImplementedException()
    };

    public static Play LosesAgainst(Play input) =>
    input switch
    {
        Play.Rock => Play.Paper,
        Play.Paper => Play.Scissors,
        Play.Scissors => Play.Rock,
        _ => throw new NotImplementedException()
    };

    static Play InputToPlay(string input) =>
        input switch
        {
            "X" or "A" => Play.Rock,
            "Y" or "B" => Play.Paper,
            "Z" or "C" => Play.Scissors,
            _ => throw new NotImplementedException()
        };

    static Result InputToResult(string input) =>
        input switch
        {
            "X" => Result.Loss,
            "Y" => Result.Draw,
            "Z" => Result.Win,
            _ => throw new NotImplementedException()
        };


    public RockPaperScissorsGame(string playerA, string playerB)
    {
        PlayerA = new Player() {Choice = InputToPlay(playerA)};
        PlayerB = new Player() {Choice = InputToPlay(playerB)};
    }

    public RockPaperScissorsGame(string input, bool secondInputIsChoice=true)
    {
        string[] choices = input.Split(' ');
        Play playerAChoice;
        PlayerB = new Player() {Choice = InputToPlay(choices[0])};
        if (secondInputIsChoice) playerAChoice = InputToPlay(choices[1]);
        else
        {
            playerAChoice = InputToResult(choices[1]) switch
            {
                Result.Draw => PlayerB.Choice,
                Result.Win => LosesAgainst(PlayerB.Choice),
                Result.Loss => WinsAgainst(PlayerB.Choice),
                _ => throw new NotImplementedException()
            };
        }

        PlayerA = new Player() {Choice = playerAChoice};
    }

    public void PlayGame()
    {
        PlayerA.Score = (int)PlayerA.DetermineResults(PlayerB.Choice) + (int)PlayerA.Choice;
        PlayerB.Score = (int)PlayerB.DetermineResults(PlayerA.Choice) + (int)PlayerB.Choice;
    }
}

public class Day2
{
    List<RockPaperScissorsGame> Games = new();

    public Day2(string input, bool secondInputIsChoice=true)
    {
        foreach (string game in input.Split("\n"))
        {
            Games.Add(new RockPaperScissorsGame(game, secondInputIsChoice));
        }
    }

    public int Solve()
    {
        foreach (var game in Games) { game.PlayGame();}

        return Games.Select(x => x.PlayerA.Score).Sum();
    }

}
