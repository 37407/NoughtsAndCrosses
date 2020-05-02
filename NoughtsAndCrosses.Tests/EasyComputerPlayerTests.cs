using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NoughtsAndCrosses.Tests
{
    public class EasyComputerPlayerTests
    {
        [Fact]
        public void EasyComputerPlayer_PlayerInput_ReturnsBoard_OneDisplayCharacterMatchesComputerPlayerSymbol()
        {
            var board = new Board();
            var player = new EasyComputerPlayer();
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
        public void EasyComputerPlayer_PlayerInput_ReturnsBoard_OneSquareStateMatchesComputerPlayerState()
        {
            var board = new Board();
            var player = new EasyComputerPlayer();
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
    }
}
