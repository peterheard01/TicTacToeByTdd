using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Game
    {
        public GameState Generate(int? position)
        {
            var state = new GameState();
            state.Message = "Please choose your symbol";
            state.Board = new string[9] { "_", "_", "_", "_", "_", "_", "_", "_", "_" };
            return state;
        }
    }
}
