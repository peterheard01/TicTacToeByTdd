using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        //public string UserChoice { get; set; }

        public string ComputerSymbol { get; set; }

        public string UserSymbol { get; set; }

        public GameState GameState { get; set; }

        public Game()
        {
            GameState = new GameState();
        }

        public string Prompt()
        {
            if (GameState.GameStatus == GameStatus.PromptingUserSymbol)
            {
                return "Which symbol would you like? plese type 'x' or 'o'";
            }
            else if (GameState.GameStatus == GameStatus.PromptingUserGoFirst)
            {
                return "Would you like to go first? please type 'y' or 'n'";
            }
            else
            {
                return "Please make your move by typing 1-9";
            }
        }

        public void ReadUserInput(string userInput)
        {
            if (GameState.GameStatus == GameStatus.GameStarted)
            {
                GameState.Board[4] = ComputerSymbol;
                GameState.Board[0] = UserSymbol;

            }
            else if (GameState.GameStatus == GameStatus.PromptingUserGoFirst)
            {
                if (userInput == "y")
                {
                    GameState.Board = new string[9] {"_", "_", "_", "_", "_", "_", "_", "_", "_"};
                    GameState.GameStatus = GameStatus.GameStarted;
                }
                else if (userInput == "n")
                {
                    GameState.Board = new string[9] {"_", "_", "_", "_", "o", "_", "_", "_", "_"};
                    GameState.GameStatus = GameStatus.GameStarted;
                }
            }
            
            else
            {
                UserSymbol = userInput;
                ComputerSymbol = Flip(UserSymbol);
                GameState.GameStatus = GameStatus.PromptingUserGoFirst;
            }


        }



           

        //private string[] DrawBoard(string userChoiceArg)
        //{
        //    var board = new string[9] {"_", "_", "_", "_", "_", "_", "_", "_", "_"};
        //    if (userChoiceArg != "")
        //    {
        //        board[4] = ComputerSymbol;
        //    }
        //    return board;
        //}


        //private bool UserWantsToGoFirst()
        //{
        //    return UserChoice == "y";
        //}

        private string Flip(string symbolArg)
        {
            return symbolArg == "x" ? "o" : "x";
        }
    }
}
