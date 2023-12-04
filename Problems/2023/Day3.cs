using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Utilities;

namespace AOC2023;

public class Day3
{
    public List<SchematicData> Numbers { get; set; } = new List<SchematicData>();
    public List<SchematicData> Symbols { get; set; } = new List<SchematicData>();

    public List<SchematicData> Matches => Numbers.Where(n => n.IsPartNumber(Symbols)).ToList();
    public Day3(string input)
    {

        foreach (var line in input.Split("\n").Select((value, index) => new { value, index }))
        {



            string numberPattern = @"\d+";
            Regex regex = new Regex(numberPattern);
            MatchCollection matches = regex.Matches(line.value);

            foreach (Match match in matches)
            {
                Numbers.Add(new SchematicData(match.Groups[0].Value, line.index, match.Groups[0].Index));
            }

            string symbolPattern = @"[^.\d]+";
            regex = new Regex(symbolPattern);
            matches = regex.Matches(line.value);

            foreach (Match match in matches)
            {
                Symbols.Add(new SchematicData(match.Groups[0].Value, line.index, match.Groups[0].Index));
            }
        }
    }

    public int GetSumPartNumbers()
    {
        return Matches.Where(n => n.IsPartNumber(Symbols)).Sum(n => int.Parse(n.Data));
    }

    public class SchematicData
    {
        public string Data { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public int Length => Data.Length;

        public SchematicData(string data, int row, int column)
        {
            Data = data;
            Row = row;
            Column = column;
        }


        public bool IsPartNumber(List<SchematicData> checks)
        {
            if(Data == "143")
            {
                Console.WriteLine("here");
            }
            var hitLeft = checks.Any(c => c.Row == Row && c.Column == Column - 1);  // check to the left
            var hitRight = checks.Any(c => c.Row == Row && c.Column == Column + Length); // check to the right
            var hitAbove = checks.Any(c => c.Row == Row - 1 && c.Column >= Column - 1 && c.Column <= (Column + Length)); // check above with diagonal
            var hitBelow = checks.Any(c => c.Row == Row + 1 && c.Column >= Column - 1 && c.Column <= (Column + Length)); // check below with diagonal
            var isPartNumber = hitLeft || hitRight || hitAbove || hitBelow;
            return isPartNumber;
        }

        public override string ToString()
        {
            return $"Data: {Data}, Row: {Row}, Column: {Column}";
        }

    }

}

