using System.Drawing;

namespace AOC2021;

public class Day2
{
    enum Directions
    {
        Forward,
        Down,
        Up
    }
    class Movement
    {
        public int Magnitude {get;}
        public Directions Direction {get;}

        public Movement(string input)
        {
            var splitInput = input.Split(' ');
            Direction = (Directions)Enum.Parse(typeof(Directions),splitInput[0], true);
            Magnitude = Int32.Parse(splitInput[1]);
        }
    }

    List<Movement> Movements = new List<Movement>();
    int Aim = 0;
    Point position = new Point();

    public Day2(List<string> input)
    {
        foreach(string movement in input)
        {
            Movements.Add(new Movement(movement));
        }
    }

    private void Move(Movement movement)
    {
        switch (movement.Direction){
            case Directions.Forward:
                position.Offset(movement.Magnitude,0);
                break;
            case Directions.Up:
                position.Offset(0, movement.Magnitude);
                break;
            case Directions.Down:
                position.Offset(0, -movement.Magnitude);
                break;
        }
    }

    public int Solve()
    {
        foreach (Movement movement in Movements){
            Move(movement);
        }

        return Math.Abs(position.X * position.Y);
    }
    
}