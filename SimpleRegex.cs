using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class SimpleRegex
    {
        public static void Init()
        {
            SimpleRegex sm = new SimpleRegex();
            Console.WriteLine(sm.isMatch("a+b", "aab")); //true + following one character is same
            Console.WriteLine(sm.isMatch("a+b", "aaab")); //false
            Console.WriteLine(sm.isMatch("a*b", "aaaaab")); // true * following 0 or many characters are same
            Console.WriteLine(sm.isMatch("a*ab", "aaaaab")); // false * following 0 or many characters are same. Here it is none.
            Console.WriteLine(sm.isMatch("aa*aa+b", "aaaaab"));  //true * following 0 or many characters are same. Here it is zero.
            Console.WriteLine(sm.isMatch("aa*aa*ab", "aaaaab"));  //true * following 0 or many characters are same. Here it is 0.
            Console.WriteLine(sm.isMatch("aa*aa*ab", "aaaaaab"));  //false * following 0 or many characters are same. Here it is none.
        }
        
        public bool isMatch(string regex, string input)
        {
            int inputLen = input.Length;
            int regexLen = regex.Length;
            int i = 0, j = 0;
            while (i < regexLen || j < inputLen)
            {
                if (i + 1 < regexLen && regex[i + 1] == '*')
                {
                    //recursively
                    if (isMatch(regex.Substring(i + 2), input.Substring(j+1)))
                        return true;

                    while (j < inputLen && input[j] == regex[i])
                        j++;

                    i += 2; //Increment index to character after *
                }
                else if (i + 1 < regexLen && regex[i + 1] == '+')
                {
                    if (j < inputLen && input[j] == regex[i] && input[j+1] == regex[i])
                        j++;

                    j++; 
                    i += 2; //Increment index to character after +
                }
                else if (j < inputLen && i < regexLen)
                {
                    if (j < inputLen && input[j] != regex[i])
                    {
                        return false;
                    }
                    //Increment counter for both index as character matched 
                    i++;
                    j++;
                }
                else
                    return false;
            }
            return true;
        }
    }
}
