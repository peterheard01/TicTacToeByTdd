using System.Linq;

namespace TicTacToe
{
    public class GameCommands
    {
        private GameState _gameState;
        private GameQueries _gameQueries;

        public GameCommands(GameState gameStateArg)
        {
            _gameState = gameStateArg;
            _gameQueries = new GameQueries(_gameState);
        }

        internal void Win()
        {
            Line winningLine = _gameQueries.FindWinningLine();
            var emptySpace = winningLine.Positions.Single(pos => pos.Symbol == " ");
            emptySpace.Place(_gameState.ComputerSymbol);
        }

    }
}
