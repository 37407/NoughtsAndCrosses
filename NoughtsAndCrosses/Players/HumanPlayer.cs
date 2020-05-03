using System;
using System.Text.RegularExpressions;

namespace NoughtsAndCrosses
{
    public class HumanPlayer : IPlayer
    {
        private readonly IConsoleInputRetriever _inputRetriever;

        public HumanPlayer(IConsoleInputRetriever inputRetriever)
        {
            _inputRetriever = inputRetriever;
        }

        public SquareState SquareOccupied => SquareState.X;

        public string DisplayCharacter => "X";

        public string WinMessage => "Player X wins!";

        public Square[,] PlayerInput(Square[,] board)
        {
            Console.WriteLine("Choose a location, e.g. 1-9");
            string input;
            bool inputValid;
            bool locationEmpty;
            ValidateInput(out input, out inputValid);
            int[] playerCoordinates = MapUserInputToCoordinates(input);

            locationEmpty = UserLocationEmpty(playerCoordinates, board);
            while (!locationEmpty)
            {
                Console.WriteLine("Location has already been chosen - please select another");
                ValidateInput(out input, out inputValid);
                playerCoordinates = MapUserInputToCoordinates(input);
                locationEmpty = UserLocationEmpty(playerCoordinates, board);
            }
            board[playerCoordinates[0], playerCoordinates[1]].State = SquareState.X;
            board[playerCoordinates[0], playerCoordinates[1]].DisplayCharacter = DisplayCharacter;

            return board;
        }

        private void ValidateInput(out string input, out bool inputValid)
        {
            input = _inputRetriever.UserInputReadLine();
            inputValid = InputValid(input);
            while (!inputValid)
            {
                Console.WriteLine("Enter location as a number 1-9");
                input = _inputRetriever.UserInputReadLine();
                inputValid = InputValid(input);
            }
        }

        private bool InputValid(string input)
        {
            Regex regex = new Regex("^\\d$");
            return regex.IsMatch(input);
        }

        private int[] MapUserInputToCoordinates(string input)
        {
            return int.Parse(input) switch
            {
                1 => new int[] { 0, 0 },
                2 => new int[] { 0, 1 },
                3 => new int[] { 0, 2 },
                4 => new int[] { 1, 0 },
                5 => new int[] { 1, 1 },
                6 => new int[] { 1, 2 },
                7 => new int[] { 2, 0 },
                8 => new int[] { 2, 1 },
                9 => new int[] { 2, 2 },
                _ => null
            };
        }

        private bool UserLocationEmpty(int[] playerCoordinates, Square[,] board)
        {
            return board[playerCoordinates[0], playerCoordinates[1]].State.Equals(SquareState.Empty);
        }
    }
}
