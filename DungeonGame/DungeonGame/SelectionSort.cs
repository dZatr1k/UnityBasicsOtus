using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public static class SelectionSort
    {
        public static int FindMinIndex(int start, int[] array)
        {
            int min = start;
            for (int i = start; i < array.Length; i++)
            {
                if (array[min] > array[i])
                    min = i;
            }
            return min;
        }

        public static void Swap(int[] array, int i, int j)
        {
            var a = array[i];
            array[i] = array[j];
            array[j] = a;
        }

        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                Swap(array, FindMinIndex(i, array), i);
            }
        }
    }
}
