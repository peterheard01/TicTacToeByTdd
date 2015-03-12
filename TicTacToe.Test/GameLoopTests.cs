using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace TicTacToe.Test
{
    [TestFixture]
    public class GameLoopTests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            GameStarted();
        }

        private void GameStarted()
        {
            _game = new Game();
            _game.UserSymbol = "x";
            _game.ComputerSymbol = "o";
            _game.GameState.GameStatus = GameStatus.GameStarted;
        }


        //[TestCase(new string[9] {   "_", "_", "_", 
        //                            "_", "o", "_", 
        //                            "_", "_", "_" },
        //                            "4", new string[9] 
        //{                           "_", "_", "_", 
        //                            "x", "o", "_", 
        //                            "_", "_", "o" })]
        //[TestCase(new string[9] {   "_", "_", "_", 
        //                            "x", "o", "_", 
        //                            "_", "_", "o"  },
        //                            "3", new string[9] 
        //{                           "_", "_", "x", 
        //                            "x", "o", "_", 
        //                            "o", "_", "o" })]
        //[TestCase(new string[9] {   "_", "_", "x", 
        //                            "x", "o", "_", 
        //                            "o", "_", "o"  },
        //                            "8", new string[9] 
        //{                           "o", "_", "x", 
        //                            "x", "o", "_", 
        //                            "o", "x", "o" })]
        //[TestCase(new string[9] {   "_", "_", "x", 
        //                            "x", "o", "_", 
        //                            "o", "_", "o"  },
        //                            "1", new string[9] 
        //{                           "x", "_", "x", 
        //                            "x", "o", "_", 
        //                            "o", "o", "o" })]

        //triangulation
        //[TestCase(new string[9] {   "_", "_", "_", 
        //                            "_", "o", "_", 
        //                            "_", "_", "_" },
        //                            "2", new string[9] 
        //{                           "_", "x", "_", 
        //                            "_", "o", "_", 
        //                            "o", "_", "_" })]
        //[TestCase(new string[9] {   "_", "x", "_", 
        //                            "_", "o", "_", 
        //                            "o", "_", "_" },
        //                            "3", new string[9]
        //{                           "o", "x", "x", 
        //                            "_", "o", "_", 
        //                            "o", "_", "_" })]
        //public void Computer_Went_First(string[] start, string userInput, string[] end)
        //{
        //    _game.GameState.Board = start;
        //    _game.ReadUserInput(userInput);
        //    CollectionAssert.AreEqual(_game.GameState.Board, end);
        //}

    }
}
