using Utilities;

namespace AOC2022;

public class Day4
{
    public List<(Elf elf1, Elf elf2)> ElfPairs = new();
    public class Elf
    {
        public List<int> Sections = new();

        public Elf(string sections)
        {
            var sectionsStartAndEnd = sections.Split('-');
            Sections =  Utility.Range(int.Parse(sectionsStartAndEnd[0]), int.Parse(sectionsStartAndEnd[1])).ToList();
        }
    }

    public Day4(string input)
    {
        foreach(string elfPairs in input.Split('\n', StringSplitOptions.RemoveEmptyEntries))
        {
            var elves = elfPairs.Split(',');

            var firstElf = new Elf(elves.First());
            var secondElf = new Elf(elves.Last());

            ElfPairs.Add((firstElf, secondElf));
        }
    }

    public int Solve()
    {
        return ElfPairs.Where(x => (x.elf1.Sections.Intersect(x.elf2.Sections).Count() == x.elf1.Sections.Count
                                || x.elf2.Sections.Intersect(x.elf1.Sections).Count() == x.elf2.Sections.Count)).Count();
    }
    
}