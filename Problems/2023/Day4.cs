using System.Net;
using System.Text.RegularExpressions;
using Utilities;

namespace AOC2023;

public class Day4
{
    public List<ScratchCard> Cards { get; set; } = new List<ScratchCard>();

    public Day4(string input)
    {
        foreach (var card in input.Split("\n"))
        {
            var cleanedCard = card.ReplaceRecursive("  ", " ");
            var cardMatch = Regex.Match(cleanedCard, @"Card (\d+): (.*)");
            var cardNumber = int.Parse(cardMatch.Groups[1].Value);
            var cardNumbers = cardMatch.Groups[2].Value.Split('|');
            var winningNumbers = cardNumbers[0].Replace("  ", " ").Trim(' ').Split(' ').Select(int.Parse).ToList();
            var numbers = cardNumbers[1].Replace("  ", " ").Trim(' ').Split(' ').Select(int.Parse).ToList();
            Cards.Add(new ScratchCard(cardNumber, numbers, winningNumbers));
        }

        foreach (var winningCard in Cards.Where(c => c.Matches > 0))
        {
            Cards.Where(c => c.CardNumber <= winningCard.CardNumber + winningCard.Matches && c.CardNumber > winningCard.CardNumber).ToList().ForEach(c => c.IncreaseCopies(winningCard.Copies));
        }
    }

    public double Solve1() => Cards.Sum(c => c.Score);
    public double Solve2() => Cards.Sum(c => c.Copies);

    public class ScratchCard
    {
        public int CardNumber { get; set; }
        public List<int> Numbers { get; set; } = new List<int>();

        public List<int> WinningNumbers { get; set; } = new List<int>();

        public List<int> MatchingNumbers => Numbers.Intersect(WinningNumbers).ToList();

        public int Matches => MatchingNumbers.Count();

        public double Score => Matches == 0 ? 0 : Math.Pow(2, Matches - 1);

        public int Copies = 1;

        public ScratchCard() { }

        public ScratchCard(int CardNumber, List<int> numbers, List<int> winningNumbers)
        {
            this.CardNumber = CardNumber;
            Numbers = numbers;
            WinningNumbers = winningNumbers;
        }

        public void IncreaseCopies(int increase) => Copies += increase;

        public override string ToString() => $"Card {CardNumber}: {string.Join(" ", Numbers)} | Matches: {Matches} | Score: {Score} | Copies: {Copies} | {string.Join(" ", WinningNumbers)}";
    }
}
