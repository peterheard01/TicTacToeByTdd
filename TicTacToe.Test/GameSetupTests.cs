using NUnit.Framework;
using System;
using System.Collections;

namespace TicTacToe.Test
{
    [TestFixture]
    public class GameSetupTests
    {
        private string[] _blankBoard = new string[9] {"_", "_", "_", "_", "_", "_", "_", "_", "_"};

        [Test]
        public void Game_Start_Game_Shows_Empty_Board_And_Prompts_User_To_Choose_Symbol()
        {
            var game = new Game();
            game.Generate();

            Assert.AreEqual(game.GameState.Message, "Please choose your symbol");
            CollectionAssert.AreEqual(game.GameState.Board, _blankBoard);
        }

        [TestCase("x","o")]
        [TestCase("o","x")]
        public void User_Chooses_Makes_SymbolChoice_Computer_Opposite_And_Prompts_For_UserFirst_Choice(string userSymbolChoice, string computerSymbolChoice)
        {
            var game = new Game();
            game.UserSymbol = userSymbolChoice;
            game.Generate();

            Assert.AreEqual(game.ComputerSymbol, computerSymbolChoice);
            Assert.AreEqual(game.GameState.Message, "Would you like to go first?");
            CollectionAssert.AreEqual(game.GameState.Board, _blankBoard);
        }
        
    }
}
