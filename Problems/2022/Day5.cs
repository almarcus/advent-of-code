using System.Text.RegularExpressions;

namespace AOC2022;

public class Day5
{
    public List<Movement> Movements = new();

    public List<Stack> Stacks = new();

    public class Stack
    {

        public void AddToStack(List<char> crates, bool pickupMultiple)
        {
            if (pickupMultiple)
                Crates.AddRange(crates);
            else
                Crates.AddRange(crates.ToArray().Reverse().ToList());
        }

        public List<char> RemoveFromStack(int numberToRemove)
        {
            var removedCrates = Crates.TakeLast(numberToRemove).ToList();
            Crates = Crates.Take(Crates.Count - numberToRemove).ToList();

            return removedCrates;
        }
        public List<char> Crates = new();
    }
    public class Ship
    {
        List<char> stack = new();

        public Ship() {}
    }
    
    public class Movement
    {
        public int NumberToMove;
        public int FromStack;
        public int ToStack;

        public Movement(string input) 
        {
            Regex regex = new Regex(@"\d*");

            var matches = regex.Matches(input).Where(x => x.Length > 0).ToList();

            NumberToMove = int.Parse(matches[0].Groups[0].Value);
            FromStack = int.Parse(matches[1].Groups[0].Value);
            ToStack = int.Parse(matches[2].Groups[0].Value);
        }
    }

    private void parseContainerInput(string input)
    {
        var lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

        Regex regex = new Regex(@"\d");
        for (int i = 1; i <= regex.Matches(lines.Last()).Count; i++)
            Stacks.Add(new Stack());


        var containers = lines.Reverse().ToArray()[1..];

        foreach (var containerRow in containers)
        {
            for (int i = 1; i< containerRow.Length; i+=4)
            {
                char crate = containerRow[i];

                double stackIndex = (i-1)/4;

                stackIndex = Math.Floor(stackIndex);

                if(char.IsAsciiLetter(crate))
                    Stacks[(int)stackIndex].AddToStack(new List<char>() {crate}, false);
            }
        }
    }

    public Day5(string input)
    {
        var splitInput = input.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);

        parseContainerInput(splitInput[0]);

        foreach (string movement in splitInput[1].Split("\n", StringSplitOptions.RemoveEmptyEntries))
            Movements.Add(new Movement(movement));
    }

    private void processMovement(Movement movement, bool pickupMultiple)
    {
        Stacks[movement.ToStack-1].AddToStack(Stacks[movement.FromStack-1].RemoveFromStack(movement.NumberToMove), pickupMultiple);
    }

    public string Solve(bool pickupMultiple)
    {
        foreach(Movement movement in Movements)
            processMovement(movement, pickupMultiple);

        return string.Concat(Stacks.Select(x => x.Crates.Last()).ToArray());
    }
}
