using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Tree_ArrayPostTraversal
    {
        public static void Init()
        {
            int[] arr = {5,7,9,6,11,10,8};
            Console.WriteLine(isValidBST(arr).ToString());
        }

        public static bool isValidBST(int[] post)
        {
            return isValidBSTHelper(post, 0, post.Length - 1);
        }

        private static bool isValidBSTHelper(int[] post, int start, int end)
        {
            if (start >= end)
            {
                return true;
            }
            int i = start;
            int root = post[end];
            while (post[i] <= root && i < end)
            {
                i++;
            }
            for (int k = i; k < end; k++)
            {
                if (post[k] < root)
                {
                    return false;
                }
            }
            return isValidBSTHelper(post, start, i - 1)
            && isValidBSTHelper(post, i, end - 1);
        }
    }
}
