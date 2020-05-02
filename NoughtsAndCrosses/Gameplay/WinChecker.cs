namespace NoughtsAndCrosses
{
    public static class WinChecker
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
    }
}
