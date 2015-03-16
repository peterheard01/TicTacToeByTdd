using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool ComputerHasTwoDiagonally()
        {
            var hasCorner = false;
            var hasCenter = false;
            foreach (var computerPosition in _gameState.ComputerPositons)
            {
                if (computerPosition.IsCenter)
                {
                    hasCenter = true;
                }
                if (IsCornerCell(computerPosition))
                {
                    hasCorner = true;
                }
            }
            return hasCorner && hasCenter;
        }

        public bool IsCornerCell(Position pos)
        {
            return ((pos.Column + pos.Row) % 2) == 0 && !pos.IsCenter;
        }

        public bool PlayerHasTwoInARowOnColumn()
        {
            return _gameState.PlayerPositions[0].Column == _gameState.PlayerPositions[1].Column;
        }

        public bool PlayerHasTwoInARowOnRow()
        {
            return _gameState.PlayerPositions[0].Row == _gameState.PlayerPositions[1].Row;
        }

        public Position FindArrayPositionOfBoxNumberRef(int boxNumber)
        {
            Dictionary<int, Position> map = new Dictionary<int, Position>();
            map.Add(1, new Position(0, 0));
            map.Add(2, new Position(0, 1));
            map.Add(3, new Position(0, 2));
            map.Add(4, new Position(1, 0));
            map.Add(5, new Position(1, 1));
            map.Add(6, new Position(1, 2));
            map.Add(7, new Position(2, 0));
            map.Add(8, new Position(2, 1));
            map.Add(9, new Position(2, 2));
            var place = map.First(x => x.Key == boxNumber).Value;
            return place;
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




        internal List<Line> Lines()
        {
            var retVal = new List<Line>();
            for (int row = 0; row <= 2; row++)
            {
                var line = new Line();
                line.Orientation = Orientation.Horizontal;

                for (int column = 0; column <= 2; column++)
                {
                    line.Positions.Add(new Position(row,column));
                }
                retVal.Add(line);

            }

            return retVal;

        }
    }
}
