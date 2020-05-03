namespace NoughtsAndCrosses
{
    public class Board
    {
        public Board()
        {
            Squares = new Square[3, 3];
            int squareCount = 1;

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    Squares[x, y] = new Square
                    {
                        State = SquareState.Empty,
                        DisplayCharacter = squareCount.ToString()
                    };
                    squareCount++;
                }
            }
        }

        public Square[,] Squares { get; set; }
    }
}
