using System;

namespace NoughtsAndCrosses
{
    public static class DifficultyLevelSelector
    {
        private static IPlayer computerPlayer;

        public static IPlayer SetComputerPlayerLevel(IConsoleInputRetriever inputRetriever)
        {
            Console.WriteLine("Select difficulty level: 1 = easy, 2 = medium, 3 = impossible");
            bool computerLevelValid = false;
            while(!computerLevelValid)
            {
                string input = inputRetriever.UserInputReadLine();
                switch (input)
                {
                    case "1":
                        computerLevelValid = true;
                        computerPlayer = new EasyComputerPlayer();
                        break;
                    case "2":
                        computerLevelValid = true;
                        computerPlayer = new MediumComputerPlayer();
                        break;
                    case "3":
                        computerLevelValid = true;
                        computerPlayer = new ImpossibleComputerPlayer();
                        break;
                    default:
                        Console.WriteLine("Please enter 1, 2 or 3.");
                        break;
                }
            }
            return computerPlayer;
        }
    }
}
