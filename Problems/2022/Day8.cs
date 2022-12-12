using System.Drawing;
using Utilities;

namespace AOC2022;

public class Day8
{

    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    List<Tree> forest = new();

    Point forestEdge => forest.OrderByDescending(x => x.Position.Magnitude()).First().Position;

    public class Tree
    {
        public int Height;
        public Point Position;

        public Tree(int x, int y, int height)
        {
            Position = new Point(x,y);
            Height = height;
        }
    }

    public Day8(string input)
    {
        var rows = input.Split('\n',StringSplitOptions.RemoveEmptyEntries);

        for (int row=0; row<rows.Length; row++)
        {
            for (int column=0; column < rows[row].Length; column++)
            {
                forest.Add(new Tree(column, row, rows[row][column]));
            }
        }
    }

    List<Tree> GetTrees(Point position, Direction direction) => direction switch
    {
        Direction.Up => forest.Where(trees => (trees.Position.X == position.X) && (trees.Position.Y < position.Y)).ToList(),
        Direction.Down => forest.Where(trees => (trees.Position.X == position.X) && (trees.Position.Y > position.Y)).ToList(),
        Direction.Left => forest.Where(trees => (trees.Position.X < position.X) && (trees.Position.Y == position.Y)).ToList(),
        Direction.Right => forest.Where(trees => (trees.Position.X > position.X) && (trees.Position.Y == position.Y)).ToList(),
    };

    bool canSeeFromDirection(Tree tree, Direction direction) => GetTrees(tree.Position, direction).All(x => x.Height < tree.Height);

    Tree lastTreeThatCanBeSeen(Tree tree, Direction direction)
    {
        var trees = GetTrees(tree.Position, direction);
        
        switch(direction)
        {
            case Direction.Up:
            case Direction.Left:
                trees.Reverse();
                break;

        };

        return trees.FirstOrDefault(x => x.Height >= tree.Height, trees.Last());
    }

    double viewingDistance(Tree tree, Direction direction) => tree.Position.DistanceTo(lastTreeThatCanBeSeen(tree, direction).Position);

    double scenicScore(Tree tree) => viewingDistance(tree, Direction.Up)
                                   * viewingDistance(tree, Direction.Down)
                                   * viewingDistance(tree, Direction.Left)
                                   * viewingDistance(tree, Direction.Right);
    public int CalculateVisibleTrees() => forest.Where(tree =>  canSeeFromDirection(tree, Direction.Up) || 
                                                                canSeeFromDirection(tree, Direction.Down) || 
                                                                canSeeFromDirection(tree, Direction.Left) || 
                                                                canSeeFromDirection(tree, Direction.Right)
                                                      ).Count();

    public double CalculateScenicScore() => forest.Where(x => x.Position.X > 0 && x.Position.Y > 0 && x.Position.X < forestEdge.X && x.Position.Y < forestEdge.Y).Max(x => scenicScore(x));

}