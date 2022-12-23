namespace UnitTests;

using System.Text.Json.Nodes;
using AOC2022;
using Utilities;
using Xunit.Abstractions;

public class AoC2022Tests
{

    private readonly ITestOutputHelper output;

    public AoC2022Tests(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day1Example.txt", 1, 24000)]
    [InlineData(@"2022/Inputs/Day1Example.txt", 3, 45000)]
    [InlineData(@"2022/Inputs/Day1.txt", 1, 71780)]
    [InlineData(@"2022/Inputs/Day1.txt", 3, 212489)]
    public void Day1Solutions(string filename, int elvesToCheck, int expectedResult)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day1(input);

        Assert.Equal(expectedResult, problem.Solve(elvesToCheck));
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day2Example.txt", true, 15)]
    [InlineData(@"2022/Inputs/Day2Example.txt", false, 12)]
    [InlineData(@"2022/Inputs/Day2.txt", true, 11386)]
    [InlineData(@"2022/Inputs/Day2.txt", false, 13600)]
    public void Day2Solutions(string filename, bool secondInputIsChoice, int expectedResult)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day2(input, secondInputIsChoice);

        Assert.Equal(expectedResult, problem.Solve());
    }

    [Theory]
    [InlineData("aa",'a', 1)]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp",'p',16)]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",'L',38)]
    [InlineData("PmmdzqPrVvPwwTWBwg",'P',42)]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",'v',22)]
    [InlineData("ttgJtRGJQctTZtZT",'t',20)]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw",'s',19)]
    
    public void Day3CheckRucksackProperties(string rucksackItems, char expectedCommonItem, int expectedPriority)
    {
        var rucksack = new Day3.Rucksack(rucksackItems);

        Assert.Equal(expectedCommonItem, rucksack.CommonItem);
        Assert.Equal(expectedPriority, rucksack.Priority);
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day3Example.txt", 157, 70)]
    [InlineData(@"2022/Inputs/Day3.txt", 7990, 2602)]
    public void Day3Solutions(string filename, int expectedPart1Result, int expectedPart2Result)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day3(input);

        Assert.Equal(expectedPart1Result, problem.Solve());
        Assert.Equal(expectedPart2Result, problem.SolveWithBuckets(3));
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day4Example.txt", 6)]
    [InlineData(@"2022/Inputs/Day4.txt", 1000)]
    public void Day4Parsing(string filename, int expectedElfPairs)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day4(input);

        Assert.Equal(expectedElfPairs, problem.ElfPairs.Count);
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day4Example.txt", false, 2)]
    [InlineData(@"2022/Inputs/Day4Example.txt", true, 4)]
    [InlineData(@"2022/Inputs/Day4.txt", false, 550)]
    [InlineData(@"2022/Inputs/Day4.txt", true, 931)]
    public void Day4Solutions(string filename, bool onlyPartialOverlaps, int expectedResult)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day4(input);
        
        Assert.Equal(expectedResult, problem.Solve(onlyPartialOverlaps));
    }

    [Theory]
    [InlineData("move 1 from 2 to 1", 1, 2, 1)]
    [InlineData("move 3 from 1 to 3", 3, 1, 3)]
    [InlineData("move 2 from 2 to 1", 2, 2, 1)]
    [InlineData("move 1 from 1 to 2", 1, 1, 2)]
    [InlineData("move 10 from 20 to 30", 10, 20, 30)]
    public void Day5MovementParsing(string input, int expectedNumberToMove, int expectedFromStack, int expectedToStack)
    {
        Day5.Movement movement = new Day5.Movement(input);
        
        Assert.Equal(expectedNumberToMove, movement.NumberToMove);
        Assert.Equal(expectedFromStack, movement.FromStack);
        Assert.Equal(expectedToStack, movement.ToStack);
    }

    [Fact]
    public void Day5StackParsing()
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day5Example.txt");

        var problem = new Day5(input);

        Assert.Equal(4, problem.Movements.Count);
        Assert.Equal(3, problem.Stacks.Count);

        Assert.Collection(problem.Stacks[0].Crates,
            crate => Assert.Equal('Z', crate),
            crate => Assert.Equal('N', crate)
            );
        Assert.Collection(problem.Stacks[1].Crates,
            crate => Assert.Equal('M', crate),
            crate => Assert.Equal('C', crate),
            crate => Assert.Equal('D', crate)
            );
        Assert.Collection(problem.Stacks[2].Crates,
            crate => Assert.Equal('P', crate)
            );
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day5Example.txt", false, "CMZ")]
    [InlineData(@"2022/Inputs/Day5Example.txt", true, "MCD")]
    [InlineData(@"2022/Inputs/Day5.txt", false, "QGTHFZBHV")]
    [InlineData(@"2022/Inputs/Day5.txt", true, "MGDMPSZTM")]
    public void Day5Solutions(string filename, bool pickupMultiple, string expectedResult)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day5(input);

        Assert.Equal(expectedResult, problem.Solve(pickupMultiple));
    }

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 4, 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 4, 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 4, 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 4, 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 4, 11)]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 14, 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 14, 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 14, 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 14, 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 14, 26)]
    public void Day6Example(string input, int messageSize, int expectedResult)
    {
        Assert.Equal(expectedResult, Day6.Solve(input, messageSize));
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day6.txt", 4, 1833)]
    [InlineData(@"2022/Inputs/Day6.txt", 14, 3425)]

    public void Day6Solution(string filename, int messageSize, int expectedResult)
    {
        var input = Utility.ReadFile(filename);

        Assert.Equal(expectedResult, Day6.Solve(input, messageSize));
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day8Example.txt", 21, 8)]
    [InlineData(@"2022/Inputs/Day8.txt", 1705, 371200)]
    public void Day8Solution(string filename, int expectedVisibleTrees, int expectedScenicScore)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day8(input);

        Assert.Equal(expectedVisibleTrees, problem.CalculateVisibleTrees());
        Assert.Equal(expectedScenicScore, problem.CalculateScenicScore());
    }    

    [Theory]
    [InlineData(@"2022/Inputs/Day9Example1.txt", 2,13)]
    [InlineData(@"2022/Inputs/Day9Example1.txt", 10,1)]
    [InlineData(@"2022/Inputs/Day9Example2.txt", 10,36)]
    [InlineData(@"2022/Inputs/Day9.txt", 2,6311)]
    [InlineData(@"2022/Inputs/Day9.txt", 10,2482)]
    public void Day9Example1(string filename, int knots, int expectedResult)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day9(input, knots);

        Assert.Equal(expectedResult,problem.Solve());
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day10Example1.txt",1,1)]
    [InlineData(@"2022/Inputs/Day10Example1.txt",2,1)]
    [InlineData(@"2022/Inputs/Day10Example1.txt",3,4)]
    [InlineData(@"2022/Inputs/Day10Example1.txt",4,4)]
    [InlineData(@"2022/Inputs/Day10Example1.txt",5,-1)]
    public void Day10XValueTests(string filename, int cyclesToRun, int expectedXValue)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day10(input);

        Assert.Equal(expectedXValue, problem.CalculateXValue(cyclesToRun));
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day10Example2.txt",20,420)]
    [InlineData(@"2022/Inputs/Day10Example2.txt",60,1140)]
    [InlineData(@"2022/Inputs/Day10Example2.txt",100,1800)]
    [InlineData(@"2022/Inputs/Day10Example2.txt",140,2940)]
    [InlineData(@"2022/Inputs/Day10Example2.txt",180,2880)]
    [InlineData(@"2022/Inputs/Day10Example2.txt",220,3960)]
    public void Day10SignalStrengthTests(string filename, int cycle, int expectedSignalStrength)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day10(input);

        Assert.Equal(expectedSignalStrength, problem.CalculateSignalStrength(cycle));
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(20, true)]
    [InlineData(30, false)]
    [InlineData(40, false)]
    [InlineData(50, false)]
    [InlineData(60, true)]
    [InlineData(100, true)]
    [InlineData(140, true)]
    [InlineData(180, true)]
    [InlineData(220, true)]
    public void Day10CheckSpecialCycle(int cycle, bool expectedSpecialIndicator)
    {
        Assert.Equal(expectedSpecialIndicator, Day10.IsSpecialCycle(cycle));
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day10Example2.txt",13140)]
    [InlineData(@"2022/Inputs/Day10.txt",14820)]
    public void Day10Part1Solutions(string filename, int expectedResult)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day10(input);

        Assert.Equal(expectedResult, problem.Solve());
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day10Example2.txt", "##..##..##..##..##..##..##..##..##..##..\n###...###...###...###...###...###...###.\n####....####....####....####....####....\n#####.....#####.....#####.....#####.....\n######......######......######......####\n#######.......#######.......#######.....")]
    [InlineData(@"2022/Inputs/Day10.txt", "###..####.####.#..#.####.####.#..#..##..\n#..#....#.#....#.#..#....#....#..#.#..#.\n#..#...#..###..##...###..###..####.#..#.\n###...#...#....#.#..#....#....#..#.####.\n#.#..#....#....#.#..#....#....#..#.#..#.\n#..#.####.####.#..#.####.#....#..#.#..#.")]
    public void Day10Part2Solutions(string filename, string expectedResult)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day10(input);

        var drawing = problem.Draw();

        Assert.Equal(expectedResult, string.Join(Environment.NewLine, drawing));
    }

    [Theory]
    [InlineData(1, 2, 4, 3, 6)]
    [InlineData(20, 99, 97, 8, 103)]
    [InlineData(1000, 5204, 4792, 199, 5192)]
    [InlineData(2000, 10419, 9577, 392, 10391)]
    [InlineData(3000, 15638, 14358, 587, 15593)]
    [InlineData(4000, 20858, 19138, 780, 20797)]
    [InlineData(5000, 26075, 23921, 974, 26000)]
    [InlineData(6000, 31294, 28702, 1165, 31204)]
    [InlineData(7000, 36508, 33488, 1360, 36400)]
    [InlineData(8000, 41728, 38268, 1553, 41606)]
    [InlineData(9000, 46945, 43051, 1746, 46807)]
    [InlineData(10000, 52166, 47830, 1938, 52013)]
    public void Day11bExampleByMonkey(int rounds, int firstMonkeyExpectedInspections, int secondMonkeyExpectedInspections, int thirdMonkeyExpectedInspections, int fourthMonkeyExpectedInspections)
    {
        var input = Utility.ReadFile(@"2022/Inputs/Day11Example.txt");

        var problem = new Day11(input, 1);

        problem.Solve(rounds);
        Assert.Equal(firstMonkeyExpectedInspections, problem.Monkeys[0].Inspections);
        Assert.Equal(secondMonkeyExpectedInspections, problem.Monkeys[1].Inspections);
        Assert.Equal(thirdMonkeyExpectedInspections, problem.Monkeys[2].Inspections);
        Assert.Equal(fourthMonkeyExpectedInspections, problem.Monkeys[3].Inspections);
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day11Example.txt", 20, 3, 10605)]
    [InlineData(@"2022/Inputs/Day11Example.txt", 10000, 1, 2713310158)]
    [InlineData(@"2022/Inputs/Day11.txt", 20, 3, 76728)]
    [InlineData(@"2022/Inputs/Day11.txt", 10000, 1, 21553910156)]
    public void Day11Solutions(string filename, int rounds, int worryFactor, Int64 expectedResult)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day11(input, worryFactor);

        Assert.Equal(expectedResult, problem.Solve(rounds));
    }

    [Fact]
    public void FileTests()
    {
        Day7.File top = new("/");
        Day7.File b = new("b.txt", 14848514);
        Day7.File c = new("c.dat", 8504156);
        Day7.File a = new("a");
        Day7.File f = new("f", 29116);
        Day7.File e = new("e");
        top.Files.Add(b);
        top.Files.Add(c);
        top.Files.Add(a);
        a.Files.Add(f);
        a.Files.Add(e);

        Assert.Equal(b.Size + c.Size + a.Size, top.Size);
        Assert.Equal(a.Size, f.Size);

        Assert.Equal(b, top.GetByName("b.txt"));
        Assert.Equal(e, top.GetByName("e"));

        output.WriteLine(top.PrintStructure());
    }

    [Theory]
    [InlineData(@"2022/Inputs/Day7Example.txt", 100000, 95437, 70000000, 24933642)]
    [InlineData(@"2022/Inputs/Day7.txt", 100000, 1517599, 70000000, 2481982)]
    public void Day7(string filename, int totalSize, int expectedTotalSizeLarger, int totalSpace, int expectedSmallestDirectory)
    {
        var input = Utility.ReadFile(filename);

        var problem = new Day7(input);

        Assert.Equal(expectedTotalSizeLarger, problem.TotalSizeLarger(totalSize));
        Assert.Equal(expectedSmallestDirectory,problem.FindSmallestDirectory(totalSpace, 30000000));
    }

    [Theory]
    [InlineData("[1,1,3,1,1]")]
    [InlineData("[1,1,5,1,1]")]
    [InlineData("[[1],[2,3,4]]")]
    [InlineData("[[1],4]")]
    [InlineData("[9]")]
    [InlineData("[[8,7,6]]")]
    [InlineData("[[4,4],4,4]")]
    [InlineData("[[4,4],4,4,4]")]
    [InlineData("[7,7,7,7]")]
    [InlineData("[7,7,7]")]
    [InlineData("[]")]
    [InlineData("[3]")]
    [InlineData("[[[]]]")]
    [InlineData("[[]]")]
    [InlineData("[1,[2,[3,[4,[5,6,7]]]],8,9]")]
    [InlineData("[1,[2,[3,[4,[5,6,0]]]],8,9]")]    
    public void JSONTest(string input)
    {

        var problem = new Day13(input);
    }

    [Theory]
    //[InlineData("[1,1,3,1,1]", "[1,1,5,1,1]", true)]
    [InlineData("[[1],[2,3,4]]", "[[1],4]", true)]
    public void Day13PacketComparerTest(string left, string right, bool expectedInRightOrder)
    {
        var leftNode = JsonNode.Parse(left)!;
        var rightNode = JsonNode.Parse(right)!;
        Day13.Packet packet = new Day13.Packet(leftNode, rightNode);

        Assert.Equal(expectedInRightOrder, packet.IsInRightOrder);
    }
}