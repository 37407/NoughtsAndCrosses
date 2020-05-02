using Xunit;

namespace NoughtsAndCrosses.Tests
{
    public class WinCheckerTests
    {
        [Theory]
        [InlineData(1, 0, 1, 1, 1, 2, true)]
        [InlineData(0, 1, 1, 1, 2, 1, true)]
        [InlineData(0, 0, 1, 1, 2, 2, true)]
        [InlineData(0, 2, 1, 1, 2, 0, true)]
        [InlineData(0, 0, 0, 1, 2, 0, false)]
        public void WinChecker_CheckForWin_ReturnsTrueForWin(int firstColumn, int firstRow, int secondColumn, int secondRow, int thirdColumn, int thirdRow, bool isWin)
        {
            var board = new Board();
            board.Squares[firstColumn, firstRow].State = SquareState.X;
            board.Squares[secondColumn, secondRow].State = SquareState.X;
            board.Squares[thirdColumn, thirdRow].State = SquareState.X;

            bool actual = WinChecker.CheckForWin(board.Squares, SquareState.X);

            Assert.Equal(isWin, actual);
        }
    }
}
