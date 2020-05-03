namespace NoughtsAndCrosses
{
    public interface IPlayer
    {
        SquareState SquareOccupied { get; }

        string DisplayCharacter { get; }

        string WinMessage { get; }

        Square[,] PlayerInput(Square[,] board);
    }
}
