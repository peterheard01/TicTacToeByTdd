using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        public GameCondition? GetGameCondition()
        {
            if (GetLines().Any(ComputerCanWinOnLine)) return GameCondition.CanWin;
            if (GetLines().Any(ShouldBlockPlayerOnLine)) return GameCondition.ShouldBlock;
            if (ComputerCanFork()) return GameCondition.CanFork;
            if (ComputerCanTakeCentre()) return GameCondition.CanTakeCentre;
            if (ComputerCanTakeCorner()) return GameCondition.CanTakeCorner;
            if (ComputerCanTakeEdge()) return GameCondition.CanTakeEdge;
            return null;
        }

        private bool ComputerCanTakeEdge()
        {
            return GetPositions().Any(pos => pos.IsEdge && pos.Symbol == " ");
        }

        private bool ComputerCanTakeCorner()
        {
            return GetPositions().Any(pos => pos.IsCorner && pos.Symbol == " ");
        }

        private bool ComputerCanTakeCentre()
        {
            return GetPositions().Any(pos => pos.IsCentre && pos.Symbol == " ");
        }

        private bool ComputerCanWinOnLine(Line line)
        {
            return Has(line, _gameState.ComputerSymbol, 2) && ContainsEmptySpace(line);
        }

        private bool ShouldBlockPlayerOnLine(Line line)
        {
            return Has(line, _gameState.PlayerSymbol, 2) && ContainsEmptySpace(line);;
        }

        private bool PlayerCanWinOnLine(Line line)
        {
            return Has(line, _gameState.PlayerSymbol, 2) && ContainsEmptySpace(line);
        }

        private bool ComputerCanFork()
        {
            return HasCentrePosition(_gameState.ComputerSymbol) && GetLines().Any(IsForkableByComputer);
        }

        private bool IsForkableByComputer(Line lineArg)
        {
            return Has(lineArg, " ", 2) && Has(lineArg, _gameState.ComputerSymbol, 1) && lineArg.Positions.Any(pos => pos.Symbol == _gameState.ComputerSymbol && pos.IsCorner);
        }

        private bool HasCentrePosition(string symbolArg)
        {
            return GetPositions().Any(x => x.IsCentre && x.Symbol == symbolArg);
        }

        public List<Line> GetLines()
        {
            var lines = new List<Line>();

            //horizontal
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 1), new Position(_gameState, 2), new Position(_gameState, 3) },IsEdge = true});
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 4), new Position(_gameState, 5), new Position(_gameState, 6) } });
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 7), new Position(_gameState, 8), new Position(_gameState, 9) }, IsEdge = true});

            //vertical                                                             
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 1), new Position(_gameState, 4), new Position(_gameState, 7) },IsEdge = true });
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 2), new Position(_gameState, 5), new Position(_gameState, 8) } });
            lines.Add(new Line() { Positions = new List<Position>() { new Position(_gameState, 3), new Position(_gameState, 6), new Position(_gameState, 9) }, IsEdge = true });

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

        private bool Has(Line line, string symbolArg, int count)
        {
            return line.Positions.Count(pos => pos.Symbol == symbolArg) == count;
        }

        private bool ContainsEmptySpace(Line line)
        {
            return line.Positions.Count(pos => pos.Symbol == " ") == 1;
        }

        public Line FindComputerWinningLine()
        {
            return GetLines().Where(ComputerCanWinOnLine).First();
        }

        public Line FindPlayerWinningLine()
        {
            return GetLines().Where(PlayerCanWinOnLine).First();
        }

        internal Line FindForkableLine()
        {
            return GetLines().Where(IsForkableByComputer).First();
        }
    }
}
