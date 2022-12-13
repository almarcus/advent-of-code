namespace AOC2022;

public class Day11
{

    public class Monkey
    {
        private readonly int worryFactor;
        public Int64 Inspections = 0;
        private const string startingItemsString = "Starting items: ";
        private const string operationString = "Operation: new = old ";
        private const string divisibilityTestString = "Test: divisible by ";
        private const string trueString = "If true: throw to monkey ";
        private const string falseString = "If false: throw to monkey ";
        
        public enum Operation
        {
            add,
            multiply,
            square
        }
        public List<Int64> Items = new();
        public Operation ItemOperation;
        public int OperationValue;
        public int DivisibilityCheck;
        public (int trueMonkey, int falseMonkey) MonkeyToThrowTo;

        public Monkey(string input, int worryFactor)
        {
            this.worryFactor = worryFactor;
            var inputLines = input.Split('\n', StringSplitOptions.TrimEntries);

            Items = inputLines[0][startingItemsString.Length..].Split(',', StringSplitOptions.TrimEntries).Select(x => Int64.Parse(x)).ToList();

            var operationLines = inputLines[1][operationString.Length..].Split(' ');
            switch (operationLines[1])
            {
                case "old":
                    ItemOperation = Operation.square;
                    break;
                default:
                    OperationValue = int.Parse(operationLines[1]);
                    ItemOperation = operationLines[0] == "*" ? Operation.multiply : Operation.add;
                    break;
            }

            DivisibilityCheck = int.Parse(inputLines[2][divisibilityTestString.Length..]);

            var trueMonkey = int.Parse(inputLines[3][trueString.Length..]);

            var falseMonkey = int.Parse(inputLines[4][falseString.Length..]);

            MonkeyToThrowTo = (trueMonkey, falseMonkey);
        }

        public List<(Int64 newItemValue, int destinationMonkey)> PerformInspections(int lcm) => Items.Select(x => Inspect(x, lcm)).ToList();

        private (Int64 newItemValue, int destinationMonkey) Inspect(Int64 itemValue, int lcm)
        {
            
            Int64 newItemValue = itemValue;
            newItemValue = Operate(newItemValue);
            newItemValue /= worryFactor;

            newItemValue %= lcm;
            Inspections++;
            return (newItemValue, (newItemValue % DivisibilityCheck == 0) ? MonkeyToThrowTo.trueMonkey : MonkeyToThrowTo.falseMonkey);
        }

        private Int64 Operate(Int64 item) =>
        ItemOperation switch
        {
            Operation.square => item * item,
            Operation.add => item += OperationValue,
            Operation.multiply => item *= OperationValue,
            _ => throw new NotImplementedException()
        };
    }
    
    public List<Monkey> Monkeys = new();

    private int lcm => Monkeys.Select(x=>x.DivisibilityCheck).Aggregate((total, next) => total * next);

    private void PerformInspection(Monkey monkey, int lcm)
    {
        var postInspections = monkey.PerformInspections(lcm);
        
        monkey.Items.Clear();

        foreach(var items in postInspections)
        {
            Monkeys[items.destinationMonkey].Items.Add(items.newItemValue);
        }
    }

    public Day11(string input, int worryFactor)
    {
        foreach (string s in input.Split("\n\n"))
            Monkeys.Add(new Monkey(s[(s.IndexOf(':')+3)..], worryFactor));
    }

    public Int64 Solve(int rounds)
    {
        for (int round= 1; round <= rounds; round++)
        {
            foreach(var monkey in Monkeys)
            {
                PerformInspection(monkey, lcm);
            }
        }

        return Monkeys.OrderByDescending(x => x.Inspections)
                      .Take(2)
                      .Select(x => x.Inspections)
                      .Aggregate((total, next) => total * next);
    }
}