using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class String_SortCharactersInAString
    {
        public static void Init()
        {
            Console.WriteLine("Hello");
            sortString("hihi");
        }

        private static void sortString(string s)
        {
            int end = s.Length;
            char temp;
            char[] a = s.ToCharArray();

            for (int i = 0; i < end; i++)
            {
                for (int j = i + 1; j < end; j++)
                {
                    if (a[j] < a[i])
                    {
                        temp = a[j];
                        a[j] = a[i];
                        a[i] = temp;
                    }
                }
            }

            Console.Write(a);
        }
    }
}

//yehuda.bamnolker@ca.com
