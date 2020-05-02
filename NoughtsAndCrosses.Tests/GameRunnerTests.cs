using Xunit;

namespace NoughtsAndCrosses.Tests
{
    public class GameRunnerTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void GameRunner_RunGame_RunsToCompletion(bool playAgain)
        {
            IConsoleInputRetriever inputRetriever = new TestConsoleInputRetriever("test", playAgain);
            IPlayer playerOne = new EasyComputerPlayer();
            IPlayer playerTwo = new EasyComputerPlayer();

            GameRunner gameRunner = new GameRunner(inputRetriever, playerOne, playerTwo);
            var actual = gameRunner.RunGame();
            Assert.Equal(playAgain, actual);
        }

        [Theory]
        [InlineData(1, 0, 1, 2)]
        [InlineData(0, 1, 2, 1)]
        [InlineData(0, 0, 2, 2)]
        [InlineData(0, 2, 2, 0)]
        public void GameRunner_HandlePlayerTurn_WinDetected_ReturnsTrue(int firstColumn, int firstRow, int secondColumn, int secondRow)
        {
            IConsoleInputRetriever inputRetriever = new TestConsoleInputRetriever("5", true);
            IPlayer playerOne = new HumanPlayer(inputRetriever);
            IPlayer playerTwo = new EasyComputerPlayer();

            var board = new BoardCreator().Board;
            board[firstColumn, firstRow].State = SquareState.X;
            board[secondColumn, secondRow].State = SquareState.X;

            GameRunner gameRunner = new GameRunner(inputRetriever, playerOne, playerTwo);
            var actual = gameRunner.HandlePlayerTurn(board, playerOne);
            Assert.True(actual);
        }

        [Fact]
        public void GameRunner_HandlePlayerTurn_NoWinDetected_ReturnsFalse()
        {
            IConsoleInputRetriever inputRetriever = new TestConsoleInputRetriever("5", true);
            IPlayer playerOne = new HumanPlayer(inputRetriever);
            IPlayer playerTwo = new EasyComputerPlayer();

            var board = new BoardCreator().Board;

            GameRunner gameRunner = new GameRunner(inputRetriever, playerOne, playerTwo);
            var actual = gameRunner.HandlePlayerTurn(board, playerOne);
            Assert.False(actual);
        }
    }
}
