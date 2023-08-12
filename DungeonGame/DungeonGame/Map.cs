using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public class Vector2
    {
        public int X;
        public int Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Map
    {
        public readonly string StringMap = "wwwwwwwwwwwww\n" +
                                           "w..w.......ww\n" +
                                           "ww...w..w...w\n" +
                                           "w..w.ww..w..w\n" +
                                           "w..w...w.wwww\n" +
                                           "w..w.www....w\n" +
                                           "wwwwwwwwwwwww\n";
        public readonly Cell[,] Cell;

        public Map()
        {
            var lines = StringMap.Split('\n');
            Cell = new Cell[lines.Length - 1, lines[0].Length];
            for (int i = 0; i < lines.Length - 1; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    if(lines[i][j] == 'w')
                        Cell[i, j] = new WallCell('w', new Vector2(i, j));
                    else if (lines[i][j] == '.')
                        Cell[i, j] = new EmptyCell('.', new Vector2(i, j));
                }
            }
        }

        public override string ToString()
        {
            return StringMap;
        }
    }
}
