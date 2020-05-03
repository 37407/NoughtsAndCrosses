using System.Collections.Generic;
using Xunit;

namespace NoughtsAndCrosses.Tests
{
    public class GameplayHelperTests
    {
        [Theory]
        [InlineData(1, 0, 1, 1, 1, 2, true)]
        [InlineData(0, 1, 1, 1, 2, 1, true)]
        [InlineData(0, 0, 1, 1, 2, 2, true)]
        [InlineData(0, 2, 1, 1, 2, 0, true)]
        [InlineData(0, 0, 0, 1, 2, 0, false)]
        public void CheckForWin_ReturnsTrueForWin_ReturnsFalseForNoWin(int firstColumn, int firstRow, int secondColumn, int secondRow, int thirdColumn, int thirdRow, bool isWin)
        {
            var board = new Board();
            board.Squares[firstColumn, firstRow].State = SquareState.X;
            board.Squares[secondColumn, secondRow].State = SquareState.X;
            board.Squares[thirdColumn, thirdRow].State = SquareState.X;

            bool actual = GameplayHelper.CheckForWin(board.Squares, SquareState.X);

            Assert.Equal(isWin, actual);
        }

        [Fact]
        public void ListEmptySquares_AllSquaresEmpty_ListContainsAllSquares()
        {
            var board = new Board();
            var expected = new List<int[]>
            {
                new int[] { 0, 0 },
                new int[] { 0, 1 },
                new int[] { 0, 2 },
                new int[] { 1, 0 },
                new int[] { 1, 1 },
                new int[] { 1, 2 },
                new int[] { 2, 0 },
                new int[] { 2, 1 },
                new int[] { 2, 2 },
            };

            var actual = GameplayHelper.ListEmptySquares(board.Squares);

            Assert.Equal(expected, actual);          
        }

        [Fact]
        public void ListEmptySquares_AllSquaresFilled_ReturnsEmptyList()
        {
            var board = new Board();
            foreach (var square in board.Squares)
            {
                square.State = SquareState.O;
            }

            var actual = GameplayHelper.ListEmptySquares(board.Squares);

            Assert.Empty(actual);
        }

        [Fact]
        public void ListEmptySquares_SomeSquaresFilled_ListContainsOnlyEmptySquares()
        {
            var board = new Board();

            board.Squares[0, 1].State = SquareState.O;
            board.Squares[0, 0].State = SquareState.O;
            board.Squares[1, 1].State = SquareState.X;
            board.Squares[2, 0].State = SquareState.X;

            var expected = new List<int[]>
            {
                new int[] { 0, 2 },
                new int[] { 1, 0 },
                new int[] { 1, 2 },
                new int[] { 2, 1 },
                new int[] { 2, 2 },
            };

            var actual = GameplayHelper.ListEmptySquares(board.Squares);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckForWinningSquare_WinIsPossible_ReturnsCorrectResult()
        {
            var expected = new int[] { 0, 1 };
            Board board = new Board();
            board.Squares[0, 0].State = SquareState.X;
            board.Squares[0, 2].State = SquareState.X;
            List<int[]> availableMoves = GameplayHelper.ListEmptySquares(board.Squares);

            var actual = GameplayHelper.CheckForWinningSquare(board.Squares, availableMoves, SquareState.X);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CheckForWinningSquare_WinIsNotPossible_ReturnsNull()
        {
            Board board = new Board();
            board.Squares[2, 2].State = SquareState.X;
            List<int[]> availableMoves = GameplayHelper.ListEmptySquares(board.Squares);

            var actual = GameplayHelper.CheckForWinningSquare(board.Squares, availableMoves, SquareState.X);

            Assert.Null(actual);
        }
    }
}
