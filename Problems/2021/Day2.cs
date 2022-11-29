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

    List<Movement> movements = new List<Movement>();
    int aim = 0;
    Point position = new Point();

    public Day2(List<string> input)
    {
        foreach(string movement in input)
        {
            movements.Add(new Movement(movement));
        }
    }

    private void Move(Movement movement, bool useAim)
    {
        switch (movement.Direction){
            case Directions.Down:
                if(!useAim) 
                    position.Offset(0, movement.Magnitude);
                aim += movement.Magnitude;
                break;
            case Directions.Up:
                if (!useAim) 
                    position.Offset(0, -movement.Magnitude);
                aim -= movement.Magnitude;
                break;
            case Directions.Forward:
                if (useAim)
                    position.Offset(movement.Magnitude, movement.Magnitude * aim);
                else
                    position.Offset(movement.Magnitude, 0);
                break;
        }
    }

    public int Solve(bool useAim = false)
    {
        position = new Point();
        aim = 0;
        foreach (Movement movement in movements){
            Move(movement, useAim);
        }

        return position.X * position.Y;
    }
    
}