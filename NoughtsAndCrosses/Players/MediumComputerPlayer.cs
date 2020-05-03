using System;

namespace NoughtsAndCrosses
{
    public class MediumComputerPlayer : IPlayer
    {
        public SquareState SquareOccupied => SquareState.O;

        public string DisplayCharacter => "O";

        public string WinMessage => "Player O wins!";

        public Square[,] PlayerInput(Square[,] board)
        {
            var availableMoves = GameplayHelper.ListEmptySquares(board);

            var computerWin = GameplayHelper.CheckForWinningSquare(board, availableMoves, SquareState.O);
            if (computerWin != null)
            {
                board[computerWin[0], computerWin[1]].State = this.SquareOccupied;
                board[computerWin[0], computerWin[1]].DisplayCharacter = this.DisplayCharacter;
                return board;
            }

            var humanWin = GameplayHelper.CheckForWinningSquare(board, availableMoves, SquareState.X);
            if (humanWin != null)
            {
                board[humanWin[0], humanWin[1]].State = this.SquareOccupied;
                board[humanWin[0], humanWin[1]].DisplayCharacter = this.DisplayCharacter;
                return board;
            }

            var random = new Random();
            bool turnComplete = false;
            while (!turnComplete)
            {
                var xCoord = random.Next(board.GetLength(0));
                var yCoord = random.Next(board.GetLength(1));
                if (board[xCoord, yCoord].State.Equals(SquareState.Empty))
                {
                    board[xCoord, yCoord].State = this.SquareOccupied;
                    board[xCoord, yCoord].DisplayCharacter = this.DisplayCharacter;
                    turnComplete = true;
                }
            }
            return board;
        }
    }
}
