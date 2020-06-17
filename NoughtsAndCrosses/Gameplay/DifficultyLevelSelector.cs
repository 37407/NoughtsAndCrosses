using System;

namespace NoughtsAndCrosses
{
    public static class DifficultyLevelSelector
    {
        private static IPlayer computerPlayer;

        public static IPlayer SetComputerPlayerLevel(IConsoleInputRetriever inputRetriever)
        {
            Console.WriteLine();
            Console.WriteLine("Select difficulty level: 1 = easy, 2 = medium, 3 = hard, 4 = impossible");
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
                        computerPlayer = new HardComputerPlayer();
                        break;
                    case "4":
                        computerLevelValid = true;
                        computerPlayer = new ImpossibleComputerPlayer();
                        break;
                    default:
                        Console.WriteLine("Please enter 1, 2, 3 or 4.");
                        break;
                }
            }
            return computerPlayer;
        }
    }
}
