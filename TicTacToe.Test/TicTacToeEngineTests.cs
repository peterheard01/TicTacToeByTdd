using NUnit.Framework;
using System;
using System.Collections;

namespace TicTacToe.Test
{
    [TestFixture]
    public class TicTacToeEngineTests
    {
        [Test]
        public void On_Game_Start_Game_Shows_Empty_Board_And_Prompts_User_To_Choose_Symbol()
        {
            var game = new Game();
            game.Generate();

            Assert.AreEqual(game.GameState.Message, "Please choose your symbol");
            CollectionAssert.AreEqual(game.GameState.Board, new string[9] { "_", "_", "_", "_", "_", "_", "_", "_", "_" });
        }

        [Test]
        public void User_Chooses_To_Be_x_Then_Game_Asks_If_They_Want_To_Go_First_And_Computer_Is_o()
        {
            var game = new Game();
            game.UserSymbol = "x";
            game.Generate();

            Assert.AreEqual(game.ComputerSymbol, "o");
            Assert.AreEqual(game.GameState.Message, "Would you like to go first?");
            CollectionAssert.AreEqual(game.GameState.Board, new string[9] { "_", "_", "_", "_", "_", "_", "_", "_", "_" });
        }

        [Test]
        public void User_Chooses_To_Be_o_Then_Game_Asks_If_They_Want_To_Go_First_And_Computer_Is_x()
        {
            var game = new Game();
            game.UserSymbol = "o";
            game.Generate();

            Assert.AreEqual(game.ComputerSymbol, "x");
            Assert.AreEqual(game.GameState.Message, "Would you like to go first?");
            CollectionAssert.AreEqual(game.GameState.Board, new string[9] { "_", "_", "_", "_", "_", "_", "_", "_", "_" });
        }

        
    }
}
