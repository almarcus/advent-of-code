namespace AOC2022;

public class Day10
{
    Dictionary<int,char> CRTPixels = new Dictionary<int, char>();

    const int firstSpecialCycle = 20;
    const int specialCycleIncrease = 40;

    enum Operation
    {
        noop,
        addx
    }

    List<Instruction> Instructions = new();

    List<int> Cycles = new();

    private void PopulateCycles()
    {
        foreach (var instruction in Instructions)
        {
            if (instruction.Operation == Operation.addx)
            {
                Cycles.Add(0);
            }

            Cycles.Add(instruction.V ?? 0);
        }
    }

    public int CalculateSignalStrength(int cycleNumber) => CalculateXValue(cycleNumber-1) * cycleNumber;

    public int CalculateXValue(int cycleNumber) => (1 + Cycles.Take(cycleNumber).Sum());

    public static bool IsSpecialCycle(int cycleNumber) => ((cycleNumber - firstSpecialCycle) % specialCycleIncrease) == 0;
    
    class Instruction
    {
        public Operation Operation {get;init;}

        public int? V {get; init;}

        public Instruction() {}
        public Instruction(string input) 
        {
            var splitInput = input.Split(' ');
            Operation = (Operation)Enum.Parse(typeof(Operation), splitInput[0]);

            if(Operation == Operation.addx) V = int.Parse(splitInput[1]);
        }
    }

    public Day10(string input)
    {
        foreach(var row in input.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            Instructions.Add(new Instruction(row));
        }

        PopulateCycles();
    }

    public int Solve()
    {
        return Cycles.Select((cycle, index) => new { cycle, CycleNumber = index+1, IsSpecial = IsSpecialCycle(index+1)}).Where(x => x.IsSpecial).Sum(x => CalculateSignalStrength(x.CycleNumber));
    }

    public List<string> Draw()
    {
        for (int crtPosition=0; crtPosition<240; crtPosition++)
        {
            var spritePosition = CalculateXValue(crtPosition);
            var pixelCharacter = (crtPosition % 40 <= spritePosition + 1 && crtPosition % 40>= spritePosition -1) ? '#' : '.';
            CRTPixels.Add(crtPosition+1, pixelCharacter);
        }

        return CRTPixels.Values.Chunk(40).Select(x => string.Join("", x)).ToList();
    }


}