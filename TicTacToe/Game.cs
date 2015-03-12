using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    //public enum PlaceTypes
    //{
    //    Edge, OppositeCorner, Corner
    //}

    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Position(int rowArg, int colArg)
        {
            Row = rowArg;
            Column = colArg;
        }
    }

    public class Game
    {
        public string ComputerSymbol { get; set; }

        public string PlayerSymbol { get; set; }

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
            GameState.Board[2, 0] = "o";

        }


        private void PlacePlayer(string userInput)
        {
            int target = int.Parse(userInput);
            
            var position = FindPosition(target);

            GameState.Board[position.Row, position.Column] = PlayerSymbol;
        }

        private static Position FindPosition(int target)
        {
            Dictionary<int, Position> map = new Dictionary<int, Position>();
            map.Add(1, new Position(0, 0));
            map.Add(2, new Position(0, 1));
            map.Add(3, new Position(0, 2));
            map.Add(4, new Position(1, 0));
            map.Add(5, new Position(1, 1));
            map.Add(6, new Position(1, 2));
            map.Add(7, new Position(2, 0));
            map.Add(8, new Position(2, 1));
            map.Add(9, new Position(2, 2));
            var place = map.First(x => x.Key == target).Value;
            return place;
        }


        //set up
        private void SetPlayerSymbols(string userInput)
        {
            PlayerSymbol = userInput;
            ComputerSymbol = Flip(PlayerSymbol);
            GameState.GameStatus = GameStatus.PromptingUserGoFirst;
        }

        private void StartGame(string userInput)
        {
            if (userInput == "y")
            {
                GameState.Board = new string[3,3] { {" ", " ", " "}, {" ", " ", " "}, {" ", " ", " "} };
                GameState.GameStatus = GameStatus.GameStarted;
            }
            else if (userInput == "n")
            {
                GameState.Board = new string[3, 3] { { " ", " ", " " }, { " ", "o", " " }, { " ", " ", " " } };
                GameState.GameStatus = GameStatus.GameStarted;
            }
        }

        private string Flip(string symbolArg)
        {
            return symbolArg == "x" ? "o" : "x";
        }
    }
}
