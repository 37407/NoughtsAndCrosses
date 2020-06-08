using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NoughtsAndCrosses.Tests
{
    public class HardComputerPlayerTests
    {
        [Fact]
        public void HardComputerPlayer_CentreSquareAvailable_PrioritisesWin()
        {
            var board = new Board();
            board.Squares[0, 0].State = SquareState.O;
            board.Squares[0, 1].State = SquareState.O;
            var player = new HardComputerPlayer();

            var actual = player.PlayerInput(board.Squares);

            Assert.Equal(SquareState.O, actual[0, 2].State);
            Assert.Equal("O", actual[0, 2].DisplayCharacter);
            Assert.Equal(SquareState.Empty, actual[1, 1].State);
            Assert.Equal("5", actual[1, 1].DisplayCharacter);
        }

        [Fact]
        public void HardComputerPlayer_CentreSquareAvailable_PrioritisesBlockingOpponentWin()
        {
            var board = new Board();
            board.Squares[0, 0].State = SquareState.X;
            board.Squares[0, 1].State = SquareState.X;
            var player = new HardComputerPlayer();

            var actual = player.PlayerInput(board.Squares);

            Assert.Equal(SquareState.O, actual[0, 2].State);
            Assert.Equal("O", actual[0, 2].DisplayCharacter);
            Assert.Equal(SquareState.Empty, actual[1, 1].State);
            Assert.Equal("5", actual[1, 1].DisplayCharacter);
        }

        [Fact]
        public void HardComputerPlayer_CentreSquareAvailable_PrioritisesWinOverLossAndCentre()
        {
            var board = new Board();
            board.Squares[0, 0].State = SquareState.O;
            board.Squares[0, 1].State = SquareState.O;
            board.Squares[2, 1].State = SquareState.X;
            board.Squares[2, 2].State = SquareState.X;

            var player = new HardComputerPlayer();

            var actual = player.PlayerInput(board.Squares);

            Assert.Equal(SquareState.O, actual[0, 2].State);
            Assert.Equal("O", actual[0, 2].DisplayCharacter);
            Assert.Equal(SquareState.Empty, actual[1, 1].State);
            Assert.Equal("5", actual[1, 1].DisplayCharacter);
        }

        [Fact]
        public void HardComputerPlayer_NoWinOrLossImminent_ChoosesCentreSquare()
        {
            var board = new Board();
            var player = new HardComputerPlayer();
            var actual = player.PlayerInput(board.Squares);

            var actualSquareStates = new List<SquareState>();

            foreach (var square in actual)
            {
                actualSquareStates.Add(square.State);
            }

            Assert.Equal(9, actualSquareStates.Count);
            Assert.Contains(SquareState.O, actualSquareStates);
            Assert.Single(actualSquareStates.Where(x => x.Equals(SquareState.O)));

            Assert.Equal(SquareState.O, actual[1, 1].State);
            Assert.Equal("O", actual[1, 1].DisplayCharacter);
        }

        [Fact]
        public void HardComputerPlayer_NoWinOrLossImminent_ChoosesCornerSquareIfCentreOccupied()
        {
            var board = new Board();
            board.Squares[1, 1].State = SquareState.X;
            var player = new HardComputerPlayer();
            var actual = player.PlayerInput(board.Squares);

            var actualSquareStates = new List<SquareState>();

            foreach (var square in actual)
            {
                actualSquareStates.Add(square.State);
            }

            Assert.Equal(9, actualSquareStates.Count);
            Assert.Contains(SquareState.O, actualSquareStates);
            Assert.Single(actualSquareStates.Where(x => x.Equals(SquareState.O)));

            Assert.Equal(SquareState.O, actual[0, 0].State);
            Assert.Equal("O", actual[0, 0].DisplayCharacter);
        }

        [Fact]
        public void HardComputerPlayer_NoWinOrLossImminent_CentreAndOneCornerOccupied_ChoosesAnotherCorner()
        {
            var board = new Board();
            board.Squares[1, 1].State = SquareState.X;
            board.Squares[0, 0].State = SquareState.O;

            var player = new HardComputerPlayer();
            var actual = player.PlayerInput(board.Squares);

            Assert.Equal(SquareState.O, actual[0, 2].State);
            Assert.Equal("O", actual[0, 2].DisplayCharacter);
        }
    }
}
