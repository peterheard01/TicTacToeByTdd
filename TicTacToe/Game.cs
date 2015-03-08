using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        public string UserSymbol { get; set; }

        public string ComputerSymbol { get; set; }

        public GameState GameState { get; set; }

        public Game()
        {
            GameState = new GameState();
        }

        public void Generate()
        {
            if (UserSymbol == null)
            {
                GameState.Message = "Please choose your symbol";
            }
            else
            {
                GameState.Message = "Would you like to go first?";
                ComputerSymbol = Flip(UserSymbol);
            }

            GameState.Board = new string[9] { "_", "_", "_", "_", "_", "_", "_", "_", "_" };
        }

        private string Flip(string symbolArg)
        {
            return symbolArg == "x" ? "o" : "x";
        }
    }
}
