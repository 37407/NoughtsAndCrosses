using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
