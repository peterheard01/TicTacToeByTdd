using System;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;


namespace TicTacToe.Test
{
    [TestFixture]
    public class GameSetupTests
    {
        [Test]
        public void Prompt_For_User_Symbol()
        {
            var game = new Game();
            
            Assert.AreEqual(game.GameState.GameStatus, GameStatus.PromptingUserSymbol);
            Assert.AreEqual(game.Prompt(), "Which symbol would you like? plese type 'x' or 'o'");
        }

        [TestCase("x","o")]
        [TestCase("o", "x")]
        public void Save_User_Symbol_And_Flip_Computer_Symbol_And_Prompt_For_Go_First(string userSymbol, string computerSymbol)
        {
            var game = new Game();
            game.GameState.GameStatus = GameStatus.PromptingUserSymbol;
            game.ReadUserInput(userSymbol);

            Assert.AreEqual(game.GameState.PlayerSymbol, userSymbol);
            Assert.AreEqual(game.GameState.ComputerSymbol, computerSymbol);
            Assert.AreEqual(game.GameState.GameStatus,GameStatus.PromptingUserGoFirst);
            Assert.AreEqual(game.Prompt(), "Would you like to go first? please type 'y' or 'n'");
        }


        [TestCase("y", " | | " +
                       " | | " +
                       " | | ")]
        [TestCase("n", " | | " +
                       " |o| " +
                       " | | ")]
        public void User_Prompted_To_Go_First(string userChoice, string board)
        {
            var game = new Game();
            game.GameState.GameStatus = GameStatus.PromptingUserGoFirst;
            game.ReadUserInput(userChoice);

            Assert.AreEqual(game.GameState.Board, Helper.CreateBoardFromTestData(board));
            Assert.AreEqual(game.GameState.GameStatus, GameStatus.GameStarted);
            Assert.AreEqual(game.Prompt(), "Please make your move by typing 1-9");
        }

        [Test]
        public void Game_Started_Prompt_User_Move()
        {
            var game = new Game();
            game.GameState.GameStatus = GameStatus.GameStarted;

            Assert.AreEqual(game.GameState.GameStatus, GameStatus.GameStarted);
            Assert.AreEqual(game.Prompt(), "Please make your move by typing 1-9");
        }


    }
}
