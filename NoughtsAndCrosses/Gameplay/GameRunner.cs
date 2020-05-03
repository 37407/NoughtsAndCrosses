using System;

namespace NoughtsAndCrosses
{
    public class GameRunner
    {
        private readonly IConsoleInputRetriever _inputRetriever;
        private readonly IPlayer _playerOne;
        private readonly IPlayer _playerTwo;
        private readonly Board _board;
        private int _turnCounter;
        private bool _gameOver;

        public GameRunner(IConsoleInputRetriever inputRetriever, IPlayer playerOne, IPlayer playerTwo)
        {

            _inputRetriever = inputRetriever;
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _board = new Board();
            _turnCounter = 0;
            _gameOver = false;
        }

        public bool RunGame()
        {
            DisplayBoard(_board.Squares);
            while (!_gameOver)
            {
                _gameOver = HandlePlayerTurn(_board.Squares, _playerOne);
                if (_gameOver) break;
                _gameOver = HandlePlayerTurn(_board.Squares, _playerTwo);
                if (_gameOver) break;
            }

            Console.WriteLine("Play again?");
            return _inputRetriever.PlayAgainKeyPressed();
        }

        private void DisplayBoard(Square[,] board)
        {
            Console.WriteLine();
            Console.WriteLine(" {0} | {1} | {2} ", board[0, 0].DisplayCharacter, board[0, 1].DisplayCharacter, board[0, 2].DisplayCharacter);
            Console.WriteLine("----------- ");
            Console.WriteLine(" {0} | {1} | {2} ", board[1, 0].DisplayCharacter, board[1, 1].DisplayCharacter, board[1, 2].DisplayCharacter);
            Console.WriteLine("----------- ");
            Console.WriteLine(" {0} | {1} | {2} ", board[2, 0].DisplayCharacter, board[2, 1].DisplayCharacter, board[2, 2].DisplayCharacter);
            Console.WriteLine();
        }

        public bool HandlePlayerTurn(Square[,] board, IPlayer player)
        {
            player.PlayerInput(board);
            _turnCounter++;
            bool gameOver = GameplayHelper.CheckForWin(board, player.SquareOccupied);
            if (gameOver)
            {
                Console.WriteLine(player.WinMessage);
                DisplayBoard(board);
                return true;
            }
            if (_turnCounter == 9)
            {
                Console.WriteLine("Game drawn");
                DisplayBoard(board);
                return true;
            }
            DisplayBoard(board);
            return false;
        }
    }
}