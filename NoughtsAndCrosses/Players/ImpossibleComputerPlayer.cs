using System;
using System.Collections.Generic;
using System.Linq;

namespace NoughtsAndCrosses
{
    public class ImpossibleComputerPlayer : IPlayer
    {
        public SquareState SquareOccupied => SquareState.O;

        public string DisplayCharacter => "O";

        public string WinMessage => "Player O wins!";

        private Dictionary<int[], int> _scores;

        public Square[,] PlayerInput(Square[,] board)
        {
            Console.WriteLine("Player O's turn");

            _scores = new Dictionary<int[], int>();

            var freeSquares = GameplayHelper.ListEmptySquares(board);

            foreach (var square in freeSquares)
            {
                Board moveBoard = CloneBoard(board);
                moveBoard.Squares[square[0], square[1]].State = SquareState.O;
                var moveScore = MinMax(moveBoard.Squares, SquareState.X, 0);
                _scores.Add(square, moveScore);
            }

            var optimalMove = _scores.OrderByDescending(score => score.Value).First();

            board[optimalMove.Key[0], optimalMove.Key[1]].State = this.SquareOccupied;
            board[optimalMove.Key[0], optimalMove.Key[1]].DisplayCharacter = this.DisplayCharacter;
            return board;
        }

        private static Board CloneBoard(Square[,] board)
        {
            var moveBoard = new Board();

            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    moveBoard.Squares[i, j].DisplayCharacter = board[i, j].DisplayCharacter;
                    moveBoard.Squares[i, j].State = board[i, j].State;
                }
            }

            return moveBoard;
        }

        private int MinMax(Square[,] boardForCurrentMove, SquareState player, int depth)
        {
            var availableMoves = GameplayHelper.ListEmptySquares(boardForCurrentMove);

            int score = 0;

            if (availableMoves.Count == 0) return score;

            foreach (var move in availableMoves)
            {
                boardForCurrentMove[move[0], move[1]].State = player;
                if (GameplayHelper.CheckForWin(boardForCurrentMove, player))
                {
                    switch (player)
                    {
                        case SquareState.X:
                            score = depth - 10;
                            break;
                        case SquareState.O:
                            score = 10 - depth;
                            break;
                    }
                }
                else
                {
                    depth++;
                    var boardForNextMove = CloneBoard(boardForCurrentMove);
                    switch (player)
                    {
                        case SquareState.X:
                            player = SquareState.O;
                            MinMax(boardForNextMove.Squares, player, depth);
                            break;
                        case SquareState.O:
                            player = SquareState.X;
                            MinMax(boardForNextMove.Squares, player, depth);
                            break;
                    }
                }
            }

            return score;
        }
    }
}