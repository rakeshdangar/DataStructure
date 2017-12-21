using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class BalancedBrackets
    {
        public static void hasBalancedBrackets(string str)
        {
            // WRITE YOUR CODE HERE
            var stack = new Stack<char>();
            //Dicitionary of allowed pair of Brackets
            var allowedBrackets = new Dictionary<char, char>() { { '(', ')' }, { '{', '}' }, { '[', ']' }, { '<', '>' } };

            var balancedBrackets = true;
            foreach (var chr in str)
            {
                if (allowedBrackets.ContainsKey(chr))
                {
                    stack.Push(chr); // if starting char then push on stack
                }
                else if (allowedBrackets.ContainsValue(chr)) //Check if char is allowed char, it is linear but still faster than creating another object
                {
                    balancedBrackets = stack.Any(); //not balanced if nothing to pop
                    if (balancedBrackets)
                    {
                        var startingChar = stack.Pop();
                        balancedBrackets = allowedBrackets.Contains(new KeyValuePair<char, char>(startingChar, chr)); //Check pair of Brackets is valid
                    }
                }
                if (!balancedBrackets) // if not balanced exit loop no need to continue
                {
                    break;
                }
            }
            Console.WriteLine(balancedBrackets && (stack.Count == 0) ? 1 : 0); //make sure stack is empty 
        }
    }
}
