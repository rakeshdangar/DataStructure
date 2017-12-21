using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Array_MaxProductProfit
    {
        public static void Init()
        {
            List<int> l1 = new List<int> { 0, 3, 0, -2, 1, -5, 1, 1, -4 };
            Console.WriteLine(MaxThreeProduct(l1).ToString());
        }

        public static int MaxThreeProduct(List<int> input)
        {
            if (null == input)
                throw new ArgumentNullException("This method doesn't except null arguments!");

            if (input.Count < 3)
                throw new ArgumentNullException("This method doesn't except null arguments!");

            List<int> topThree = new List<int>();
            topThree.Add(input[0]);
            topThree.Add(input[1]);
            topThree.Add(input[2]);
            topThree.Sort();

            for (int i = 3; i < input.Count; i++)
            {
                if (input[i] > topThree[0])
                {
                    topThree.Remove(topThree[0]);
                    topThree.Add(input[i]);
                    topThree.Sort();
                }
            }

            //Can't for a MaxProfit if top element is negative
            if (topThree[0] < 0)
                throw new ArgumentException("arguments not valid!");
            else if (topThree[1] < 0)
                return topThree[0];
            else if (topThree[2] < 0)
                return topThree[0] * topThree[1];
            else
                return topThree[0] * topThree[1] * topThree[2];
        }
    }
}
