using System.Collections.Generic;

namespace NoughtsAndCrosses
{
    public static class GameplayHelper
    {
        public static bool CheckForWin(Square[,] board, SquareState player)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (board[0, i].State.Equals(player) && board[1, i].State.Equals(player) && board[2, i].State.Equals(player)) return true;
            }

            for (int j = 0; j <= 2; j++)
            {
                if (board[j, 0].State.Equals(player) && board[j, 1].State.Equals(player) && board[j, 2].State.Equals(player)) return true;
            }

            if (board[0, 0].State.Equals(player) && board[1, 1].State.Equals(player) && board[2, 2].State.Equals(player)) return true;

            if (board[0, 2].State.Equals(player) && board[1, 1].State.Equals(player) && board[2, 0].State.Equals(player)) return true;

            return false;
        }

        public static List<int[]> ListEmptySquares(Square[,] board)
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

        public static int[] CheckForWinningSquare(Square[,] board, List<int[]> availableMoves, SquareState player)
        {
            foreach (var square in availableMoves)
            {
                board[square[0], square[1]].State = player;
                bool playerCanWin = CheckForWin(board, player);
                board[square[0], square[1]].State = SquareState.Empty;
                if (playerCanWin) return square;
            }
            return null;
        }
    }
}
