using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe
{
    public class GameState
    {
        public string ComputerSymbol { get; set; }

        public string PlayerSymbol { get; set; }

        public string[] Board { get; set; }

        public GameStatus GameStatus { get; set; }

        public GameState()
        {
            Board = new []{ "1 ", "2 ", "3 " , "4 ", "5 ", "6 ", "7 ", "8 ", "9 " };
        }

    }
}
