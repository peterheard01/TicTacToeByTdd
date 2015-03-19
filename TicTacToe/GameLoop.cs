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
                    Win();
                    break;
                case GameCondition.ShouldBlock:
                    Block();
                    break;
                case GameCondition.CanFork:
                    Fork();
                    break;
                case GameCondition.CanTakeCentre:
                    TakeCentre();
                    break;
                case GameCondition.CanTakeCorner:
                    TakeCorner();
                    break;
                case GameCondition.CanTakeEdge:
                    TakeEdge();
                    break;
            }
        }

        private void TakeEdge()
        {
            _gameCommands.TakeEdge();
        }

        private void TakeCorner()
        {
            _gameCommands.TakeCorner();
        }

        private void TakeCentre()
        {
            _gameCommands.TakeCentre();
        }

        private void Fork()
        {
            _gameCommands.Fork();
        }

        private void Block()
        {
            _gameCommands.Block();
        }

        private void Win()
        {
            _gameCommands.Win();
        }
    }
}
