using Utilities;

Console.WriteLine("Hello, Advent of Coder!");
Console.WriteLine("Enter in the Year and Day you would like to play in [Year].[Day] format");
var year_and_day = Console.ReadLine();
(int year, int day) = Utility.ParseAoCDate(year_and_day);
switch (Utility.ParseAoCDate(year_and_day))
{
    case var t when t.year == 2021 && t.day == 1:
    Console.WriteLine("Give me the path to the input file");
    var path = Console.ReadLine();

    Console.WriteLine("What window woul you like?");
    int window = Int32.Parse(Console.ReadLine());
    var lines = Utility.ReadLinesFromFile(path);
    var problem = new AOC2021.Day1(lines);
    Console.WriteLine($"The answer is: {problem.Solve(window)}");
    break;
}