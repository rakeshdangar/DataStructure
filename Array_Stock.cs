using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Array_Stock
    {
        /// <summary>
        /// One buy & sale price that would give you maximum profit.
        /// </summary>
        public static void findMostProfit()
        {
            List<int> a = new List<int>();
            a.Add(15);
            a.Add(5);
            a.Add(10);
            a.Add(2);
            a.Add(30);
            a.Add(1);
            a.Add(7);
            a.Add(13);
            a.Add(23);
            a.Add(25);
            a.Add(9);

            int minCounter = 0;
            int maxProfit = 0;
            for (int i = 1; i < a.Count; i++)
            {
                if (a[minCounter] > a[i])
                    minCounter = i;
                if (a[i] > a[i - 1] && a[i] - a[minCounter] > maxProfit)
                    maxProfit = a[i] - a[minCounter];
            }
            Console.WriteLine("Max profit is: {0}", maxProfit.ToString());
        }
    }
}
