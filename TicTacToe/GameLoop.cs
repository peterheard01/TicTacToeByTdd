using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class GameLoop
    {
        private GameState _gameState;
        private GameCommands _gameCommands;
        private GameQueries _gameQueries;

        public GameLoop(GameState gameStateArg,GameCommands gameCommandArg)
        {
            _gameState = gameStateArg;
            _gameCommands = gameCommandArg;
            _gameQueries = new GameQueries(_gameState);
        }

        public void RunGameLoop(string visualPosition)
        {
            _gameCommands.PlaceSymbol(_gameState.PlayerSymbol, int.Parse(visualPosition));

            GameCondition condition = _gameQueries.GetGameCondition();

            switch (condition)
            {
                    case GameCondition.CanWin:
                    Win();
                    break;
            }
        }

        private void Win()
        {
            _gameCommands.Win();
        }
    }
}
