using System.Collections.Generic;

namespace TicTacToe
{
    public class GameQueries
    {
        private GameState _gameState;

        public GameQueries(GameState gameStateArg)
        {
            _gameState = gameStateArg;
        }

        #region queries
        public Position CalculateOppositeCorner(Position pos)
        {
            return new Position(Shift(pos.Row), Shift(pos.Column));
        }

        private int Shift(int pos)
        {
            int newPos = pos + 2;
            if (newPos > 2)
            {
                newPos = 0;
            }
            return newPos;
        }

        public List<Position> FindPositions(string symBolToCheck)
        {
            var retVals = new List<Position>();
            for (int row = 0; row <= 2; row++)
            {
                for (int column = 0; column <= 2; column++)
                {
                    if (_gameState.Board[row, column] == symBolToCheck)
                    {
                        retVals.Add(new Position(row, column));
                    }
                }
            }
            return retVals;
        }
        #endregion
    }
}
