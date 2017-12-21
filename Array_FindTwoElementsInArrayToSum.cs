using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Array_FindTwoElementsInArrayToSum
    {
        public static void Init()
        {
            List<int> input = new List<int>();
            foreach (string s in Console.ReadLine().Split(' '))
            {
                input.Add(int.Parse(s));
            }

            input.Sort();
            int sum = 100;
            int start = 0;
            int end = input.Count - 1;
            do
            {
                if (input[start] + input[end] == sum)
                {
                    Console.WriteLine("Value of element at {0} and {1} are adding upto {2}", input[start], input[end], sum);
                    break;
                }
                else if ((input[start] + input[end] < sum))
                    start++;
                else
                    end--;

            } while (start <= end);
        }
    }
}
