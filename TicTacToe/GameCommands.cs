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

            var blah = false;
            foreach (var pos in _gameState.ComputerPositons)
            {
                if (_gameQueries.IsCornerCell(pos))
                {
                    if (!PlaceAtDiagonalCorner(pos))
                    {
                        //if (!
                        blah = MakeWinningLineByFillingGap(pos);

                        //blah = true;
                        // {
                        //
                        //}
                    }
                }
            }

            if (blah == false)
            {
                AttemptWinningLine();
            }
            
        }

        public void AttemptWinningLine()
        {
            //var hasEmptySpace = false;
            foreach (Line line in _gameQueries.Lines())
            {
                var emptyPosCount = 0;
                foreach (var pos in line.Positions)
                {
                    if (_gameState.Board[pos.Row, pos.Column] == " ")
                    {
                        emptyPosCount++;
                    }

                    if (emptyPosCount == 2)
                    {
                        ScanColumsAndPlace(pos.Row);
                        break;
                    }
                    //if (emptyPosCount == 1)
                    //{
                    //    ScanColumsAndPlace(pos.Row);
                    //    break;
                    //}
                }
            }
        }

        public void AttemptWinningLine2()
        {
            //var hasEmptySpace = false;
            foreach (Line line in _gameQueries.Lines())
            {
                var emptyPosCount = 0;
                foreach (var pos in line.Positions)
                {
                    if (_gameState.Board[pos.Row, pos.Column] == " ")
                    {
                        emptyPosCount++;
                    }

                    if (emptyPosCount == 1)
                    {
                        ScanColumsAndPlace(pos.Row);
                        break;
                    }
                }
            }
        }

        public void BlockOrTriangle()
        {
            if (_gameQueries.PlayerHasTwoInARowOnRow())
            {
                ScanColumsAndPlace(_gameState.PlayerPositions[0].Row);
            }
            else if (_gameQueries.PlayerHasTwoInARowOnColumn())
            {
                ScanRowsAndPlace(_gameState.PlayerPositions[0].Column);
            }
            else if (_gameQueries.ComputerHasTwoDiagonally())
            {
                CreateTriangle();
            }
        }

        

        private void CreateTriangle()
        {
            foreach (var computerPosition in _gameState.ComputerPositons)
            {
                if (_gameQueries.IsCornerCell(computerPosition))
                {
                    //check rh cel
                    var cellToTheRight = new Position(computerPosition.Row, _cycleShift.ShiftOne(computerPosition.Column) + computerPosition.Column);
                    var cellDownwards = new Position(_cycleShift.ShiftOne(computerPosition.Row) + computerPosition.Row, computerPosition.Column);

                    if (_gameState.Board[cellToTheRight.Row, cellToTheRight.Column] == " ")
                    {
                        var cornerRightWards = new Position(computerPosition.Row, _cycleShift.ShiftTwo(computerPosition.Column));
                        PlaceIfEmpty(cornerRightWards, _gameState.ComputerSymbol);
                    }
                    else if (_gameState.Board[cellDownwards.Row, cellDownwards.Column] == " ")
                    {
                        var cornerDownwards = new Position(_cycleShift.ShiftTwo(computerPosition.Row), computerPosition.Column);
                        PlaceIfEmpty(cornerDownwards, _gameState.ComputerSymbol);
                    }
                   
                }
            }

        }

        public void PlacePieceInOppositeCorner()
        {
            if (_gameQueries.IsCornerCell(PlayerTarget))
            {
                var diag = _gameQueries.CalculateOppositeDiagonalCorner(PlayerTarget);
                PlaceIfEmpty(diag, _gameState.ComputerSymbol);
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
            return PlaceIfEmpty(oppositeCorner, _gameState.ComputerSymbol);
        }

        private bool MakeWinningLineByFillingGap(Position pos)
        {
            bool winningLineMade = false;
            var otherPositions = _gameState.ComputerPositons.Where(x => (x.Column != pos.Column) || (x.Row != pos.Row)).ToList();
            var otherNonCenterPosition = otherPositions.Single(x => !x.IsCenter);

            if (otherNonCenterPosition.Row == pos.Row)
            {
                winningLineMade = ScanColumsAndPlace(pos.Row);
            }
            else if (otherNonCenterPosition.Column == pos.Column)
            {
                winningLineMade = ScanRowsAndPlace(pos.Column);
            }
            return winningLineMade;
        }

        public void PlacePlayer(string userInput)
        {
            int target = int.Parse(userInput);

            PlayerTarget = _gameQueries.FindArrayPositionOfBoxNumberRef(target);

            _gameState.Board[PlayerTarget.Row, PlayerTarget.Column] = _gameState.PlayerSymbol;
        }

        private bool ScanRowsAndPlace(int column)
        {
            var placed = false;
            for (int row = 0; row <= 2; row++)
            {
                if (PlaceIfEmpty(new Position(row, column), _gameState.ComputerSymbol))
                {
                    placed = true;
                }
            }
            return placed;
        }

        private bool ScanColumsAndPlace(int row)
        {
            bool placed = false;
            for (int column = 0; column <= 2; column++)
            {
                if (PlaceIfEmpty(new Position(row, column), _gameState.ComputerSymbol))
                {
                    placed = true;
                    break;
                }
            }
            return placed;
        }



        private bool PlaceIfEmpty(Position pos, string symbol)
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
