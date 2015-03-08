using NUnit.Framework;

namespace TicTacToe.Test
{
    [TestFixture]
    public class GameStartedTests
    {
        [Test]
        public void Player_Chooses_Center_Computer_Chooses_First_Available_Corner()
        {
            var game = new Game();
            game.UserSymbol = "x";
            game.ComputerSymbol = "o";
            game.UserChoice = "5";
            game.Generate();

            Assert.AreEqual(game.GameState.Message, "Please make your move by typing 1-9");
            CollectionAssert.AreEqual(game.GameState.Board, new string[9] { "o", "_", "_", "_", "x", "_", "_", "_", "_" });

        }
    }
}
