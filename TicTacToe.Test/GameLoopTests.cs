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
            _game.PlayerSymbol = "x";
            _game.ComputerSymbol = "o";
            _game.GameState.GameStatus = GameStatus.GameStarted;
        }


        [TestCase(" | | " +
                                     " |o| " +
                                     " | | ",
                                     "2",
                                     " |x| " +
                                     " |o| " +
                                     " | |o")]

        [TestCase(                   " |x| " +
                                     " |o| " +
                                     " | |o",
                                     "1",
                                     "x|x|o" +
                                     " |o| " +
                                     " | |o")]


        //triangulation
        [TestCase(" | | " +
                                    " |o| " +
                                    " | | ",
                                    "4",
                                    " | | " +
                                    "x|o| " +
                                    " | |o")]

        //[TestCase(" | | " +
        //                            "x|o| " +
        //                            " | |o",
        //                            "1",
        //                            "x| | " +
        //                            "x|o| " +
        //                            "o| |o")]

        public void Computer_Went_First(string start, string userInput, string end)
        {
            _game.GameState.Board = Helper.CreateBoardFromTestData(start);
            _game.ReadUserInput(userInput);
            CollectionAssert.AreEqual(Helper.CreateTestDataFromBoard(_game.GameState.Board), end);
        }



        //[TestCase(new string[9] {   "_", "_", "_", 
        //                            "x", "o", "_", 
        //                            "_", "_", "o"  },
        //                            "3", new string[9] 
        //{                           "_", "_", "x", 
        //                            "x", "o", "_", 
        //                            "o", "_", "o" })]
        //[TestCase(new string[9] {   "_", "_", "_", 
        //                            "_", "o", "_", 
        //                            "_", "_", "_" },
        //                            "4", new string[9] 
        //{                           "_", "_", "_", 
        //                            "x", "o", "_", 
        //                            "_", "_", "o" })]




    }
}
