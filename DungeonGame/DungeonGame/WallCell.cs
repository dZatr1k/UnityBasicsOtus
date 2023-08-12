using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public class WallCell : Cell
    {
        public WallCell(char cellIcon, Vector2 postion) : base(cellIcon, postion)
        {
            IsWalkable = false;
        }
    }
}
