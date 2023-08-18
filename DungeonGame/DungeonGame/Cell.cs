using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public class Cell 
    {
        public readonly char CellIcon;
        public Vector2 CellPosition { get; set; }
        public bool IsWalkable { get; set; }
        public int Cost { get; set; }

        public Cell(char cellIcon, Vector2 cellPosition)
        {
            CellIcon = cellIcon;
            CellPosition = cellPosition;
            IsWalkable = true;
        }
    }
}
