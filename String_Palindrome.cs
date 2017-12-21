using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class String_Palindrome
    {
        public static void Init()
        {
            String_Palindrome pal = new String_Palindrome();
            foreach (string s in pal.SubStringPalindrome("abaabbaca"))
            {
                Console.WriteLine(s);
            }
        }

        public static void IsPalindrome(string s)
        {
            int start = 0;
            int end = s.Length - 1;

            while (start < end)
            {
                if (s[start] != s[end])
                {
                    Console.WriteLine("String {0} is NOT a palindrome", s);
                    return;
                }

                start++;
                end--;
            }

            Console.WriteLine("String {0} is a palindrome", s);
        }

        public List<string> SubStringPalindrome(string palindrome)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < palindrome.Length; i++)
            {
                ExpandPalindrome(palindrome, result, i, i + 1);

                ExpandPalindrome(palindrome, result, i, i);
            }
            return result;
        }

        private void ExpandPalindrome(string pal, List<string> result, int loc, int nextLoc)
        {
            int subStringLength = 0;
            while (loc >= 0 && nextLoc < pal.Length && pal[loc] == pal[nextLoc])
            {
                subStringLength = nextLoc - loc + 1;

                if (!result.Contains(pal.Substring(loc, subStringLength)))
                {
                    result.Add(pal.Substring(loc, subStringLength));
                }

                loc--;
                nextLoc++;
            }
        }
    }
}
