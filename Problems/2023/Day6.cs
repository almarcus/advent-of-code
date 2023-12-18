using System.Net;
using System.Text.RegularExpressions;
using Utilities;

namespace AOC2023;

public class Day6
{
    List<Race> part1Races = new();

    Race part2Race = new();

    public Day6(string input)
    {
        string pattern = @"(\d+)"; // Matches one or more digits


        MatchCollection matches = Regex.Matches(input, pattern, RegexOptions.Singleline);

        string part2Time = string.Empty;
        string part2Distance = string.Empty;
        for (int i = 0; i < matches.Count / 2; i++)
        {
            part1Races.Add(new Race() { Time = Int64.Parse(matches[i].Value), RecordDistance = Int64.Parse(matches[i + matches.Count / 2].Value) });
            part2Time += matches[i].Value;
            part2Distance += matches[i + matches.Count / 2].Value;
        }

        part2Race.Time = int.Parse(part2Time);
        part2Race.RecordDistance = Int64.Parse(part2Distance);
    }

    public Int64 Solve1()
    {
        Int64 l_return = 1;
        foreach (Race r in part1Races)
        {
            for (int timeHeld = 0; timeHeld <= r.Time; timeHeld++)
            {
                r.BoatsInRace.Add(new Boat() { Speed = timeHeld });
            }

            l_return *= r.NumberOfBoatsToWin;
        }

        return l_return;


    }
    public Int64 Solve2()
    {
        for (int timeHeld = 0; timeHeld <= part2Race.Time; timeHeld++)
        {
            part2Race.BoatsInRace.Add(new Boat() { Speed = timeHeld });
        }

        return part2Race.NumberOfBoatsToWin;
    }

    public class Race
    {
        public Int64 NumberOfBoatsToWin => BoatsInRace.Where(b => BeatsRecord(b, Time - b.Speed)).Count();
        public Int64 Time { get; set; }
        public Int64 RecordDistance { get; set; }

        public bool BeatsRecord(Boat boat, Int64 time)
        {
            return boat.GetDistance(time) > RecordDistance;
        }

        public List<Boat> BoatsInRace { get; set; } = new();
    }

    public class Boat
    {
        public Int64 Speed { get; set; } = 0;

        public Int64 GetDistance(Int64 time) => Speed * time;
    }

}
