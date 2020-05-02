using System;

namespace NoughtsAndCrosses
{
    public class GameRunner
    {
        private readonly IConsoleInputRetriever _inputRetriever;
        private readonly IPlayer _playerOne;
        private readonly IPlayer _playerTwo;
        private readonly Square[,] _board;
        private int _turnCounter;
        private bool _gameOver;

        public GameRunner(IConsoleInputRetriever inputRetriever, IPlayer playerOne, IPlayer playerTwo)
        {

            _inputRetriever = inputRetriever;
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _board = new BoardCreator().Board;
            _turnCounter = 0;
            _gameOver = false;
        }

        public bool RunGame()
        {
            DisplayBoard(_board);
            while (!_gameOver)
            {
                _gameOver = HandlePlayerTurn(_board, _playerOne);
                if (_gameOver) break;
                _gameOver = HandlePlayerTurn(_board, _playerTwo);
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
            bool gameOver = CheckForWin(board, player.SquareOccupied);
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

        private bool CheckForWin(Square[,] board, SquareState player)
        {
            for (int i = 0; i <= 2; i++)
            {
                if (board[0, i].State.Equals(player) && board[1, i].State.Equals(player) && board[2, i].State.Equals(player)) return true;
            }

            for (int j = 0; j <= 2; j++)
            {
                if (board[j, 0].State.Equals(player) && board[j, 1].State.Equals(player) && board[j, 2].State.Equals(player)) return true;
            }

            if (board[0, 0].State.Equals(player) && board[1, 1].State.Equals(player) && board[2, 2].State.Equals(player)) return true;

            if (board[0, 2].State.Equals(player) && board[1, 1].State.Equals(player) && board[2, 0].State.Equals(player)) return true;

            return false;
        }
    }
}