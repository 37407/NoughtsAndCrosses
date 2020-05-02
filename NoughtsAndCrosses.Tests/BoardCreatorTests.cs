using Xunit;

namespace NoughtsAndCrosses.Tests
{
    public class BoardCreatorTests
    {
        [Fact]
        public void BoardCreator_CreatesBoard_TypeIsCorrect()
        {
            var actual = new BoardCreator();
            Assert.IsType<Square[,]>(actual.Board);
        }

        [Fact]
        public void BoardCreator_CreatesBoard_DimensionsAreCorrect()
        {
            var actual = new BoardCreator();
            Assert.Equal(9, actual.Board.Length);
            Assert.Equal(3, actual.Board.GetLength(0));
            Assert.Equal(3, actual.Board.GetLength(1));
        }

        [Fact]
        public void BoardCreator_CreatesBoard_AllSquaresHaveEmptyState()
        {
            var actual = new BoardCreator();
            foreach (var square in actual.Board)
            {
                Assert.IsType<Square>(square);
                Assert.Equal(SquareState.Empty, square.State);
            }
        }

        [Fact]
        public void BoardCreator_CreatesBoard_SquaresAreNumberedCorrectly()
        {
            var actual = new BoardCreator();
            var expectedDisplayCharacters = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int squareCount = 0;
            foreach (var square in actual.Board)
            {
                Assert.Equal(expectedDisplayCharacters[squareCount], square.DisplayCharacter);
                squareCount++;
            }
        }
    }
}
