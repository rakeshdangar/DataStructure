sing System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Array_FindMaxDuplicateInArray
    {
        public static void Main()
        {
            int[] a = { 1, 2, 3, 3, 4, 5, 3, 6, 3, 3, 4, 4, 4, 4, 4};
            Array_FindMaxDuplicateInArray f = new Array_FindMaxDuplicateInArray();
            Console.WriteLine(f.FindDuplicate(a).ToString());
            Console.WriteLine(f.FindIntDuplicate(a).ToString());
        }

        public int FindDuplicate(int[] a)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i=0; i<a.Length; i++)
            {
                if(dict.ContainsKey(a[i]))
                {
                    ++dict[a[i]];
                    if (a.Length / 2 <= dict[a[i]])
                        return a[i];
                }
                else
                    dict.Add(a[i], 1);
            }
           
            return dict.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;
        }

        public int FindIntDuplicate(int[] a)
        {
            int[] max = new int[a.Length];
            for (int i=0; i<a.Length; i++)
            {
                max[a[i]]++;
            }

            int maxDuplicate = 0;
            int ret = 0;
            for (int i=0; i<max.Length; i++)
            {
                if(max[i] > maxDuplicate)
                {
                    maxDuplicate = max[i];
                    ret = i;
                }
            }
           
            return ret;
        }
    }
}
