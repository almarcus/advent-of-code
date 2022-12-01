using System.Drawing;
using System.Text.RegularExpressions;

namespace Utilities;
public partial class Utility
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
}