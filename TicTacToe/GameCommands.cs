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

        public Position PlayerTarget { get; set; }

        public GameCommands(GameState gameStateArg)
        {
            _gameState = gameStateArg;
        }

        public void PlaceIfEmpty(int row, int column, string symbol)
        {
            if (_gameState.Board[row, column] == " ")
            {
                _gameState.Board[row, column] = symbol;
            }
        }

        public void PlacePieceInOppositeCorner()
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

        public void PlacePlayer(string userInput)
        {
            int target = int.Parse(userInput);

            PlayerTarget = FindArrayPositionOfBoxNumberRef(target);

            _gameState.Board[PlayerTarget.Row, PlayerTarget.Column] = _gameState.PlayerSymbol;
        }

        public void BlockPlayer()
        {
            if (PlayerHasTwoInARowOnSameRow())
            {
                for (int column = 0; column <= 2; column++)
                {
                    PlaceIfEmpty(_gameState.PlayerPositions[0].Row, column, _gameState.ComputerSymbol);
                }
            }
            else if (PlayerHasTwoInARowOnSameColumn())
            {
                for (int row = 0; row <= 2; row++)
                {
                    PlaceIfEmpty(row, _gameState.PlayerPositions[0].Column, _gameState.ComputerSymbol);
                }
            }
        }

        private bool PlayerHasTwoInARowOnSameColumn()
        {
            return _gameState.PlayerPositions[0].Column == _gameState.PlayerPositions[1].Column &&
                   (Math.Abs(_gameState.PlayerPositions[0].Row - _gameState.PlayerPositions[1].Row) == 1);
        }

        private bool PlayerHasTwoInARowOnSameRow()
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
