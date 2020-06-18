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

            Board moveBoard = CloneBoard(board);

            var moves = GameplayHelper.ListEmptySquares(moveBoard.Squares);

            foreach (var move in moves)
            {
                _scores.Add(move, 0);
                Maximise(moveBoard.Squares, move, this.SquareOccupied, 0);
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

        private static SquareState SwitchPlayer(SquareState player)
        {
            return player switch
            {
                SquareState.O => SquareState.X,
                SquareState.X => SquareState.O,
                _ => throw new InvalidOperationException($"Player cannot be switched - input Squarestate is {player}"),
            };
        }

        private void Maximise(Square[,] board, int[] currentMove, SquareState playerO, int depth)
        {
            var currentMoveBoard = CloneBoard(board);
            currentMoveBoard.Squares[currentMove[0], currentMove[1]].State = playerO;

            if (GameplayHelper.CheckForWin(currentMoveBoard.Squares, playerO))
            {
                _scores[currentMove] = 10 - depth;
                //or return this as the move to play?
            }

            var playerX = SwitchPlayer(playerO);
            var nextAvailableMoves = GameplayHelper.ListEmptySquares(currentMoveBoard.Squares);
            depth++;

            if (nextAvailableMoves.Count != 0)
            {
                foreach (var nextMove in nextAvailableMoves)
                {
                    var nextMoveBoard = CloneBoard(currentMoveBoard.Squares);
                    Minimise(nextMoveBoard.Squares, nextMove, playerX, depth);
                }
            }
            else
            {
                _scores[currentMove] = 0;
            }
        }

        private void Minimise(Square[,] board, int[] currentMove, SquareState playerX, int depth)
        {
            var currentMoveBoard = CloneBoard(board);
            currentMoveBoard.Squares[currentMove[0], currentMove[1]].State = playerX;

            if (GameplayHelper.CheckForWin(currentMoveBoard.Squares, playerX))
            {
                _scores[currentMove] = depth - 10;
                // or return this as the move to play?
            }

            var playerO = SwitchPlayer(playerX);
            var nextAvailableMoves = GameplayHelper.ListEmptySquares(currentMoveBoard.Squares);
            depth++;

            if (nextAvailableMoves.Count != 0)
            {
                foreach (var nextMove in nextAvailableMoves)
                {
                    var nextMoveBoard = CloneBoard(currentMoveBoard.Squares);
                    Maximise(nextMoveBoard.Squares, nextMove, playerO, depth);
                }
            }
            else
            {
                _scores[currentMove] = 0;
            }
        }
    }
}