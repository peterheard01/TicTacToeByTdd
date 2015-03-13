using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class GameLoop
    {
        private GameState _gameState;
        private GameCommands _gameCommands;
        private GameQueries _gameQueries;

        public GameLoop(GameState gameStateArg)
        {
            _gameState = gameStateArg;
            _gameCommands = new GameCommands(_gameState);
            _gameQueries = new GameQueries(_gameState);
        }

        public void RunGameLoop(string userInput)
        {
            _gameCommands.PlacePlayer(userInput);

            _gameState.PlayerPositions = _gameQueries.FindPositions(_gameState.PlayerSymbol);
            _gameState.ComputerPositons = _gameQueries.FindPositions(_gameState.ComputerSymbol);

            if (_gameState.PlayerPositions.Count == 3)
            {
                _gameCommands.MakeWinningLine();
            }
            else if (_gameState.PlayerPositions.Count == 2)
            {
                _gameCommands.BlockPlayer();
            }
            else if (_gameState.PlayerPositions.Count == 1)
            {
                _gameCommands.PlacePieceInOppositeCorner();
            }

        }
    }
}
