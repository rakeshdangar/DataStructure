using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Array_MergeSortedArrayUsingHeap
    {
        public static void Init()
        {
            int[][] arrays = new int[][] 
            {
              new int[] {1, 1, 1, 1, 1, 1, 0},
              new int[] {1, 1, 1, 1, 1, 1, 0},
              new int[] {1, 1, 1, 1, 1, 1, 0},
              new int[] {1, 1, 1, 1, 1, 1, 1},
              new int[] {1, 1, 1, 1, 1, 1, 1}
            };

            Array_MergeSortedArrayUsingHeap.MergeSortedArray(arrays);
        }

        private static void MergeSortedArray(int[][] arrays)
        {
            HashSet<int[]> heap = new HashSet<int[]>();
            foreach(int[] arr in arrays)
            {
                heap.Add(arr);
            }
        }
    }
}
