using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsAndCrosses
{
    public class ImpossibleComputerPlayer : IPlayer
    {
        public SquareState SquareOccupied => SquareState.O;

        public string DisplayCharacter => "O";

        public string WinMessage => "Player O wins!";

        public Square[,] PlayerInput(Square[,] board)
        {
            Console.WriteLine("Player O's turn");

            throw new NotImplementedException();

            //max calculation for SquareState.O
            //min calculation for SquareState.X

            //for board
            //int depth = 0;
            //int score = 0
            //get available moves
            //generate a board for each move in availableMoves
            //foreach of the boards
            //play the move as this.SquareState
            //check for win - if win, score = score + (10-depth)
            //if not win, score +0 depth +1

            //foreach board with score = 0
            //get available moves
            //generate a board for each move in availableMoves
            //switch to opponent SquareState
            //foreach of the boards
            //play move as opponent SquareState
            //check for win - if win, score -10
            //if not win, score +0

            //foreach board with score = 0
            //generate a board for each move in availableMoves
            //get available moves
            //switch to this.SquareState
            //check for win - if win - score +10
            // if not win, score +0

            //etc.
        }
    }
}
