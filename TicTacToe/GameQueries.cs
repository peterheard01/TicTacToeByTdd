using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class GameQueries
    {
        private GameState _gameState;

        public GameQueries(GameState gameStateArg)
        {
            _gameState = gameStateArg;
        }

        public GameCondition GetGameCondition()
        {
            return GetLines().Any(CanWinOnLine) ? GameCondition.CanWin : GameCondition.ShouldBlock;
        }

        public Line FindWinningLine()
        {
            return GetLines().Where(CanWinOnLine).First();
        }

        public List<Line> GetLines()
        {
            var lines = new List<Line>();

            //horizontal
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 1), new Position(_gameState, 2), new Position(_gameState, 3) } });
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 4), new Position(_gameState, 5), new Position(_gameState, 6) } });
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 7), new Position(_gameState, 8), new Position(_gameState, 9) } });

            //vertical                                                             
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 1), new Position(_gameState, 4), new Position(_gameState, 7) } });
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 2), new Position(_gameState, 5), new Position(_gameState, 8) } });
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 3), new Position(_gameState, 6), new Position(_gameState, 9) } });

            //diagonal                                                                                               
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 1), new Position(_gameState, 5), new Position(_gameState, 9) } });
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 2), new Position(_gameState, 5), new Position(_gameState, 8) } });
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 3), new Position(_gameState, 5), new Position(_gameState, 7) } });

            return lines;
        }

        public List<Position> GetPositions()
        {
            var positions = new List<Position>();

            positions.Add(new Position(_gameState, 1));
            positions.Add(new Position(_gameState, 2));
            positions.Add(new Position(_gameState, 3));
            positions.Add(new Position(_gameState, 4));
            positions.Add(new Position(_gameState, 5));
            positions.Add(new Position(_gameState, 6));
            positions.Add(new Position(_gameState, 7));
            positions.Add(new Position(_gameState, 8));
            positions.Add(new Position(_gameState, 9));

            return positions;
        }

        private bool CanWinOnLine(Line line)
        {
            return HasTwoComputerSymbols(line) && ContainsEmptySpace(line);
        }

        private bool HasTwoComputerSymbols(Line line)
        {
            return line.Positions.Count(pos => pos.Symbol == _gameState.ComputerSymbol) == 2;
        }

        private bool ContainsEmptySpace(Line line)
        {
            return line.Positions.Count(pos => pos.Symbol == " ") == 1;
        }
    }
}
