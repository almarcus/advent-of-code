using System.Drawing;
using System.Numerics;
using Utilities;

namespace AOC2022;

public class Day9
{
    readonly List<Direction> movements = new();
    readonly List<Point> tailHistory = new();

    Rope rope;
    
    public class Rope : ICloneable
    {
        public Point Head => Knots.First();
        public Point Tail => Knots.Last();

        public List<Point> Knots = new();

        public Rope(int knots)
        {
            for(int i = 1; i<= knots; i++)
            {
                Knots.Add(new Point());
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        private static Point GetMovementVector(Point head, Point tail)
        {
            Point tailMovement = new();

            if(head.DistanceTo(tail) > Math.Sqrt(2))
            {
                if (head.X > tail.X) tailMovement.Offset(MovementVector(Direction.R));
                else if (head.X < tail.X) tailMovement.Offset(MovementVector(Direction.L));

                if (head.Y > tail.Y) tailMovement.Offset(MovementVector(Direction.U));
                else if (head.Y < tail.Y) tailMovement.Offset(MovementVector(Direction.D));
            }

            return tailMovement;    
        }

        public void Move(Point movementVector)
        {
            Knots[0] = Knots[0].Add(movementVector);
            for (int i=1; i< Knots.Count; i++)
            {
                Knots[i] = Knots[i].Add(GetMovementVector(Knots[i-1],Knots[i]));                    
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

    public Day9(string input, int knots)
    {
        rope = new Rope(knots);
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
            tailHistory.Add(rope.Tail);
        }
    }

    public int Solve()
    {
        PerformMovements();
        return tailHistory.Distinct().Count();
    }
}