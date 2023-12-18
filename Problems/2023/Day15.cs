using System.Net;
using System.Text.RegularExpressions;
using Utilities;

namespace AOC2023;

public class Day15
{
    List<Sequence> sequences = new List<Sequence>();
    

    public Day15(string input)
    {
        sequences = input.Split(",").Select(s => new Sequence(s)).ToList();
    }

    public int Solve1()
    {
        return sequences.Select(s => s.Hash()).Sum();
    }
    public int Solve2()
    {
        return 0;
    }

    public class Sequence
    {
        public string Characters { get; set; }

        public int Hash()
        {
            int currentVal = 0;
            foreach (var c in Characters)
            {
                int asciiValue = Convert.ToInt32(c);
                currentVal += asciiValue;
                currentVal *= 17;
                currentVal %= 256;
            }

            return currentVal;
        }

        public Sequence(string characters)
        {
            Characters = characters;
        }
    }

}
