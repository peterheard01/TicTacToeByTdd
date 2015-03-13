using NUnit.Framework;

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
            _game.GameState.PlayerSymbol = "x";
            _game.GameState.ComputerSymbol = "o";
            _game.GameState.GameStatus = GameStatus.GameStarted;
        }


        [TestCase(" | | " +
                  " |o| " +
                  " | | ",
                    "2",
                    " |x| " +
                    " |o| " +
                    " | |o")]
        [TestCase(" |x| " +
                  " |o| " +
                  " | |o",
                    "1",
                    "x|x|o" +
                    " |o| " +
                    " | |o")]
        [TestCase("x|x|o" +
                  " |o| " +
                  " | |o",
                    "6",
                    "x|x|o" +
                    " |o|x" +
                    "o| |o")]


        //triangulation
        [TestCase(" | | " +
                  " |o| " +
                  " | | ",
                 "4",
                    " | | " +
                    "x|o| " +
                    " | |o")]
        [TestCase(" | | " +
                  "x|o| " +
                  " | |o",
                    "1",
                    "x| | " +
                    "x|o| " +
                    "o| |o")]
        [TestCase("x| | " +
                  "x|o| " +
                  "o| |o",
                    "3",
                    "x| |x" +
                    "x|o| " +
                    "o|o|o")]
        [TestCase("x|x|o" +
                  " |o| " +
                  " | |o",
                    "7",
                    "x|x|o" +
                    " |o|o" +
                    "x| |o")]
        public void Computer_Went_First(string start, string userInput, string end)
        {
            _game.GameState.Board = Helper.CreateBoardFromTestData(start);
            _game.ReadUserInput(userInput);
            CollectionAssert.AreEqual(Helper.CreateTestDataFromBoard(_game.GameState.Board), end);
        }
    }
}
