using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class String_Anagram
    {
        public static void Init(string s, string t)
        {
            Console.WriteLine("Given string " + s + " and " + t + " are same : " + AreStringSame(s, t));
        }

        public static bool AreStringSame(String s, String t)
        {
            if (s.Length != t.Length) return false;
            int[] letters = new int[256];

            int number_of_unique_char = 0;
            int number_completed_char = 0;

            foreach (char c in s)
            {
                if (letters[(int)c] == 0)
                {
                    number_of_unique_char++;
                }
                ++letters[(int)c];
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (letters[(int)t[i]] == 0)
                    return false;

                --letters[(int)t[i]];

                if (letters[(int)t[i]] == 0)
                {
                    number_completed_char++;
                }

                if (number_completed_char == number_of_unique_char)
                    return i == t.Length - 1;
            }

            return false;
        }
    }
}
