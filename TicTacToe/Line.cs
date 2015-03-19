using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Line
    {
        public bool IsEdge { get; set; }

        public Line()
        {
            Positions = new List<Position>();   
        }

        public List<Position> Positions { get; set; }
    }
}
