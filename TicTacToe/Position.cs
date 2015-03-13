namespace TicTacToe
{
    public class Position
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public bool IsCenter {
            get { return Row == 1 && Column == 1; }
        }

        public Position(int rowArg, int colArg)
        {
            Row = rowArg;
            Column = colArg;
        }
    }
}