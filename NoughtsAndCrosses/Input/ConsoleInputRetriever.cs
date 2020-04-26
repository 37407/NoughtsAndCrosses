using System;

namespace NoughtsAndCrosses
{
    public class ConsoleInputRetriever : IConsoleInputRetriever
    {
        public string UserInputReadLine() => Console.ReadLine().ToUpperInvariant();
        public bool UserInputReadKey() => Console.ReadKey().Key == ConsoleKey.Y;
    }
}
