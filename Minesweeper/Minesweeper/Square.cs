using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal class Square
    {
        bool isMine = false;
        bool isFlagged = false;
        bool isRevealed = false;
        int Row;
        int Column;
        int AdjacentMines = 0;

        public Square(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
