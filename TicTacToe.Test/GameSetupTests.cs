using NUnit.Framework;


namespace TicTacToe.Test
{
    [TestFixture]
    public class GameSetupTests
    {
        private readonly string[] _blankBoard = new string[9] {"_", "_", "_", "_", "_", "_", "_", "_", "_"};

        [Test]
        public void Game_Start_Game_Shows_Empty_Board_And_Prompts_User_To_Choose_Symbol()
        {
            var game = new Game();
            game.Generate();

            Assert.AreEqual(game.GameState.Message, "Please choose your symbol, 'x' or 'o'");
            CollectionAssert.AreEqual(game.GameState.Board, _blankBoard);
        }

        [TestCase("x","o")]
        [TestCase("o","x")]
        public void User_Makes_SymbolChoice_Computer_Makes_Opposite_And_Prompts_For_User_Go_First(string userSymbolChoice, string computerSymbolChoice)
        {
            var game = new Game();
            game.UserChoice = userSymbolChoice;
            game.Generate();

            Assert.AreEqual(game.UserSymbol, userSymbolChoice);
            Assert.AreEqual(game.ComputerSymbol, computerSymbolChoice);
            Assert.AreEqual(game.GameState.Message, "Would you like to go first? please type 'y' or 'n'");
            CollectionAssert.AreEqual(game.GameState.Board, _blankBoard);
        }

        [Test]
        public void User_Chooses_To_Go_First_Then_Computer_Prompts_For_Their_Move_And_Blank_Board()
        {
            var game = new Game();
            game.UserSymbol = "x";
            game.UserChoice = "y";
            game.Generate();

            Assert.AreEqual(game.GameState.Message, "Please make your move by typing 1-9");
            CollectionAssert.AreEqual(game.GameState.Board, _blankBoard);

        }
        
    }
}
