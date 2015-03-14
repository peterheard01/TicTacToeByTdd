using NUnit.Framework;

namespace TicTacToe.Test.GameLoopTests
{
    [TestFixture]
    public class GameLoopTestsCompFirstPlayerMarksEdge : GameLoopTestsBase
    {
        
        //original flow
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
        //diagonal win
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

        //horizontal win 
        [TestCase("x| | " +
                  "x|o| " +
                  "o| |o",
                    "3",
                    "x| |x" +
                    "x|o| " +
                    "o|o|o")]
        //vertical win
        [TestCase("x|x|o" +
                    " |o| " +
                    " | |o",
                    "7",
                    "x|x|o" +
                    " |o|o" +
                    "x| |o")]
        public void Computer_Goes_First_Player_Marks_Edge(string start, string userInput, string end)
        {
            _game.GameState.Board = Helper.CreateBoardFromTestData(start);
            _game.ReadUserInput(userInput);
            CollectionAssert.AreEqual(Helper.CreateTestDataFromBoard(_game.GameState.Board), end);
        }
    }
}
