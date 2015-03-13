using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class GameLoop
    {
        public Position PlayerTarget { get; set; }

        private GameState _gameState;

        public GameLoop(GameState gameStateArg)
        {
            _gameState = gameStateArg;
        }

        public void RunGameLoop(string userInput)
        {
            PlacePlayer(userInput);

            var playerPositions = FindPlayerPositions(_gameState.PlayerSymbol);
            var computerPositions = FindPlayerPositions(_gameState.ComputerSymbol);

            if (playerPositions.Count == 3)
            {
                foreach (var pos in computerPositions)
                {
                    //check if it is corner cell
                    if (((pos.Column + pos.Row) % 2) == 0 && !pos.IsCenter)
                    {
                        //if the opposite corner is free
                        var oppositeCorner = FindOppositeCorner(pos);
                        if (_gameState.Board[oppositeCorner.Row, oppositeCorner.Column] == " ")
                        {
                            _gameState.Board[oppositeCorner.Row, oppositeCorner.Column] = _gameState.ComputerSymbol;
                        }
                        else
                        {

                            //must then be a triangle shape so fill in the middle
                            //extract the other positions that are not the center
                            var otherPositions = computerPositions.Where(x => (x.Column != pos.Column) || (x.Row != pos.Row)).ToList();
                            var otherNonCenterPosition = otherPositions.Where(x => !x.IsCenter).Single();

                            //if on the same row
                            if (otherNonCenterPosition.Row == pos.Row)
                            {
                                //find the gap
                                for (int column = 0; column < 2; column++)
                                {
                                    if (_gameState.Board[pos.Row, column] == " ")
                                    {
                                        _gameState.Board[pos.Row, column] = _gameState.ComputerSymbol;
                                    }
                                }
                            }
                            else if (otherNonCenterPosition.Column == pos.Column)
                            {
                                for (int row = 0; row < 2; row++)
                                {
                                    if (_gameState.Board[row, pos.Column] == " ")
                                    {
                                        _gameState.Board[row, pos.Column] = _gameState.ComputerSymbol;
                                    }
                                }
                            }


                        }
                    }

                }
            }
            else if (playerPositions.Count == 2)
            {

                //block the player
                //same row
                if (playerPositions[0].Row == playerPositions[1].Row &&
                    (Math.Abs(playerPositions[0].Column - playerPositions[1].Column) == 1))
                {

                    //scan the columns for the empty space and place it there
                    for (int column = 0; column <= 2; column++)
                    {
                        if (_gameState.Board[playerPositions[0].Row, column] == " ")
                        {
                            _gameState.Board[playerPositions[0].Row, column] = _gameState.ComputerSymbol;
                        }
                    }
                }
                //same column
                else if (playerPositions[0].Column == playerPositions[1].Column &&
                    (Math.Abs(playerPositions[0].Row - playerPositions[1].Row) == 1))
                {
                    //scan the columns for the empty space and place it there
                    for (int row = 0; row <= 2; row++)
                    {
                        if (_gameState.Board[row, playerPositions[0].Column] == " ")
                        {
                            _gameState.Board[row, playerPositions[0].Column] = _gameState.ComputerSymbol;
                        }
                    }
                }

            }

            else if (playerPositions.Count == 1)
            {
                if (PlayerTarget.Row == 0 || PlayerTarget.Row == 2)
                {
                    if (PlayerTarget.Row == 0)
                        _gameState.Board[PlayerTarget.Row + 2, PlayerTarget.Column + 1] = "o";
                    else if (PlayerTarget.Row == 2)
                        _gameState.Board[PlayerTarget.Row - 2, PlayerTarget.Column + 1] = "o";

                }
                else if (PlayerTarget.Row == 1)
                {
                    if (PlayerTarget.Column == 0)
                        _gameState.Board[PlayerTarget.Row + 1, PlayerTarget.Column + 2] = "o";
                    else if (PlayerTarget.Column == 2)
                        _gameState.Board[PlayerTarget.Row + 1, PlayerTarget.Column - 2] = "o";
                }

            }

        }

        private void PlacePlayer(string userInput)
        {
            int target = int.Parse(userInput);

            PlayerTarget = FindPosition(target);

            _gameState.Board[PlayerTarget.Row, PlayerTarget.Column] = _gameState.PlayerSymbol;
        }

        private Position FindOppositeCorner(Position pos)
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

        private List<Position> FindPlayerPositions(string symBolToCheck)
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

        private static Position FindPosition(int target)
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
            var place = map.First(x => x.Key == target).Value;
            return place;
        }
    }
}
