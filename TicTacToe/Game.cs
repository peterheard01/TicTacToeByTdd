using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        public string UserChoice { get; set; }

        public string ComputerSymbol { get; set; }

        public string UserSymbol { get; set; }

        public GameState GameState { get; set; }

        public Game()
        {
            GameState = new GameState();
        }

        public void Generate()
        {
            if (UserChoice == null)
            {
                GameState.Message = "Please choose your symbol, 'x' or 'o'";
            }
            else
            {
                if (UserChoice == "y")
                {
                    GameState.Message = "Please make your move by typing 1-9";
                }
                else
                {
                    GameState.Message = "Would you like to go first? please type 'y' or 'n'";
                    UserSymbol = UserChoice;
                    ComputerSymbol = Flip(UserChoice);
                }

                
            }

            GameState.Board = new string[9] { "_", "_", "_", "_", "_", "_", "_", "_", "_" };
        }

        private string Flip(string symbolArg)
        {
            return symbolArg == "x" ? "o" : "x";
        }
    }
}
