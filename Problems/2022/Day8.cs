using System.Drawing;

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

    public int CalculateVisibleTrees() => forest.Where(tree =>  canSeeFromDirection(tree, Direction.Up) || 
                                                                canSeeFromDirection(tree, Direction.Down) || 
                                                                canSeeFromDirection(tree, Direction.Left) || 
                                                                canSeeFromDirection(tree, Direction.Right)
                                                      ).Count();

}