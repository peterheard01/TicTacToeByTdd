namespace TicTacToe.Test
{
    public class Helper
    {
        public static string[] Setup(string[] board)
        {
            for (int i = 1; i < 10; i++)
            {
                board[i-1] = i + board[i-1];
            }
            return board;
        }
    }
}
