using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public class EmptyCell : Cell
    {
        public EmptyCell(char cellIcon, Vector2 postion) : base(cellIcon, postion)
        {
        }
    }
}
