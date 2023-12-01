namespace AOC2023;

public class Day1
{
    public static List<int> ParseInput(string input, bool translateSpelledOutNumbers = false)
    {
        List<int> returnList = new();

        for (int i = 0; i < input.Length; i++)
        {
            if (int.TryParse(input[i].ToString(), out int number))
            {
                returnList.Add(number);
            }
            else if (translateSpelledOutNumbers)
            {
                string currentWord = input.Substring(i);
                if (currentWord.StartsWith("one"))
                {
                    returnList.Add(1);
                }
                else if (currentWord.StartsWith("two"))
                {
                    returnList.Add(2);
                }
                else if (currentWord.StartsWith("three"))
                {
                    returnList.Add(3);
                }
                else if (currentWord.StartsWith("four"))
                {
                    returnList.Add(4);
                }
                else if (currentWord.StartsWith("five"))
                {
                    returnList.Add(5);
                }
                else if (currentWord.StartsWith("six"))
                {
                    returnList.Add(6);
                }
                else if (currentWord.StartsWith("seven"))
                {
                    returnList.Add(7);
                }
                else if (currentWord.StartsWith("eight"))
                {
                    returnList.Add(8);
                }
                else if (currentWord.StartsWith("nine"))
                {
                    returnList.Add(9);
                }
            }
        }

        return returnList;
    }

    List<CalibrationDocument> calibrationDocuments = new();

    public Day1(string input, bool translateSpelledOutNumbers = false)
    {
        foreach (var calibrationDocument in input.Split("\n"))
        {
            calibrationDocuments.Add(new CalibrationDocument(calibrationDocument, translateSpelledOutNumbers));
        }
    }

    public int Solve()
    {
        return calibrationDocuments.Sum(x => x.CalibrationValue);
    }

    class CalibrationDocument
    {
        string _input;
        bool _translateSpelledOutNumbers;

        public int CalibrationValue1 => ParseInput(_input, _translateSpelledOutNumbers).FirstOrDefault();
        public int CalibrationValue2 => ParseInput(_input, _translateSpelledOutNumbers).LastOrDefault();

        public int CalibrationValue => int.Parse(CalibrationValue1.ToString() + CalibrationValue2.ToString());
        public CalibrationDocument(string input, bool translateSpelledOutNumbers = false)
        {
            _input = input;
            _translateSpelledOutNumbers = translateSpelledOutNumbers;
        }
    }
}
