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

        [TestCase(new string[9] {   "_", "_", "_", 
                                    "_", "o", "_", 
                                    "_", "_", "_" }, 
                                    "1", new string[9] ///////
        {                           "x", "_", "_", 
                                    "_", "o", "_", 
                                    "_", "_", "_" })]

        //[TestCase(new string[9] {   "_", "_", "_", 
        //                            "_", "o", "_", 
        //                            "_", "_", "_" },
        //                            "4", new string[9] ///////
        //{                           "_", "_", "o", 
        //                            "x", "o", "_", 
        //                            "_", "_", "_" })]
        public void Cases(string[] start, string userInput, string[] end)
        {
            _game.GameState.Board = start;
            _game.ReadUserInput(userInput);
            CollectionAssert.AreEqual(_game.GameState.Board, end);
        }

        //user goes first
        //[Test]
        //public void User_Goes_First_Computer_Responds()
        //{
        //    _game.ReadUserInput("5");
        //    CollectionAssert.AreEqual(_game.GameState.Board, new string[9] { "o", "_", "_", "_", "x", "_", "_", "_", "_" });
        //}


        


    }
}
