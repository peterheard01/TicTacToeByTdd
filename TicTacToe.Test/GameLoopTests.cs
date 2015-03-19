using NUnit.Framework;

namespace TicTacToe.Test
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
            _game.GameState.PlayerSymbol = "o";
            _game.GameState.ComputerSymbol = "x";
            _game.GameState.GameStatus = GameStatus.GameStarted;
        }

        [TestCase(new[]
        {
            "x", "o", " ", 
            "o", "x", " ", 
            " ", " ", " "
        }, "7", new[]
        {
            "x", "o", " ", 
            "o", "x", " ", 
            "o", " ", "x"
        })]//test win [first diagonal]
        [TestCase(new[]
        {
            " ", "x", "o", 
            " ", "x", " ", 
            " ", " ", "o"
        }, "4", new[]
        {
            " ", "x", "o", 
            "o", "x", " ", 
            " ", "x", "o"
        })]//test win [first vertical]
        [TestCase(new[]
        {
            "x", "x", " ", 
            "o", "o", " ", 
            " ", " ", " "
        }, "8", new[]
        {
            "x", "x", "x", 
            "o", "o", " ", 
            " ", "o", " "
        })]//test win [first horizontal]

        [TestCase(new[]
        {
            "x", "x", " ", 
            "o", "o", " ", 
            "o", "x", " "
        }, "9", new[]
        {
            "x", "x", "x", 
            "o", "o", " ", 
            "o", "x", "o"
        })]//test win [first horizontal]

        public void Test_Win(string[] start, string userInput, string[] end)
        {
            _game.GameState.Board = Helper.Setup(start);
            _game.ReadUserInput(userInput);
            var endState = Helper.Setup(end);
            CollectionAssert.AreEqual(_game.GameState.Board, endState);
        }

    }
}
