using System;
using NUnit.Framework;

namespace TicTacToe.Test
{
    [TestFixture]
    public class GameStartedTests
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
            
        }

        //[Test]
        //public void Symbols_Chosen_User_Chooses_Go_Second_Then_Computer_Chooses_Middle()
        //{
        //    _game.UserChoice = "n";
        //    _game.Generate();

        //    Assert.AreEqual(_game.GameState.Message, "Please make your move by typing 1-9");
        //    CollectionAssert.AreEqual(_game.GameState.Board, new string[9] { "_", "_", "_", "_", "o", "_", "_", "_", "_" });

        //}


        //[TestCase(new string[9] { "_", "_", "_", "_", "_", "_", "_", "_", "_" }, new string[9] { "_", "_", "_", "_", "o", "_", "_", "_", "_" })]
        //public void Symbols_Chosen_User_Chooses_Go_Second_Comoputer_Chooses_Middle(string[] start, string[] end)
        //{
        //    _game.Generate();

        //    Assert.AreEqual(_game.GameState.Message, "Please make your move by typing 1-9");
        //    CollectionAssert.AreEqual(_game.GameState.Board, new string[9] { "o", "_", "_", "_", "x", "_", "_", "_", "_" });

        //}


    }
}
