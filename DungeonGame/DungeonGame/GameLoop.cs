using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public static class GameLoop
    {
        public static Map Map;
        public static void Start()
        {
            Console.WriteLine("Добро пожаловать в DungeonGame");
            Console.WriteLine("Enter, чтобы начать");
            Console.ReadLine();

            Map = new Map();
            Console.Clear();
            Update();
        }

        private static void Update()
        {
            var path = PathFinder.FindPath(Map, new Vector2(1,1), new Vector2(Map.Cell.GetLength(0) - 2, Map.Cell.GetLength(1) - 2));

            for (int i = 0; i < path.Count; i++)
            {
                Console.Clear();
                DrawMap();
                var left = Console.CursorLeft;
                var top = Console.CursorTop;
                Console.SetCursorPosition(path[i].Y, path[i].X);
                Console.Write('P');
                Console.ReadLine();
            }
        }

        private static void DrawMap()
        {
            Console.WriteLine(Map);
        }
    }
}
