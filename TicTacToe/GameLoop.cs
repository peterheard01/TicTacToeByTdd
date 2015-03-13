using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class GameLoop
    {
        private GameState _gameState;
        private GameCommands _gameCommands;
        private GameQueries _gameQueries;

        public GameLoop(GameState gameStateArg)
        {
            _gameState = gameStateArg;
            _gameCommands = new GameCommands(_gameState);
            _gameQueries = new GameQueries(_gameState);
        }

        public void RunGameLoop(string userInput)
        {
            _gameCommands.PlacePlayer(userInput);

            _gameState.PlayerPositions = _gameQueries.FindPositions(_gameState.PlayerSymbol);
            _gameState.ComputerPositons = _gameQueries.FindPositions(_gameState.ComputerSymbol);

            if (_gameState.PlayerPositions.Count == 3)
            {
                foreach (var pos in _gameState.ComputerPositons)
                {
                    //check if it is corner cell
                    if (((pos.Column + pos.Row) % 2) == 0 && !pos.IsCenter)
                    {
                        //if the opposite corner is free
                        var oppositeCorner = _gameQueries.FindOppositeCorner(pos);
                        if (_gameState.Board[oppositeCorner.Row, oppositeCorner.Column] == " ")
                        {
                            _gameState.Board[oppositeCorner.Row, oppositeCorner.Column] = _gameState.ComputerSymbol;
                        }
                        else
                        {

                            //must then be a triangle shape so fill in the middle
                            //extract the other positions that are not the center
                            var otherPositions = _gameState.ComputerPositons.Where(x => (x.Column != pos.Column) || (x.Row != pos.Row)).ToList();
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
            else if (_gameState.PlayerPositions.Count == 2)
            {
                _gameCommands.BlockPlayer();
            }
            else if (_gameState.PlayerPositions.Count == 1)
            {
                _gameCommands.PlacePieceInOppositeCorner();
            }

        }

       
      


    }
}
