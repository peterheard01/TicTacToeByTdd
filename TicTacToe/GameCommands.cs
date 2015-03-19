using System.Linq;

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
            var lineMade = false;
            foreach (var pos in _gameState.ComputerPositons)
            {
                if (_gameQueries.IsCornerCell(pos))
                {
                    if (!TryPlaceAtDiagonalCorner(pos))
                    {
                        lineMade = TryMakeWinningLineByFillingGap(pos);
                    }
                }
            }

            if (lineMade == false)
            {
                AttemptWinningLine(2);
            }
            
        }

        public void AttemptWinningLine(int maxPositionCount)
        {
            foreach (Line line in _gameQueries.Lines())
            {
                var emptyPosCount = 0;
                foreach (var pos in line.Positions)
                {
                    if (_gameState.Board[pos.Row, pos.Column] == " ")
                    {
                        emptyPosCount++;
                    }

                    if (emptyPosCount == maxPositionCount)
                    {
                        TryScanColumsAndPlace(pos.Row);
                        break;
                    }
                }
            }
        }

        public void PlacePlayer(string userInput)
        {
            int target = int.Parse(userInput);

            PlayerTarget = _gameQueries.FindArrayPositionOfBoxNumberRef(target);

            _gameState.Board[PlayerTarget.Row, PlayerTarget.Column] = _gameState.PlayerSymbol;
        }

        private void PlaceInLCorner()
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

        public void TryBlockOrTriangle()
        {
            if (_gameQueries.PlayerHasTwoInARowOnRow())
            {
                TryScanColumsAndPlace(_gameState.PlayerPositions[0].Row);
            }
            else if (_gameQueries.PlayerHasTwoInARowOnColumn())
            {
                TryScanRowsAndPlace(_gameState.PlayerPositions[0].Column);
            }
            else if (_gameQueries.ComputerHasTwoDiagonally())
            {
                TryCreateTriangle();
            }
        }

        private void TryCreateTriangle()
        {
            foreach (var computerPosition in _gameState.ComputerPositons)
            {
                if (_gameQueries.IsCornerCell(computerPosition))
                {
                    var cellToTheRight = new Position(computerPosition.Row, _cycleShift.ShiftOne(computerPosition.Column) + computerPosition.Column);
                    var cellDownwards = new Position(_cycleShift.ShiftOne(computerPosition.Row) + computerPosition.Row, computerPosition.Column);

                    if (_gameState.Board[cellToTheRight.Row, cellToTheRight.Column] == " ")
                    {
                        var cornerRightWards = new Position(computerPosition.Row, _cycleShift.ShiftTwo(computerPosition.Column));
                        TryPlace(cornerRightWards, _gameState.ComputerSymbol);
                    }
                    else if (_gameState.Board[cellDownwards.Row, cellDownwards.Column] == " ")
                    {
                        var cornerDownwards = new Position(_cycleShift.ShiftTwo(computerPosition.Row), computerPosition.Column);
                        TryPlace(cornerDownwards, _gameState.ComputerSymbol);
                    }

                }
            }

        }

        public void TryPlacePieceInOppositeCorner()
        {
            if (_gameQueries.IsCornerCell(PlayerTarget))
            {
                var diag = _gameQueries.CalculateOppositeDiagonalCorner(PlayerTarget);
                TryPlace(diag, _gameState.ComputerSymbol);
            }
            else
            {
                PlaceInLCorner();
            }

        }

        private bool TryPlaceAtDiagonalCorner(Position pos)
        {
            var oppositeCorner = _gameQueries.CalculateOppositeDiagonalCorner(pos);
            return TryPlace(oppositeCorner, _gameState.ComputerSymbol);
        }

        private bool TryMakeWinningLineByFillingGap(Position pos)
        {
            bool winningLineMade = false;
            var otherPositions = _gameState.ComputerPositons.Where(x => (x.Column != pos.Column) || (x.Row != pos.Row)).ToList();
            var otherNonCenterPosition = otherPositions.Single(x => !x.IsCenter);

            if (otherNonCenterPosition.Row == pos.Row)
            {
                winningLineMade = TryScanColumsAndPlace(pos.Row);
            }
            else if (otherNonCenterPosition.Column == pos.Column)
            {
                winningLineMade = TryScanRowsAndPlace(pos.Column);
            }
            return winningLineMade;
        }

        private bool TryScanRowsAndPlace(int column)
        {
            var placed = false;
            for (int row = 0; row <= 2; row++)
            {
                if (TryPlace(new Position(row, column), _gameState.ComputerSymbol))
                {
                    placed = true;
                }
            }
            return placed;
        }

        private bool TryScanColumsAndPlace(int row)
        {
            bool placed = false;
            for (int column = 0; column <= 2; column++)
            {
                if (TryPlace(new Position(row, column), _gameState.ComputerSymbol))
                {
                    placed = true;
                    break;
                }
            }
            return placed;
        }

        private bool TryPlace(Position pos, string symbol)
        {
            var placed = false;
            if (_gameState.Board[pos.Row, pos.Column] == " ")
            {
                _gameState.Board[pos.Row, pos.Column] = symbol;
                placed = true;
            }
            return placed;
        }


    }
}
