using System.Collections.Generic;

namespace TicTacToe
{
    public class GameQueries
    {
        private GameState _gameState;
        private CycleShift _cycleShift;

        public GameQueries(GameState gameStateArg)
        {
            _gameState = gameStateArg;
            _cycleShift = new CycleShift();
        }

        public Position CalculateOppositeDiagonalCorner(Position pos)
        {
            return new Position(_cycleShift.ShiftTwo(pos.Row), _cycleShift.ShiftTwo(pos.Column));
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

    }
}
