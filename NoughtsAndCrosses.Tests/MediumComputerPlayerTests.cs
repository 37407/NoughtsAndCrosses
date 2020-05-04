using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NoughtsAndCrosses.Tests
{
    public class MediumComputerPlayerTests
    {
        [Fact]
        public void MediumComputerPlayer_PlayerInput_ReturnsBoard_OneDisplayCharacterMatchesComputerPlayerSymbol()
        {
            var board = new Board();
            var player = new MediumComputerPlayer();
            var actual = player.PlayerInput(board.Squares);

            var actualSquareSymbols = new List<string>();

            foreach (var square in actual)
            {
                actualSquareSymbols.Add(square.DisplayCharacter);
            }

            Assert.Equal(9, actualSquareSymbols.Count);
            Assert.Contains("O", actualSquareSymbols);
            Assert.Single(actualSquareSymbols.Where(x => x.Equals("O")));
        }

        [Fact]
        public void MediumComputerPlayer_PlayerInput_ReturnsBoard_OneSquareStateMatchesComputerPlayerState()
        {
            var board = new Board();
            var player = new MediumComputerPlayer();
            var actual = player.PlayerInput(board.Squares);

            var actualSquareStates = new List<SquareState>();

            foreach (var square in actual)
            {
                actualSquareStates.Add(square.State);
            }

            Assert.Equal(9, actualSquareStates.Count);
            Assert.Contains(SquareState.O, actualSquareStates);
            Assert.Single(actualSquareStates.Where(x => x.Equals(SquareState.O)));
        }

        [Theory]
        [InlineData(0, 0, 0, 1, 2, 2, 1, 2, 0, 2)]
        [InlineData(0, 0, 1, 0, 0, 1, 1, 1, 2, 0)]
        [InlineData(0, 0, 1, 1, 2, 0, 2, 1, 2, 2)]
        public void MediumComputerPlayer_ComputerAndHumanCanWin_ComputerPlaysWinningMove(int col1, int row1, int col2, int row2, int col3, int row3, int col4, int row4, int expectedCol, int expectedRow)
        {
            var board = new Board();
            board.Squares[col1, row1].State = SquareState.O;
            board.Squares[col2, row2].State = SquareState.O;
            board.Squares[col3, row3].State = SquareState.X;
            board.Squares[col4, row4].State = SquareState.X;

            Assert.Equal(SquareState.Empty, board.Squares[expectedCol, expectedRow].State);

            var player = new MediumComputerPlayer();
            var actual = player.PlayerInput(board.Squares);

            Assert.Equal(SquareState.O, actual[expectedCol, expectedRow].State);
        }

        [Theory]
        [InlineData(0, 0, 0, 1, 2, 2, 1, 0, 0, 2)]
        [InlineData(0, 0, 1, 0, 2, 2, 0, 1, 2, 0)]
        [InlineData(0, 0, 1, 1, 2, 0, 0, 1, 2, 2)]
        public void MediumComputerPlayer_ComputerCanWinButHumanCannot_ComputerPlaysWinningMove(int col1, int row1, int col2, int row2, int col3, int row3, int col4, int row4, int expectedCol, int expectedRow)
        {
            var board = new Board();
            board.Squares[col1, row1].State = SquareState.O;
            board.Squares[col2, row2].State = SquareState.O;
            board.Squares[col3, row3].State = SquareState.X;
            board.Squares[col4, row4].State = SquareState.X;

            Assert.Equal(SquareState.Empty, board.Squares[expectedCol, expectedRow].State);

            var player = new MediumComputerPlayer();
            var actual = player.PlayerInput(board.Squares);

            Assert.Equal(SquareState.O, actual[expectedCol, expectedRow].State);
        }

        [Theory]
        [InlineData(2, 2, 1, 0, 0, 0, 0, 1, 0, 2)]
        [InlineData(2, 2, 0, 1, 0, 0, 1, 0, 2, 0)]
        [InlineData(2, 0, 1, 2, 0, 0, 1, 1, 2, 2)]
        public void MediumComputerPlayer_HumanCanWinButComputerCannon_ComputerBlocksHumanWin(int col1, int row1, int col2, int row2, int col3, int row3, int col4, int row4, int expectedCol, int expectedRow)
        {
            var board = new Board();
            board.Squares[col1, row1].State = SquareState.O;
            board.Squares[col2, row2].State = SquareState.O;
            board.Squares[col3, row3].State = SquareState.X;
            board.Squares[col4, row4].State = SquareState.X;

            Assert.Equal(SquareState.Empty, board.Squares[expectedCol, expectedRow].State);

            var player = new MediumComputerPlayer();
            var actual = player.PlayerInput(board.Squares);

            Assert.Equal(SquareState.O, actual[expectedCol, expectedRow].State);
        }

        [Theory]
        [InlineData(0, 0, 2, 1, 2, 2, 0, 1)]
        [InlineData(0, 0, 1, 2, 2, 2, 1, 0)]
        public void MediumComputerPlayer_NeitherComputerNorHumanCanWin_ComputerMakesMove(int col1, int row1, int col2, int row2, int col3, int row3, int col4, int row4)
        {
            var board = new Board();
            board.Squares[col1, row1].State = SquareState.O;
            board.Squares[col2, row2].State = SquareState.O;
            board.Squares[col3, row3].State = SquareState.X;
            board.Squares[col4, row4].State = SquareState.X;

            List<int[]> emptySquaresBeforeMove = GameplayHelper.ListEmptySquares(board.Squares);
            Assert.Equal(5, emptySquaresBeforeMove.Count);

            var player = new MediumComputerPlayer();
            var actual = player.PlayerInput(board.Squares);

            List<int[]> emptySquaresAfterMove = GameplayHelper.ListEmptySquares(actual);
            Assert.Equal(4, emptySquaresAfterMove.Count);
        }
    }
}
