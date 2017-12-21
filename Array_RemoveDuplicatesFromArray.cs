using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Array_RemoveDuplicatesFromArray
    {
        public static void Init(char[] str)
        {
            removeDuplicatesInPlace(str);
            removeDuplicatesUsingBuffer(str);

            foreach (char c in str)
            {
                if (c == '0')
                    break;
                Console.Write(c);
            }
        }

        public static void removeDuplicatesInPlace(char[] str)
        {
            if (str == null) return;
            int len = str.Length;
            if (len < 2) return;

            int tail = 1;

            for (int i = 1; i < len; ++i)
            {
                int j;
                for (j = 0; j < tail; ++j)
                {
                    if (str[i] == str[j]) break;
                }
                if (j == tail)
                {
                    str[tail] = str[i];
                    ++tail;
                }
            }
            str[tail] = '0';
        }

        public static void removeDuplicatesUsingBuffer(char[] str)
        {
            if (str == null) return;
            int len = str.Length;
            if (len < 2) return;
            bool[] hit = new bool[256];
            for (int i = 0; i < 256; ++i)
            {
                hit[i] = false;
            }
            hit[str[0]] = true;
            int tail = 1;
            for (int i = 1; i < len; ++i)
            {
                if (!hit[str[i]])
                {
                    str[tail] = str[i];
                    ++tail;
                    hit[str[i]] = true;
                }
            }
        }

    }
}
