using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameCommands
    {
        private GameState _gameState;
        private GameQueries _gameQueries;
        private CycleShift _cycleShift;

        public Position PlayerTarget { get; set; }

        public GameCommands(GameState gameStateArg)
        {
            _gameState = gameStateArg;
            _gameQueries = new GameQueries(_gameState);
            _cycleShift = new CycleShift();
        }

        public void MakeWinningLine()
        {
            foreach (var pos in _gameState.ComputerPositons)
            {
                if (IsCornerCell(pos))
                {
                    if (!PlaceAtDiagonalCorner(pos))
                    {
                        FindAndPlaceInBetween(pos);
                    }
                }
            }
        }

        public void BlockPlayer()
        {
            if (PlayerHasTwoInARowOnRow())
            {
                ScanColumsAndPlace(_gameState.PlayerPositions[0].Row);
            }
            else if (PlayerHasTwoInARowOnColumn())
            {
                ScanRowsAndPlace(_gameState.PlayerPositions[0].Column);
            }
            if (ComputerHasTwoDiagonally())
            {
                CreateTriangle();
            }
        }

        private bool ComputerHasTwoDiagonally()
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

        private void CreateTriangle()
        {
            foreach (var computerPosition in _gameState.ComputerPositons)
            {
                if (IsCornerCell(computerPosition))
                {
                    //check rh cel
                    var cellToTheRight = new Position(computerPosition.Row, _cycleShift.ShiftOne(computerPosition.Column) + computerPosition.Column);
                    var cellDownwards = new Position(_cycleShift.ShiftOne(computerPosition.Row) + computerPosition.Row, computerPosition.Column);

                    if (_gameState.Board[cellToTheRight.Row, cellToTheRight.Column] == " ")
                    {
                        //place piece at opposite corner
                        //var newPos = new Position()
                    }
                    else if (_gameState.Board[cellDownwards.Row, cellDownwards.Column] == " ")
                    {
                        //place piece at opposite corner
                        var diag = _gameQueries.CalculateOppositeDiagonalCorner(computerPosition);
                    }
                    

                    //if (PlaceIfEmpty(rh))
                    //{
                    //}
                }
            }

        }

       

        public void PlacePieceInOppositeCorner()
        {
            if (IsCornerCell(PlayerTarget))
            {
                var diag = _gameQueries.CalculateOppositeDiagonalCorner(PlayerTarget);
                PlaceIfEmpty(diag.Row, diag.Column, _gameState.ComputerSymbol);
            }
            else
            {
                switch (PlayerTarget.Row)
                {
                    case 0:
                        _gameState.Board[PlayerTarget.Row + 2, PlayerTarget.Column + 1] = _gameState.ComputerSymbol;
                        break;
                    case 2:
                        _gameState.Board[PlayerTarget.Row - 2, PlayerTarget.Column + 1] = _gameState.ComputerSymbol;
                        break;
                    case 1:
                        if (PlayerTarget.Column == 0)
                            _gameState.Board[PlayerTarget.Row + 1, PlayerTarget.Column + 2] = _gameState.ComputerSymbol;
                        else if (PlayerTarget.Column == 2)
                            _gameState.Board[PlayerTarget.Row + 1, PlayerTarget.Column - 2] = _gameState.ComputerSymbol;
                        break;
                }
            }

           
        }

        private bool PlaceAtDiagonalCorner(Position pos)
        {
            var oppositeCorner = _gameQueries.CalculateOppositeDiagonalCorner(pos);
            return PlaceIfEmpty(oppositeCorner.Row, oppositeCorner.Column, _gameState.ComputerSymbol);
        }

        private void FindAndPlaceInBetween(Position pos)
        {
            var otherPositions = _gameState.ComputerPositons.Where(x => (x.Column != pos.Column) || (x.Row != pos.Row)).ToList();
            var otherNonCenterPosition = otherPositions.Single(x => !x.IsCenter);

            if (otherNonCenterPosition.Row == pos.Row)
            {
                ScanColumsAndPlace(pos.Row);
            }
            else if (otherNonCenterPosition.Column == pos.Column)
            {
                ScanRowsAndPlace(pos.Column);
            }
        }

        public void PlacePlayer(string userInput)
        {
            int target = int.Parse(userInput);

            PlayerTarget = FindArrayPositionOfBoxNumberRef(target);

            _gameState.Board[PlayerTarget.Row, PlayerTarget.Column] = _gameState.PlayerSymbol;
        }

        private void ScanRowsAndPlace(int pos)
        {
            for (int row = 0; row <= 2; row++)
            {
                PlaceIfEmpty(row, pos, _gameState.ComputerSymbol);
            }
        }

        private void ScanColumsAndPlace(int row)
        {
            for (int column = 0; column <= 2; column++)
            {
                PlaceIfEmpty(row, column, _gameState.ComputerSymbol);
            }
        }

        private static bool IsCornerCell(Position pos)
        {
            return ((pos.Column + pos.Row) % 2) == 0 && !pos.IsCenter;
        }

        private bool PlaceIfEmpty(int row, int column, string symbol)
        {
            var placed = false;
            if (_gameState.Board[row, column] == " ")
            {
                _gameState.Board[row, column] = symbol;
                placed = true;
            }
            return placed;
        }

        private bool PlayerHasTwoInARowOnColumn()
        {
            return _gameState.PlayerPositions[0].Column == _gameState.PlayerPositions[1].Column &&
                   (Math.Abs(_gameState.PlayerPositions[0].Row - _gameState.PlayerPositions[1].Row) == 1);
        }

        private bool PlayerHasTwoInARowOnRow()
        {
            return _gameState.PlayerPositions[0].Row == _gameState.PlayerPositions[1].Row &&
                   (Math.Abs(_gameState.PlayerPositions[0].Column - _gameState.PlayerPositions[1].Column) == 1);
        }

        private static Position FindArrayPositionOfBoxNumberRef(int boxNumber)
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
    }
}
