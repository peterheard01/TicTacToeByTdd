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
             _gameQueries.GetPositions().Single(x => x.VisualPosition == int.Parse(visualPosition)).Place(_gameState.PlayerSymbol);

            GameCondition? condition = _gameQueries.GetGameCondition();

            switch (condition)
            {
                case GameCondition.CanWin:
                    _gameCommands.Win();
                    break;
                case GameCondition.ShouldBlock:
                    _gameCommands.Block();
                    break;
                case GameCondition.CanFork:
                    _gameCommands.Fork();
                    break;
                case GameCondition.CanTakeCentre:
                    _gameCommands.TakeCentre();
                    break;
                case GameCondition.CanTakeCorner:
                    _gameCommands.TakeCorner();
                    break;
                case GameCondition.CanTakeEdge:
                    _gameCommands.TakeEdge();
                    break;
            }
        }


    }
}
