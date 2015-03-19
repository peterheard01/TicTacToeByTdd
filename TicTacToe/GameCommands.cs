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
            _gameQueries.FindComputerWinningLine().Positions.Single(pos => pos.Symbol == GameConstants.EmptySpace).Place(_gameState.ComputerSymbol);
        }

        internal void Block()
        {
            _gameQueries.FindPlayerWinningLine().Positions.Single(pos => pos.Symbol == GameConstants.EmptySpace).Place(_gameState.ComputerSymbol);
        }

        internal void Fork()
        {
            _gameQueries.FindForkableLine().Positions.First(pos => pos.Symbol == GameConstants.EmptySpace && pos.IsCorner).Place(_gameState.ComputerSymbol);
        }

        internal void TakeCentre()
        {
            _gameQueries.GetPositions().Single(pos => pos.IsCentre && pos.Symbol == GameConstants.EmptySpace).Place(_gameState.ComputerSymbol);
        }

        internal void TakeCorner()
        {
            _gameQueries.GetPositions().First(pos => pos.IsCorner && pos.Symbol == GameConstants.EmptySpace).Place(_gameState.ComputerSymbol);
        }

        internal void TakeEdge()
        {
            _gameQueries.GetPositions().First(pos => pos.IsEdge && pos.Symbol == GameConstants.EmptySpace).Place(_gameState.ComputerSymbol);
        }
    }
}
