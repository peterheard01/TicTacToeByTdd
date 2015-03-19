using System.Linq;

namespace TicTacToe
{
    public class GameLoop
    {
        private GameState _gameState;
        private GameCommands _gameCommands;
        private GameQueries _gameQueries;

        public GameLoop(GameState gameStateArg,GameCommands gameCommandArg, GameQueries gameQueriesArg)
        {
            _gameState = gameStateArg;
            _gameCommands = gameCommandArg;
            _gameQueries = gameQueriesArg;
        }

        public void RunGameLoop(string visualPosition)
        {
            var single = _gameQueries.GetPositions().Single(x => x.VisualPosition == int.Parse(visualPosition));
            single.Place(_gameState.PlayerSymbol);

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
