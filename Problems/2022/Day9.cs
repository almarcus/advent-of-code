using System.Drawing;
using System.Numerics;
using Utilities;

namespace AOC2022;

public class Day9
{
    List<Direction> movements = new();

    List<Rope> ropeHistory = new List<Rope>(){ new Rope()};

    Rope rope = new();
    
    public class Rope : ICloneable
    {
        public Point Head = new Point(0,0);
        public Point Tail = new(0,0);

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Move(Point movementVector)
        {
            Head.Offset(movementVector);

            if(Head.DistanceTo(Tail) > Math.Sqrt(2))
            {
                Point tailMovement = new();
                // tailMovement = new Point(Math.MaxMagnitude(Head.X - Tail.X), (Head.Y - Tail.Y));
                if (Head.X > Tail.X) tailMovement.Offset(MovementVector(Direction.R));
                else if (Head.X < Tail.X) tailMovement.Offset(MovementVector(Direction.L));

                if (Head.Y > Tail.Y) tailMovement.Offset(MovementVector(Direction.U));
                else if (Head.Y < Tail.Y) tailMovement.Offset(MovementVector(Direction.D));                
                
                Tail.Offset(tailMovement);
            }
        }
    }
    enum Direction
    {
        U,
        D,
        L,
        R
    }

    static Point MovementVector(Direction direction) => direction switch
    {
        Direction.U => new Point(0,1),
        Direction.D => new Point(0,-1),
        Direction.L => new Point(-1,0),
        Direction.R => new Point(1,0)
    };

    public Day9(string input)
    {
        foreach (var row in input.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var movement = row.Split(' ');
            Direction direction = (Direction)Enum.Parse(typeof(Direction), movement[0]);
            int num = int.Parse(movement[1]);
            movements.AddRange(Enumerable.Repeat(direction, num));
        }
    }

    private void PerformMovements()
    {
        foreach(var movement in movements)
        {
            rope.Move(MovementVector(movement));
            ropeHistory.Add((Rope)rope.Clone());
        }
    }

    public int Solve()
    {
        PerformMovements();
        return ropeHistory.Select(x => x.Tail).Distinct().Count();
    }
}