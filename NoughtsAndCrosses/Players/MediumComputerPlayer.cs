using System;
using System.Collections.Generic;

namespace NoughtsAndCrosses
{
    public class MediumComputerPlayer : IPlayer
    {
        public SquareState SquareOccupied => SquareState.O;

        public string DisplayCharacter => "O";

        public string WinMessage => "Player O wins!";

        public Square[,] PlayerInput(Square[,] board)
        {
            var availableMoves = ListEmptySquares(board);

            var computerWin = CheckForWinningSquare(board, availableMoves, SquareState.O);
            if (computerWin != null)
            {
                board[computerWin[0], computerWin[1]].State = this.SquareOccupied;
                board[computerWin[0], computerWin[1]].DisplayCharacter = this.DisplayCharacter;
                return board;
            }

            var humanWin = CheckForWinningSquare(board, availableMoves, SquareState.X);
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

        private List<int[]> ListEmptySquares(Square[,] board)
        {
            List<int[]> emptySquares = new List<int[]>();
            for (int y = 0; y <= 2; y++)
            {
                for (int x = 0; x <= 2; x++)
                {
                    if (board[y, x].State == SquareState.Empty)
                    {
                        emptySquares.Add(new int[] { y, x });
                    }
                }
            }
            return emptySquares;
        }

        private int[] CheckForWinningSquare(Square[,] board, List<int[]> availableMoves, SquareState player)
        {
            foreach (var square in availableMoves)
            {
                board[square[0], square[1]].State = player;
                bool playerCanWin = WinChecker.CheckForWin(board, player);
                board[square[0], square[1]].State = SquareState.Empty;
                if (playerCanWin) return square;
            }
            return null;
        }
    }
}
