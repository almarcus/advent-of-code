using System.Text;

namespace AOC2021;

public class Day3
{
    List<string> DiagnosticCodes
    {
        get;
        set;
    } = new List<string>();

    public static char GetMostCommonCharacterInPosition(List<string> input, int position)
    {

        var mostCommonCharacter =
            from characterInPosition in input.Select(x => x[position])
            group characterInPosition by characterInPosition into newGroup
            orderby newGroup.Count() descending, newGroup.Key descending
            select newGroup.Key;

            return mostCommonCharacter.First();
    }   

    public string gammaRateBinary
    {
        get
        {
            StringBuilder computedBinary = new StringBuilder(DiagnosticCodes.First().Length);
            for(int i=0; i< computedBinary.Capacity; i++)
            {
                computedBinary.Append(GetMostCommonCharacterInPosition(DiagnosticCodes, i));
            }

            return computedBinary.ToString();
        }
    }
    public string epsilonRateBinary => FlipBits(gammaRateBinary);

    public int gammaRate => Convert.ToInt32(gammaRateBinary, 2);
    public int epsilonRate => Convert.ToInt32(epsilonRateBinary, 2);

    public string oxygenGeneratorBinary
    {
        get
        {
            StringBuilder computedBinary = new StringBuilder(DiagnosticCodes.First().Length);
            List<string> oxygenList = DiagnosticCodes.ToList();
            int position = 0;
            while (true){
                oxygenList = oxygenList.Where(x => x[position] == GetMostCommonCharacterInPosition(oxygenList, position)).ToList();
                if (oxygenList.Count == 1) return oxygenList.First();
                
                position++;
            }
        }
    }

    public string co2ScrubberBinary
    {
        get
        {
            StringBuilder computedBinary = new StringBuilder(DiagnosticCodes.First().Length);
            List<string> co2List = DiagnosticCodes.ToList();
            int position = 0;
            while (true){
                co2List = co2List.Where(x => x[position] != GetMostCommonCharacterInPosition(co2List, position)).ToList();
                if (co2List.Count == 1) return co2List.First();
                
                position++;
            }
        }
    }

    public int oxygenGeneratorRating => Convert.ToInt32(oxygenGeneratorBinary, 2);

    public int co2ScrubberRating => Convert.ToInt32(co2ScrubberBinary, 2);


    
    
    public static string FlipBits(string binary) => string.Concat(binary.Select(x => x == '1' ? '0' : '1'));
    
    public Day3(List<string> input)
    {
        DiagnosticCodes = input;
    }

    
    public (int powerConsumption, int lifeSupportRating) Solve()
    {
        return (gammaRate * epsilonRate, oxygenGeneratorRating * co2ScrubberRating); 
    }
}