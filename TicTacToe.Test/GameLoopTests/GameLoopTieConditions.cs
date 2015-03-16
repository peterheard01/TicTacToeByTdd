using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TicTacToe.Test.GameLoopTests
{
    public class GameLoopTieConditions : GameLoopTestsBase
    {
        [TestCase("x| | " +
                  " |o| " +
                  " | |o",
                  "3",
                  "x|o|x" +
                  " |o| " +
                  " | |o")]
        //triangulation
        [TestCase("x| | " +
                  " |o| " +
                  " | |o",
                  "7",
                  "x| | " +
                  "o|o| " +
                  "x| |o")]



        [TestCase(  "x|o|x" +
                    " |o| " +
                    " | |o",
                    "8",
                    "x|o|x" +
                    "o|o| " +
                    " |x|o")]
        [TestCase(  "x|o|x" +
                    "o|o| " +
                    " |x|o",
                    "6",
                    "x|o|x" +
                    "o|o|x" +
                    "o|x|o")]
        public void Computer_Goes_First_Player_Marks_Corner_Tie_Conditions(string start, string userInput, string end)
        {
            _game.GameState.Board = Helper.CreateBoardFromTestData(start);
            _game.ReadUserInput(userInput);
            CollectionAssert.AreEqual(Helper.CreateTestDataFromBoard(_game.GameState.Board), end);
        }
    }
}
