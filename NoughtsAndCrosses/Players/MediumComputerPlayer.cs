using System;
using System.Collections.Generic;

namespace NoughtsAndCrosses
{
    public class MediumComputerPlayer : IPlayer
    {
        public SquareState SquareOccupied => SquareState.O;

        public string WinMessage => "Player O wins!";

        public Square[,] PlayerInput(Square[,] board)
        {
            bool turnComplete = false;
            var availableMoves = ListEmptySquares(board);

            foreach (var square in availableMoves)
            {
                bool computerCanWin = DetermineOutcomeOfMove(board, square, SquareState.O);
                if (computerCanWin && !turnComplete)
                {
                    board[square[0], square[1]].State = SquareState.O;
                    board[square[0], square[1]].DisplayCharacter = "O";
                    turnComplete = true;
                    break;
                }
            }

            foreach (var square in availableMoves)
            {
                bool playerCanWin = DetermineOutcomeOfMove(board, square, SquareState.X);
                if (playerCanWin && !turnComplete)
                {
                    board[square[0], square[1]].State = SquareState.O;
                    board[square[0], square[1]].DisplayCharacter = "O";
                    turnComplete = true;
                    break;
                }
            }

            if (!turnComplete)
            {
                var random = new Random();
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
                    if (board[x, y].State == SquareState.Empty)
                    {
                        emptySquares.Add(new int[] { x, y });
                    }
                }
            }
            return emptySquares;
        }

        private bool DetermineOutcomeOfMove(Square[,] board, int[] emptySquare, SquareState player)
        {
            var theoreticalBoard = new Board { Squares = board };
            theoreticalBoard.Squares[emptySquare[0], emptySquare[1]].State = player;
            return WinChecker.CheckForWin(theoreticalBoard.Squares, player);
        }
    }
}
