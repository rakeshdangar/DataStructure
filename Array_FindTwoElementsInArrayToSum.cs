using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Array_FindTwoElementsInArrayToSum
    {
        public static void Main()
        {
            int[] input = new int[]{1, 5, 5, 7, 8, 10, 18, 30, 34, 50, 65, 80, 86};
            
            Array.Sort(input);
            int sum = 100;
            int start = 0;
            int end = input.Length - 1;

            if(input[end-1] + input[end] < sum || input[start] + input[start+1] > sum)
                Console.WriteLine("There are no two numbers equal to the sum");
            else
                do
                {
                    Console.WriteLine("Start: " + start.ToString() + " " + "End: " + end.ToString());

                    if(input[start] + input[(end+start)/2] > sum)
                    {
                        end = end/2;
                        Console.WriteLine("First Half");
                    }
                    else if(input[(end+start)/2] + input[end] < sum)
                    {   
                        start = (end+start)/2;
                        Console.WriteLine("Second Half");
                    }
                    else if (input[start] + input[end] == sum)
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
