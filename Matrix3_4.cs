using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Matrix3_4
    {
        public static void draw()
        {
            int n = 3;
            int m = 4;
            int[][] arr = new int[n][];
            arr[0] = new int[] { 1, 2, 3, 4 };
            arr[1] = new int[] { 5, 6, 7, 8 };
            arr[2] = new int[] { 9, 10, 11, 12 };

            //ist=>i_start
            //jst=>j_start
            int i = n - 1, j = 0, ist, jst, count = 0;
            while (count < n * m)
            {
                ist = i; jst = j;
                while (i < n && j < m)
                {
                    Console.Write(arr[i][j] + " ");
                    count++;
                    i++; j++;
                }
                Console.WriteLine();
                i = (ist - 1) >= 0 ? ist - 1 : ist;
                j = (jst == 0 && (ist - 1) >= 0) ? 0 : jst + 1;
            }
        }
    }
}
