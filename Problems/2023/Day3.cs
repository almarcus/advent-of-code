using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using Utilities;

namespace AOC2023;

public class Day3
{
    public List<SchematicData> Numbers { get; set; } = new List<SchematicData>();
    public List<SchematicData> Symbols { get; set; } = new List<SchematicData>();

    public List<SchematicData> PartMatches => Numbers.Where(n => n.IsPartNumber(Symbols)).ToList();
    public List<SchematicData> Gears => Symbols.Where(n => n.Data == "*").ToList();
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

    public int GetSumPartNumbers() => PartMatches.Where(n => n.IsPartNumber(Symbols)).Sum(n => int.Parse(n.Data));
    public int GetSumGears() => Gears.Sum(n => n.GetGearRatio(Numbers));

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
            var hitLeft = checks.Any(c => c.Row == Row && c.Column == Column - 1);  // check to the left
            var hitRight = checks.Any(c => c.Row == Row && c.Column == Column + Length); // check to the right
            var hitAbove = checks.Any(c => c.Row == Row - 1 && c.Column >= Column - 1 && c.Column <= (Column + Length)); // check above with diagonal
            var hitBelow = checks.Any(c => c.Row == Row + 1 && c.Column >= Column - 1 && c.Column <= (Column + Length)); // check below with diagonal
            var isPartNumber = hitLeft || hitRight || hitAbove || hitBelow;
            return isPartNumber;
        }

        public int GetGearRatio(List<SchematicData> checks)
        {

            var hitLeft = checks.Where(c => c.Row == Row && (c.Column + c.Length + 1) == Column);  // check to the left
            var hitRight = checks.Where(c => c.Row == Row && c.Column == Column + 1); // check to the right
            var hitAbove = checks.Where(c => c.Row == Row - 1 && c.Column <= Column && c.Column + c.Length >= Column); // check above with diagonal
            var hitBelow = checks.Where(c => c.Row == Row + 1 && c.Column <= Column && c.Column + c.Length >= Column); // check above with diagonal

            
            if((hitLeft.Count() + hitRight.Count() + hitAbove.Count() + hitBelow.Count()) == 2)
            {
                var product =  Math.Max(hitLeft.Sum(c => int.Parse(c.Data)), 1) *
                       Math.Max(hitRight.Sum(c => int.Parse(c.Data)), 1) *
                       Math.Max(hitAbove.Sum(c => int.Parse(c.Data)), 1) *
                       Math.Max(hitBelow.Sum(c => int.Parse(c.Data)), 1);

                       return product;
            }

            return 0;
        }

        public override string ToString()
        {
            return $"Data: {Data}, Row: {Row}, Column: {Column}";
        }

    }

}

