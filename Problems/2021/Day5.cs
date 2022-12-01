using System.Drawing;
using Utilities;

namespace AOC2021;

public class Day5
{
    Dictionary<Point, int> Grid = new();
    List<Tuple<Point,Point>> pairedPoints;

    public Day5(List<string> input)
    {
        pairedPoints = input.Select(x => x.Split("->", StringSplitOptions.TrimEntries))
                                                    .Select(x => Tuple.Create(Utility.ParsePoint(x[0]),Utility.ParsePoint(x[1]))).ToList();

    }

    private List<Point> getLinePoints(Point Point1, Point Point2)
    {
        List<Point> linePoints = new List<Point>();

        Point linePoint = Point1;

        while (linePoint != Point2)
        {
            linePoints.Add(linePoint);
            
            if(Point1.X < Point2.X) linePoint.X++;
            else if (Point1.X > Point2.X) linePoint.X--;

            if(Point1.Y < Point2.Y) linePoint.Y++;
            else if (Point1.Y > Point2.Y) linePoint.Y--;
        }

        linePoints.Add(Point2);
        
        // if(Point1.X == Point2.X) // vertical line
        // {
        //     for (int y= Math.Min(Point1.Y,Point2.Y); y<= Math.Max(Point1.Y,Point2.Y); y++) linePoints.Add(new Point(Point1.X, y));
        // }
        // else if(Point1.Y == Point2.Y) // horizontal line
        // {
        //     for (int x= Math.Min(Point1.X,Point2.X); x<= Math.Max(Point1.X,Point2.X); x++) linePoints.Add(new Point(x, Point1.Y));
        // }

        return linePoints;
    }

    public int Solve(bool ignoreDiagonals = true)
    {
        Grid.Clear();
        
        List<Tuple<Point,Point>> pairsToMap = ignoreDiagonals ? pairedPoints.Where(x => x.Item1.X == x.Item2.X || x.Item1.Y == x.Item2.Y).ToList() : pairedPoints;
        
        foreach (var pair in pairsToMap){
            foreach (var linePoint in getLinePoints(pair.Item1, pair.Item2))
            {
                if (!Grid.TryAdd(linePoint,1))
                    Grid[linePoint]++;
            }
        }

        return Grid.Where(x => x.Value > 1).Count();
    }
}