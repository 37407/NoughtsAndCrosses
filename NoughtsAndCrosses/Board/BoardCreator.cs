namespace NoughtsAndCrosses
{
    public class BoardCreator
    {
        public Square[,] Board { get; set; }

        public BoardCreator()
        {
            Board = new Square[3, 3];
            int squareCount = 1;

            for (int x = 0; x <= 2; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    Board[x, y] = new Square
                    {
                        State = SquareState.Empty,
                        DisplayCharacter = squareCount.ToString()
                    };
                    squareCount++;
                }
            }
        }
    }
}
