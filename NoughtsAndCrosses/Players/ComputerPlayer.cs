using System;

namespace NoughtsAndCrosses
{
    public class ComputerPlayer : IPlayer
    {
        public SquareState SquareOccupied => SquareState.O;

        public string WinMessage => "Player O wins!";

        public Square[,] PlayerInput(Square[,] board)
        {
            Console.WriteLine("Player O's turn");
            var random = new Random();
            bool turnComplete = false;
            while (!turnComplete)
            {
                var xCoord = random.Next(board.GetLength(0));
                var yCoord = random.Next(board.GetLength(1));
                if (board[xCoord, yCoord].State.Equals(SquareState.Empty))
                {
                    board[xCoord, yCoord].State = SquareState.O;
                    board[xCoord, yCoord].DisplayCharacter = "O";
                    turnComplete = true;
                }
            }
            return board;
        }
    }
}
