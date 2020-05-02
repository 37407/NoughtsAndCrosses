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
                IPlayer computerPlayer = DifficultyLevelSelector.SetComputerPlayerLevel(inputRetriever);
                GameRunner gameRunner = new GameRunner(inputRetriever, new HumanPlayer(inputRetriever), computerPlayer);
                runGame = gameRunner.RunGame();
            }
        }
    }
}
