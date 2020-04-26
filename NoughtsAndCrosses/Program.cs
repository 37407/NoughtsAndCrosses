namespace NoughtsAndCrosses
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runGame = true;
            ConsoleInputRetriever inputRetriever = new ConsoleInputRetriever();
            while (runGame)
            {
                GameRunner gameRunner = new GameRunner(inputRetriever, new HumanPlayer(inputRetriever), new ComputerPlayer());
                runGame = gameRunner.RunGame();
            }
        }
    }
}
