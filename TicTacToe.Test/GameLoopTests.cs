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
        })]//test win
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
        })]//test win
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
        })]//test win
        [TestCase(new[]
        {
            "x", "x", "o", 
            "o", " ", " ", 
            "o", " ", "x"
        }, "8", new[]
        {
            "x", "x", "o", 
            "o", "x", " ", 
            "o", "o", "x"
        })]//test win

        public void Tests(string[] start, string userInput, string[] end)
        {
            _game.GameState.Board = Helper.Setup(start);
            _game.ReadUserInput(userInput);
            var endState = Helper.Setup(end);
            CollectionAssert.AreEqual(_game.GameState.Board, endState);
        }

    }
}
