using System.Runtime.CompilerServices;

namespace NoughtsAndCrosses
{
    public interface IPlayer
    {
        SquareState SquareOccupied { get; }

        Square[,] PlayerInput(Square[,] board);

        string WinMessage { get; }
    }
}
