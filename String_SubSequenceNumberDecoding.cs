using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class String_SubSequenceNumberDecoding
    {
        //NOTE : See problem statement at the bottom
        public static void Init()
        {
            string input = "12312"; // "123123123";
            String_SubSequenceNumberDecoding decode = new String_SubSequenceNumberDecoding();
            Console.WriteLine("Total possible decodings (using buffer) are {0}", decode.numDecodingsUsingBuffer(input));
            Console.WriteLine("Total possible decodings (using temp variables) are {0}", decode.numDecodingsUsingTempVariables(input));
        }


        public int numDecodingsUsingBuffer(String s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }
            int n = s.Length;
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = s[0] != '0' ? 1 : 0;
            for (int i = 2; i <= n; i++)
            {
                int first = int.Parse(s.Substring(i - 1, 1));
                int second = int.Parse(s.Substring(i - 2, 2));

                if (first >= 1 && first <= 9)
                {
                    dp[i] += dp[i - 1];
                }
                if (second >= 10 && second <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }
            return dp[n];
        }

        public int numDecodingsUsingTempVariables(String s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }
            int n = s.Length;
            int final_total = 1;
            int two_digit_total = 1;
            int temp_total = 0;
            List<string> solutions = new List<string>();
            for (int i = 2; i <= n; i++)
            {
                int one_digit = int.Parse(s.Substring(i - 1, 1));
                int two_digit = int.Parse(s.Substring(i - 2, 2));

                if (one_digit >= 1 && one_digit <= 9)
                {
                    temp_total += final_total;
                }
                if (two_digit >= 10 && two_digit <= 26)
                {
                    temp_total += two_digit_total;
                }
                two_digit_total = final_total;
                final_total = temp_total;
                temp_total = 0;
            }
            return final_total;
        }

        private static string EncodeIntToString(string intPresentation)
        {
            const int AsciiOffset = 96; // for example 'a' ASCII code is 1 + 96 = 97

            return ((char)(int.Parse(intPresentation) + AsciiOffset)).ToString();
        }
    }
}

//Given:
//a encoded to 1
//b encoded to 2
//....
//z encoded to 26

//You can translate a number to a string:

//'123' can be translated to 'abc'
//but also can be translated to 'aw','lc' which gives 3 total translations
//'12' can be translated to 'ab' and 'l' -> 2 translations

//Write a function to get the number of valid combinations from a number like '123123123'
