using Utilities;

Console.WriteLine("Hello, Advent of Coder!");
Console.WriteLine("Enter in the Year and Day you would like to play in [Year].[Day] format");
var year_and_day = Console.ReadLine();
(int year, int day) = Utility.ParseAoCDate(year_and_day);

Console.WriteLine("Give me the path to the input file");
var path = Console.ReadLine();

var input = Utility.ReadLinesFromFile(path);

switch (Utility.ParseAoCDate(year_and_day))
{
    case var t when t.year == 2021 && t.day == 1:


        Console.WriteLine("What window would you like to apply?");
        int window = Int32.Parse(Console.ReadLine());
        var day1 = new AOC2021.Day1(input);
        Console.WriteLine($"The answer is: {day1.Solve(window)}");
        break;
    case var t when t.year == 2021 && t.day == 2:
        Console.WriteLine("What window would you like to apply?");
        var day2 = new AOC2021.Day2(input);
        
        Console.WriteLine($"The answer without aiming is: {day2.Solve(false)}");
        Console.WriteLine($"The answer with aiming is: {day2.Solve(true)}");
        break;
    case var t when t.year == 2021 && t.day == 3:
        var day3 = new AOC2021.Day3(input);
        Console.WriteLine($"The power consumption is {day3.Solve().powerConsumption}");
        Console.WriteLine($"The life support rating is {day3.Solve().lifeSupportRating}");
        break;
}