using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TicTacToe.Test
{
    [TestClass]
    public class TicTacToeEngineTests
    {
        [TestMethod]
        public void On_Game_Start_Game_Shows_Empty_Board_And_Prompts_User_To_Choose_Symbol()
        {
            var gameState = new Game().Generate(null);
            
            Assert.AreEqual(gameState.Message, "Please choose your symbol");
            CollectionAssert.AreEqual(gameState.Board, new string[9] { "_", "_", "_", "_", "_", "_", "_", "_", "_" });
        }

        
    }
}
