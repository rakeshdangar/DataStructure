using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class String_ReverseOrder
    {
        public static void ReverseWordsOrder(String inputstr)
        {
            // Write your code here
            if (String.IsNullOrEmpty(inputstr))
                Console.WriteLine("");

            StringBuilder sb = new StringBuilder();
            String[] str_arr = inputstr.Split(' ');
            for (int i = str_arr.Length - 1; i >= 0; i--)
            {
                sb.Append(str_arr[i]);
                if (i != 0)
                    sb.Append(" ");
            }
            Console.WriteLine(sb.ToString());
        }

        public static void PrintPyramidOfNumbers(int n)
        {
            int p = 1;
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(p.ToString() + " ");
                    p++;
                }
                Console.WriteLine();
            }
        }
    }
}
