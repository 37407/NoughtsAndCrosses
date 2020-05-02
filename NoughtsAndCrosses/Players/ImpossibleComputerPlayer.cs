using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsAndCrosses
{
    public class ImpossibleComputerPlayer : IPlayer
    {
        public SquareState SquareOccupied => SquareState.O;

        public string WinMessage => "Player O wins!";

        public Square[,] PlayerInput(Square[,] board)
        {
            throw new NotImplementedException();
        }
    }
}
