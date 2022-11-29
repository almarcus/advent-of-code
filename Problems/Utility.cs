using System.Text.RegularExpressions;

namespace Utilities;
public partial class Utility
{
    public static List<string> ReadLinesFromFile(string path){
        return File.ReadAllLines(path).ToList();
    }

    public static (int year, int day) ParseAoCDate(string input)
    {
        string[] split_inputs = input.Split('.');
        if(split_inputs.Length == 2)
            return (int.Parse(split_inputs[0]), int.Parse(split_inputs[1]));
        else
            throw new ArgumentException("Input parameter is not a valid format", nameof(input));
    }
}