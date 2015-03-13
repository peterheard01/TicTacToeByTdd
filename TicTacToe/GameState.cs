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

        public string[,] Board { get; set; }

        public GameStatus GameStatus { get; set; }

        public GameState()
        {
            Board = new string[3, 3] { { "_", "_", "_" }, { "_", "_", "_" }, { "_", "_", "_" } };
        }

    }
}
