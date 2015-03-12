using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum PlaceTypes
    {
        Edge,OppositeCorner
    }

    public class Game
    {
        public string ComputerSymbol { get; set; }

        public string UserSymbol { get; set; }

        public GameState GameState { get; set; }

        public int PlayerTarget { get; set; }

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
            switch (GameState.GameStatus)
            {
                case GameStatus.GameStarted:
                    RunGameLoop(userInput);
                break;
                case GameStatus.PromptingUserGoFirst:
                    StartGame(userInput);
                break;
                default:
                    SetPlayerSymbols(userInput);
                break;
            }            
        }

        private void RunGameLoop(string userInput)
        {
            PlacePlayer(userInput);

            if (PlayerTarget == 1)
            {
                PlaceComputerAt(8);
            }
            else if (PlayerTarget == 3)
            {
                PlaceComputerAt(7);
            }
            else if (PlayerTarget == 8)
            {
                PlaceComputerAt(1);
            }
            else if (PlayerPlacedAt() == PlaceTypes.Edge)
            {
                PlaceComputer(PlaceTypes.OppositeCorner);
            }
        }

        private void PlaceComputer(PlaceTypes placeType)
        {
            if()

           // if (placeType == PlaceTypes.OppositeCorner)
               // PlaceComputerAt(9);
        }

        private void PlaceComputerAt(int targetPos)
        {
            GameState.Board[targetPos - 1] = ComputerSymbol;
        }

        private PlaceTypes? PlayerPlacedAt()
        {
            if (PlayerTarget == 2 || PlayerTarget == 4 || PlayerTarget == 6 || PlayerTarget == 8)
                return PlaceTypes.Edge;
            return null;
        }

        private void PlacePlayer(string userInput)
        {
            PlayerTarget = int.Parse(userInput);
            int pos = PlayerTarget - 1;
            GameState.Board[pos] = UserSymbol;
        }

        private void SetPlayerSymbols(string userInput)
        {
            UserSymbol = userInput;
            ComputerSymbol = Flip(UserSymbol);
            GameState.GameStatus = GameStatus.PromptingUserGoFirst;
        }

        private void StartGame(string userInput)
        {
            if (userInput == "y")
            {
                GameState.Board = new string[9] { "_", "_", "_", "_", "_", "_", "_", "_", "_" };
                GameState.GameStatus = GameStatus.GameStarted;
            }
            else if (userInput == "n")
            {
                GameState.Board = new string[9] { "_", "_", "_", "_", "o", "_", "_", "_", "_" };
                GameState.GameStatus = GameStatus.GameStarted;
            }
        }

        private string Flip(string symbolArg)
        {
            return symbolArg == "x" ? "o" : "x";
        }
    }
}
