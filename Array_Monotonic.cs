using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Array_Monotonic
    {
        public static void Init()
        {
            Array_Monotonic m = new Array_Monotonic();

            int[] a = { 1,3,5,7,9};
            Console.WriteLine(m.is_monotonic(a).ToString());
            
            int[] b = { 1, 4, 5, 0, 0, 0 };
            int[] c = { 2, 6, 10 };
            b = m.inplace_merge(b, c);
            foreach (int i in b)
            {
                Console.Write(i.ToString() + ", ");
            }
        }
        
        // a has size 2*n, b size n
        // n = 3
        // a = [1, 4, 5, 0, 0, 0]
        // b = [2, 6, 10]
        // a = [1, 2, 4, 5, 6, 10]
        public int[] inplace_merge(int[] a, int[] b)
        {
            int i = 0, j = 0, temp = 0;
            while (i < a.Length && j < b.Length)
            {
                if (a[i] < b[j])
                {
                    temp = a[++i];
                    a[i] = b[j];
                    b[j] = temp;
                }
                else
                    j++;

            }
            return a;
        }

        // true: [1, 3, 3, 5]
        // true: [5, 3, 2]
        // false: [3, 5, 1]
        // false: [5, 3, 5]
        // true: [1, 1]
        public bool is_monotonic(int[] arr)
        {

            int asc = -1;
            bool monotonic = true;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                    continue;

                if (asc == -1)
                {
                    asc = (arr[i] < arr[i + 1]) ? 1 : 0;
                }

                if (asc == 1)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        monotonic = false;
                        break;
                    }
                }
                else
                {
                    if (arr[i] < arr[i + 1])
                    {
                        monotonic = false;
                        break;
                    }
                }
            }
            return monotonic;
        }
    }
}
