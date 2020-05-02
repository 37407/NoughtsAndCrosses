using Xunit;

namespace NoughtsAndCrosses.Tests
{
    public class BoardTests
    {
        [Fact]
        public void Board_Created_TypeIsCorrect()
        {
            var actual = new Board();
            Assert.IsType<Square[,]>(actual.Squares);
        }

        [Fact]
        public void Board_Created_DimensionsAreCorrect()
        {
            var actual = new Board();
            Assert.Equal(9, actual.Squares.Length);
            Assert.Equal(3, actual.Squares.GetLength(0));
            Assert.Equal(3, actual.Squares.GetLength(1));
        }

        [Fact]
        public void Board_Created_AllSquaresHaveEmptyState()
        {
            var actual = new Board();
            foreach (var square in actual.Squares)
            {
                Assert.IsType<Square>(square);
                Assert.Equal(SquareState.Empty, square.State);
            }
        }

        [Fact]
        public void Board_Created_SquaresAreNumberedCorrectly()
        {
            var actual = new Board();
            var expectedDisplayCharacters = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            int squareCount = 0;
            foreach (var square in actual.Squares)
            {
                Assert.Equal(expectedDisplayCharacters[squareCount], square.DisplayCharacter);
                squareCount++;
            }
        }
    }
}
