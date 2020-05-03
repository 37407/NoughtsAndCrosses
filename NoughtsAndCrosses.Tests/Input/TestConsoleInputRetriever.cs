namespace NoughtsAndCrosses.Tests
{
    public class TestConsoleInputRetriever : IConsoleInputRetriever
    {
        private readonly string _input;
        private readonly bool _playAgain;

        public TestConsoleInputRetriever(string input, bool playAgain = false)
        {
            _input = input;
            _playAgain = playAgain;
        }

        public string UserInputReadLine() => _input;

        public bool PlayAgainKeyPressed() => _playAgain;
    }
}
