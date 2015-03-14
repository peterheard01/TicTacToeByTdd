using NUnit.Framework;

namespace TicTacToe.Test.GameLoopTests
{
    public class GameLoopTestsCompFirstPlayerMarksCorner : GameLoopTestsBase
    {
        [TestCase(" | | " +
                  " |o| " +
                  " | | ",
                    "3",
                    " | |x" +
                    " |o| " +
                    "o| | ")]
        [TestCase(  " | |x" +
                    " |o| " +
                    "o| | ",
                    "2",
                    "o| |x" +
                    " |o| " +
                    "o|x| ")]

        [TestCase(" | | " +
                 " |o| " +
                 " | | ",
                   "1",
                   "x| | " +
                   " |o| " +
                   " | |o")]
        public void Computer_Goes_First_Player_Marks_Corner(string start, string userInput, string end)
        {
            _game.GameState.Board = Helper.CreateBoardFromTestData(start);
            _game.ReadUserInput(userInput);
            CollectionAssert.AreEqual(Helper.CreateTestDataFromBoard(_game.GameState.Board), end);
        }
    }
}
