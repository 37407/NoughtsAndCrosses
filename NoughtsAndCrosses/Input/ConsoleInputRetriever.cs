using System;

namespace NoughtsAndCrosses
{
    public class ConsoleInputRetriever : IConsoleInputRetriever
    {
        public string UserInputReadLine() => Console.ReadLine().ToUpperInvariant();
        public bool PlayAgainKeyPressed() => Console.ReadKey().Key == ConsoleKey.Y;
    }
}
