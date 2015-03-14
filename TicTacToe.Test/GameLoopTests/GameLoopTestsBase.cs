using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TicTacToe.Test.GameLoopTests
{
    public class GameLoopTestsBase
    {
        protected Game _game;

        [SetUp]
        public void Setup()
        {
            GameStarted();
        }

        private void GameStarted()
        {
            _game = new Game();
            _game.GameState.PlayerSymbol = "x";
            _game.GameState.ComputerSymbol = "o";
            _game.GameState.GameStatus = GameStatus.GameStarted;
        }

    }
}
