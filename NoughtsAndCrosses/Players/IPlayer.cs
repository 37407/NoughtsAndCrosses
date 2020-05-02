namespace NoughtsAndCrosses
{
    public interface IPlayer
    {
        SquareState SquareOccupied { get; }

        string WinMessage { get; }

        Square[,] PlayerInput(Square[,] board);
    }
}
