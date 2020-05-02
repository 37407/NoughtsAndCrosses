using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsAndCrosses
{
    public class ImpossibleComputerPlayer : IPlayer
    {
        public SquareState SquareOccupied => throw new NotImplementedException();

        public string WinMessage => throw new NotImplementedException();

        public Square[,] PlayerInput(Square[,] board)
        {
            throw new NotImplementedException();
        }
    }
}
