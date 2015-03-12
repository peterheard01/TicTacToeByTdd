using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Helper
    {
        public static string[,] CreateBoardFromTestData(string board)
        {
            board = board.Replace("|", "").Replace(",", "");

            var boardAs2dArray = new string[,] { { board[0].ToString(), board[1].ToString(), board[2].ToString() }, 
                                   { board[3].ToString(), board[4].ToString(), board[5].ToString() }, 
                                   { board[6].ToString(), board[7].ToString(), board[8].ToString() } };
            return boardAs2dArray;
        }
    }
}
