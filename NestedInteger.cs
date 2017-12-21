using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class NestedInteger1
    {
        /**
         * Given a nested list of integers, returns the sum of all integers in the list weighted by their depth
         * For example, given the list [{1,1},2,{1,1}] the function should return 10 (four 1's at depth 2, one 2 at depth 1)
         * Given the list [1,{4,{6}}] the function should return 27 (one 1 at depth 1, one 4 at depth 2, and one 6 at depth 3) = depthSum([1,{4,{6}}]) = 27 = (1 * 1 + 4 * 2 + 6 * 3)
         */
        public static void Init()
        {
            NestedInteger1 nestedInt = new NestedInteger1();
            List<NestedInteger> nInt = new List<NestedInteger>( );
            //Console.WriteLine(nestedInt.depthSum(List[1,{4,{6}}]));
        }

        public int depthSum(List<NestedInteger> input)
        {
            int sum = 0;
            //foreach (NestedInteger i in input)
            //{
            //    if (i.isInteger())
            //        sum += i.getInteger();
            //    else
            //        sum += getNestedSum(i.getList(), sum, level++);
            //}
            sum = getNestedSum(input, sum, 1);
            return sum;
        }

        private int getNestedSum(List<NestedInteger> input, int sum, int level)
        {
            foreach (NestedInteger i in input)
            {
                if (i.isInteger())
                    sum += i.getInteger() * level;
                else
                    sum += getNestedSum(i.getList(), sum, level++);
            }
            return sum;
        }
    }

    /**
        * This is the interface that represents nested lists.
        * You should not implement it, or speculate about its implementation.
        */
    public interface NestedInteger
    {
        /** @return true if this NestedInteger holds a single integer, rather than a nested list */
        bool isInteger();

        /** @return the single integer that this NestedInteger holds, if it holds a single integer
            * Return null if this NestedInteger holds a nested list */
        int getInteger();

        /** @return the nested list that this NestedInteger holds, if it holds a nested list
            * Return null if this NestedInteger holds a single integer */
        List<NestedInteger> getList();
    }
}
