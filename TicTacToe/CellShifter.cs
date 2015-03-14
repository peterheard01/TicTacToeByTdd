﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class CellShifter
    {
        public int ShiftOne(int pos)
        {
            int newPos = pos + 1;
            if (newPos > 2)
            {
                newPos = -1;
            }
            return newPos;
        }

        public int ShiftTwo(int pos)
        {
            int newPos = pos + 2;
            if (newPos > 2)
            {
                newPos = 0;
            }
            return newPos;
        }
    }
}
