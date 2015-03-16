using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum Orientation{ Horizontal, Vertical }

    public class Line
    {
        public Line()
        {
            Positions = new List<Position>();   
        }

        public List<Position> Positions { get; set; }
        public Orientation Orientation { get; set; }
    }
}
