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
        [TestCase(" | |x" +
                   " |o| " +
                   "o| | ",
                   "8",
                   "o| |x" +
                   " |o| " +
                   "o|x| ")]
        [TestCase(" | |x" +
                   " |o| " +
                   "o| | ",
                   "6",
                   " | |x" +
                   " |o|x" +
                   "o| |o")]//can make triangle
        [TestCase("o| |x" +
                   " |o| " +
                   "o|x| ",
                   "9",
                   "o| |x" +
                   "o|o| " +
                   "o|x|x")]//player takes diagonal so take triangle

        
        //////triangulation
        [TestCase(" | | " +
                   " |o| " +
                   " | | ",
                   "1",
                   "x| | " +
                   " |o| " +
                   " | |o")]
        [TestCase("x| | " +
                   " |o| " +
                   " | |o",
                   "6",
                   "x| | " +
                   " |o|x" +
                   "o| |o")]
        [TestCase("x| | " +
                   " |o|x" +
                   "o| |o",
                   "3",
                   "x| |x" +
                   " |o|x" +
                   "o|o|o")]//player takes diagonal so take triangle

        [TestCase("x| | " +
                   " |o|x" +
                   "o| |o",
                   "8",
                   "x| |o" +
                   " |o|x" +
                   "o|x|o")]//player takes triangle so take diagonal


        [TestCase("x| | " +
                  " |o| " +
                  " | |o",
                  "3",
                  "x|o|x" +
                  " |o| " +
                  " | |o")]//tie condition
        [TestCase("x| | " +
                  " |o| " +
                  " | |o",
                  "7",
                  "x| | " +
                  "o|o| " +
                  "x| |o")]//tie condition
        public void Computer_Goes_First_Player_Marks_Corner(string start, string userInput, string end)
        {
            _game.GameState.Board = Helper.CreateBoardFromTestData(start);
            _game.ReadUserInput(userInput);
            CollectionAssert.AreEqual(Helper.CreateTestDataFromBoard(_game.GameState.Board), end);
        }
    }
}
