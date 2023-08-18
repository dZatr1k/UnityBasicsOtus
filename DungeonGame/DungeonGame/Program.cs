using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 1, 3, 9, 6, 1, 4, 7, 3, 8, 6, 26, 8, 92, 42, 2, 7, 6552347, 55 };
            Console.Write("Before: ");
            PrintArray(array);
            SelectionSort.Sort(array);
            Console.Write("After: ");
            PrintArray(array);
            Console.ReadLine();
            Console.Clear();
            GameLoop.Start();
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
