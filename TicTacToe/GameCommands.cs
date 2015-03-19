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
            _gameQueries.FindComputerWinningLine().Positions.Single(pos => pos.Symbol == " ").Place(_gameState.ComputerSymbol);
        }


        internal void Block()
        {
            _gameQueries.FindPlayerWinningLine().Positions.Single(pos => pos.Symbol == " ").Place(_gameState.ComputerSymbol);
        }
    }
}
