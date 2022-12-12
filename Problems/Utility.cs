using System.Drawing;
using System.Text.RegularExpressions;

namespace Utilities;
public static class Utility
{
    public static List<string> ReadLinesFromFile(string path){
        return File.ReadAllLines(path).ToList();
    }

    public static string ReadFile(string path){
        return File.ReadAllText(path);
    }

    public static (int year, int day) ParseAoCDate(string input)
    {
        string[] split_inputs = input.Split('.');
        if(split_inputs.Length == 2)
            return (int.Parse(split_inputs[0]), int.Parse(split_inputs[1]));
        else
            throw new ArgumentException("Input parameter is not a valid format", nameof(input));
    }

    public static Point ParsePoint(string input)
    {
        List<int> coordinates = input.TrimStart('(').TrimEnd(')').Split(',').Select(x => Int32.Parse(x)).ToList();
        return new Point(coordinates[0], coordinates[1]);
    }

    public static int Priority(this char input)
    {
        char flippedCase = char.IsUpper(input) ? char.ToLower(input) : char.ToUpper(input);
        int offset = char.IsUpper(flippedCase) ? 64 : 64+6;

        return (int)flippedCase - offset;
    }

    public static IEnumerable<int> Range(int start, int end)
    {
        return Enumerable.Range(start, Math.Abs(end - start) + 1);
    }

    public static double Magnitude(this Point point) => Math.Sqrt(Math.Pow(point.X, 2) + Math.Pow(point.Y,2));

    public static double DistanceTo(this Point pointFrom, Point pointTo) => (new Point(pointFrom.X - pointTo.X, pointFrom.Y - pointTo.Y)).Magnitude();
}