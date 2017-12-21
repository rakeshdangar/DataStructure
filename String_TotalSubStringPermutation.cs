using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class String_TotalSubStringPermutation
    {
        public static void Init(string str)
        {
            List<string> perm = getPerms(str);
            foreach (string s in perm)
            {
                Console.WriteLine(s);
            }
        }
        public static List<String> getPerms(String s)
        {
            List<String> permutations = new List<String>();
            if (s == null)
            { // error case
                return null;
            }
            else if (s.Length == 0)
            { // base case
                permutations.Add("");
                return permutations;
            }

            char first = s[0]; // get the first character
            String remainder = s.Substring(1); // remove the first character
            List<String> words = getPerms(remainder);
            foreach (string word in words)
            {
                for (int j = 0; j <= word.Length; j++)
                {
                    permutations.Add(insertCharAt(word, first, j));
                }
            }
            return permutations;
        }

        public static String insertCharAt(String word, char c, int i)
        {
            String start = word.Substring(0, i);
            String end = word.Substring(i);
            return start + c + end;
        }
    }
}
