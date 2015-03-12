using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public Position PlayerTarget { get; set; }

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

            var playerPositions = FindPlayerPositions();

            if (playerPositions.Count == 2)
            {
                //same row
                if (playerPositions[0].Row == playerPositions[1].Row &&
                    (Math.Abs(playerPositions[0].Column - playerPositions[1].Column) == 1))
                {

                    //scan the columns for the empty space and place it there
                    for (int column = 0; column <= 2; column++)
                    {
                        if (GameState.Board[playerPositions[0].Row, column] == " ")
                        {
                            GameState.Board[playerPositions[0].Row, column] = ComputerSymbol;
                        }
                    }
                }

                            //same column
                else if (playerPositions[0].Column == playerPositions[1].Column &&
                    (Math.Abs(playerPositions[0].Row - playerPositions[1].Row) == 1))
                {
                    //scan the columns for the empty space and place it there
                    for (int row = 0; row <= 2; row++)
                    {
                        if (GameState.Board[row, playerPositions[0].Column] == " ")
                        {
                            GameState.Board[row, playerPositions[0].Column] = ComputerSymbol;
                        }
                    }
                }

            }

            




            else if (PlayerTarget.Row == 0 || PlayerTarget.Row == 2)
            {
                if (PlayerTarget.Row == 0)
                    GameState.Board[PlayerTarget.Row + 2, PlayerTarget.Column + 1] = "o";
                else if (PlayerTarget.Row == 2)
                    GameState.Board[PlayerTarget.Row - 2, PlayerTarget.Column + 1] = "o";

            }
            else if (PlayerTarget.Row == 1)
            {
                if (PlayerTarget.Column == 0)
                    GameState.Board[PlayerTarget.Row + 1, PlayerTarget.Column + 2] = "o";
                else if (PlayerTarget.Column == 2)
                    GameState.Board[PlayerTarget.Row + 1, PlayerTarget.Column - 2] = "o";
            }

        }

        private List<Position> FindPlayerPositions()
        {
            var retVals = new List<Position>();
            for (int row = 0; row <= 2; row++)
            {
                for (int column = 0; column <= 2; column++)
                {
                    if (GameState.Board[row,column] == PlayerSymbol)
                    {
                        retVals.Add(new Position(row,column));
                    }
                }
            }
            return retVals;

            //var retVals = new List<Position>();
            //retVals.AddRange(GameState.Board[]);

            //foreach (var position in GameState.Board)
            //{
            //    if(position.)
            //}
        }


        private void PlacePlayer(string userInput)
        {
            
            int target = int.Parse(userInput);

            PlayerTarget = FindPosition(target);

            GameState.Board[PlayerTarget.Row, PlayerTarget.Column] = PlayerSymbol;
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
