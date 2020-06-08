using System;
using System.Collections.Generic;
using System.Linq;

namespace NoughtsAndCrosses
{
    public class HardComputerPlayer : IPlayer
    {
        public SquareState SquareOccupied => SquareState.O;

        public string DisplayCharacter => "O";

        public string WinMessage => "Player O wins!";

        public Square[,] PlayerInput(Square[,] board)
        {
            Console.WriteLine("Player O's turn");
            var availableMoves = GameplayHelper.ListEmptySquares(board);

            // if a winning move is available, make it
            var computerWin = GameplayHelper.CheckForWinningSquare(board, availableMoves, SquareState.O);
            if (computerWin != null)
            {
                board[computerWin[0], computerWin[1]].State = this.SquareOccupied;
                board[computerWin[0], computerWin[1]].DisplayCharacter = this.DisplayCharacter;
                return board;
            }

            // if opponent can win, block them
            var humanWin = GameplayHelper.CheckForWinningSquare(board, availableMoves, SquareState.X);
            if (humanWin != null)
            {
                board[humanWin[0], humanWin[1]].State = this.SquareOccupied;
                board[humanWin[0], humanWin[1]].DisplayCharacter = this.DisplayCharacter;
                return board;
            }

            // if centre square is free, choose it
            if (availableMoves.Any(square => square.SequenceEqual(new int[] { 1, 1 })))
            {
                board[1, 1].State = this.SquareOccupied;
                board[1, 1].DisplayCharacter = this.DisplayCharacter;
                return board;
            }

            // if a corner is free, choose it
            List<int[]> corners = new List<int[]> 
            { 
                new int[] { 0, 0 },
                new int[] { 0, 2 },
                new int[] { 2, 0 },
                new int[] { 2, 2 }
            };

            foreach (var square in corners)
            {
                if (availableMoves.Any(x => x.SequenceEqual(square)))
                {
                    board[square[0], square[1]].State = this.SquareOccupied;
                    board[square[0], square[1]].DisplayCharacter = this.DisplayCharacter;
                    return board;
                }
            }

            // pick a free square at random - should just be edges left
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
