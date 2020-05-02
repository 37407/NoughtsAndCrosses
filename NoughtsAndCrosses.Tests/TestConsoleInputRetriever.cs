namespace NoughtsAndCrosses.Tests
{
    public class TestConsoleInputRetriever : IConsoleInputRetriever
    {
        private readonly string _input;

        public TestConsoleInputRetriever(string input) => _input = input;

        public string UserInputReadLine() => _input;

        public bool PlayAgainKeyPressed() => false;
    }
}
