using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Array_MergeTwoSortedList
    {
        public void Init()
        {
            List<int> l1 = new List<int>{0,2,3};
            List<int> l2 = new List<int>{1,3,4,5};
            List<int> sort = CollateSortedLists(l1, l2);
            foreach (int i in sort)
            {
                Console.WriteLine(i.ToString());
            }
        }

        public static List<int> CollateSortedLists(List<int> l1, List<int> l2)
        {
            //List<int> sortedList = new List<int>();
            //int i = (l1.Count) - 1, j = (l2.Count) - 1, k = i + j;

            //while (k > 0)
            //    sortedList[--k] =
            //        (j < 0 || (i >= 0 && l1[i] >= l2[j])) ? l1[i--] : l2[j--];

            //return sortedList;

            //Check for null arguments.
            if (null == l1 && null == l2)
                return null;

            //if l1 is null doesn't have any element  then l2 is sortedList.
            if (null == l1 || l1.Count <= 0)
                return l2;

            //if l2 is null or doesn't have any element then l1 is sortedList
            if (null == l2 || l2.Count <= 0)
                return l1;

            List<int> sortedList = new List<int>();
            int i = 0, j = 0, k = 0;


            //Find smaller element from between l1 and l2 and copy it to sortedList
            while (i < l1.Count && j < l2.Count)
            {
                k = l1[i] < l2[j] ? l1[i++] : l2[j++];
                sortedList.Add(k);
            }

            //l1 has more elements than l2. Copy remaining elements from l1 to sortedList
            while (i < l1.Count)
            {
                k = l1[i++];
                sortedList.Add(k);
            }

            //l2 has more elements than l1. Copy remaining elements from l2 to sortedList
            while (j < l2.Count)
            {
                k = l2[j++];
                sortedList.Add(k);
            }


            return sortedList;

        }
    }
}
