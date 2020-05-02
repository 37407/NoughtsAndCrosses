using Xunit;

namespace NoughtsAndCrosses.Tests
{
    public class HumanPlayerTests
    {
        [Theory]
        [InlineData("1", 0, 0)]
        [InlineData("2", 0, 1)]
        [InlineData("3", 0, 2)]
        [InlineData("4", 1, 0)]
        [InlineData("5", 1, 1)]
        [InlineData("6", 1, 2)]
        [InlineData("7", 2, 0)]
        [InlineData("8", 2, 1)]
        [InlineData("9", 2, 2)]
        public void HumanPlayer_InputValid_CorrectSquareUpdated(string userInput, int column, int row)
        {
            IConsoleInputRetriever inputRetriever = new TestConsoleInputRetriever(userInput);
            HumanPlayer humanPlayer = new HumanPlayer(inputRetriever);
            var board = new Board();

            var actual = humanPlayer.PlayerInput(board.Squares);

            Assert.Equal("X", actual[column, row].DisplayCharacter);
            Assert.Equal(SquareState.X, actual[column, row].State);
        }
    }
}
