using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinesweeperMVVM.Model
{
    internal struct Square
    {
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; } = false;
        public bool IsRevealed { get; set; } = false;
        public int NeighbourMines { get; set; } = 0;

        public Square() { }
    }
}
