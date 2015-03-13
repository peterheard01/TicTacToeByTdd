using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Position FindOppositeCorner(Position pos)
        {
            Position oppositeCorner;
            int newColumn = pos.Column + 2;
            int newRow = pos.Row + 2;
            if (newColumn > 2)
            {
                newColumn = 0;
            }
            if (newRow > 2)
            {
                newRow = 0;
            }
            oppositeCorner = new Position(newRow, newColumn);
            return oppositeCorner;
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
