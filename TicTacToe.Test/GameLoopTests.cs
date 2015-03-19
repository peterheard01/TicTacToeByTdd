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
        public void Tests(string[] start, string userInput, string[] end)
        {
            _game.GameState.Board = Helper.Setup(start);
            _game.ReadUserInput(userInput);
            CollectionAssert.AreEqual(_game.GameState.Board, Helper.Setup(end));
        }

    }
}
