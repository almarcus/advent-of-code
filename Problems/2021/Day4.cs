namespace AOC2021;

using System.Linq;
public class Day4
{
    public class Square
    {
        public int Row {get;set;}

        public int Column {get;set;}

        public int Value {get; init;}

        public bool Picked{ get; set;} = false;

        public Square()
        {

        }
    }

    public class Board
    {
        List<Square> Squares = new List<Square>();
        
        public int WinningNumber;
        
        public Board(List<string> input)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int column = 0; column < 5; column++)
                {
                    Squares.Add(new Square { Row = row, Column = column, Value = Int32.Parse(input[row].Split(' ', StringSplitOptions.RemoveEmptyEntries).GetValue(column).ToString())});
                }
            }
        }

        public void MarkNumber(int pickedNumber)
        {
            if (IsWinner) return;
            
            foreach (Square s in Squares)
            {
                if (s.Value == pickedNumber) s.Picked = true;
            }

            if (IsWinner) WinningNumber = pickedNumber;
        }

        public bool IsWinner
        {
            get
            {
                return GetWinningLine() != null;
            }
        }

        public List<Square>? GetWinningLine()
        {
            for(int i= 0; i<5; i++)
            {
                List<Square> rowSquares = Squares.Where(x => x.Row == i).ToList();
                List<Square> columnSquares = Squares.Where(x => x.Column == i).ToList();

                if (rowSquares.Where(x => x.Picked).Count() == 5) return rowSquares;
                if (columnSquares.Where(x => x.Picked).Count() == 5) return columnSquares;
            }

            return null;
        }

        public int? WinningSum => Squares.Where(x => !x.Picked).Sum(x => x.Value);

        public int? WinningScore => WinningSum * WinningNumber;
    }

    public List<Board> Boards = new List<Board>();
    List<string> chosenNumbers = new List<string>();

    void MarkBoards(int chosenNumber)
    {
        foreach (Board b in Boards)
        {
            b.MarkNumber(chosenNumber);
        }
    }

    public Day4(string input)
    {
        List<string> lines = input.Split("\n\n").ToList();
        chosenNumbers = lines[0].Split(',').ToList();

        var boards = lines.GetRange(1, lines.Count - 1).Select(x => x.Split("\n").ToList());
        foreach (var board in boards)
        {
            Boards.Add(new Board(board));
        }


    }

    public int Solve(bool getWinningBoard = true)
    {
        List<Board> boardWinners = new();
        foreach (string chosenNumber in chosenNumbers)
        {
            int convertedNumber = Int32.Parse(chosenNumber);
            MarkBoards(convertedNumber);

            boardWinners.AddRange(Boards.Where(b => b.IsWinner && b.WinningNumber == convertedNumber));
        }

        
        if (getWinningBoard) return boardWinners.FirstOrDefault().WinningScore.Value;
        else return boardWinners.LastOrDefault().WinningScore.Value;

        
    }
    
}