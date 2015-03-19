using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class Game
    {
        private GameLoop _gameLoop;
        private GameCommands _gameCommands;

        public GameState GameState { get; set; }

        public Game()
        {
            GameState = new GameState();
            _gameCommands = new GameCommands(GameState);
            _gameLoop = new GameLoop(GameState,_gameCommands);
        }

        public string Prompt()
        {
            switch (GameState.GameStatus)
            {
                case GameStatus.PromptingUserSymbol:
                    return "Which symbol would you like? plese type 'x' or 'o'";
                case GameStatus.PromptingUserGoFirst:
                    return "Would you like to go first? please type 'y' or 'n'";
                default:
                    return "Please make your move by typing 1-9";
            }
        }

        public void ReadUserInput(string userInput)
        {
            switch (GameState.GameStatus)
            {
                case GameStatus.GameStarted:
                    _gameLoop.RunGameLoop(userInput);
                break;
                case GameStatus.PromptingUserGoFirst:
                    StartGame(userInput);
                break;
                default:
                    SetPlayerSymbols(userInput);
                break;
            }            
        }

        private void SetPlayerSymbols(string userInput)
        {
            GameState.PlayerSymbol = userInput;
            GameState.ComputerSymbol = FlipSymbol(GameState.PlayerSymbol);
            GameState.GameStatus = GameStatus.PromptingUserGoFirst;
        }

        private void StartGame(string userInput)
        {
            if (userInput == "y")
            {
                GameState.GameStatus = GameStatus.GameStarted;
            }
            else if (userInput == "n")
            {
                GameState.ComputerSymbol = "x";
                _gameCommands.PlaceSymbol(GameState.ComputerSymbol, 5);
                GameState.GameStatus = GameStatus.GameStarted;
            }
        }

        private string FlipSymbol(string symbolArg)
        {
            return symbolArg == "x" ? "o" : "x";
        }
    }
}
