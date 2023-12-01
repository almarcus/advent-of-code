namespace AOC2023;

public class Day1
{
    List<CalibrationDocument> calibrationDocuments = new();

    public Day1(string input)
    {
        foreach(var calibrationDocument in input.Split("\n"))
        {
            calibrationDocuments.Add(new CalibrationDocument(calibrationDocument));
        }
    }

    public int Solve()
    {
        return calibrationDocuments.Sum(x => x.CalibrationValue);
    }

    class CalibrationDocument
    {
        string input;

        List<int> values => input.ToArray().Where(x => int.TryParse(x.ToString(), out int y)).Select(x => int.Parse(x.ToString())).ToList();
        public int CalibrationValue1 => values.FirstOrDefault();
        public int CalibrationValue2 => values.LastOrDefault();

        public int CalibrationValue => int.Parse(CalibrationValue1.ToString() + CalibrationValue2.ToString());
        public CalibrationDocument(string input)
        {
            this.input = input;
        }
    }
}

