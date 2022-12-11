namespace AOC2022;

public class Day6
{
    public static int Solve(string input, int messageSize)
    {
        for (int i = 0; i < input.Length; i++)
        {
            var end = i+messageSize;
            if (input[i..end].Distinct().Count() == messageSize)
                return end;
        }

        return 0;
    }
}