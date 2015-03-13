namespace TicTacToe.Test
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

        public static string CreateTestDataFromBoard(string[,] board)
        {
            return board[0, 0] + "|" + board[0, 1] + "|" + board[0, 2] +
                   board[1, 0] + "|" + board[1, 1] + "|" + board[1, 2] +
                   board[2, 0] + "|" + board[2, 1] + "|" + board[2, 2];
        }
    }
}
