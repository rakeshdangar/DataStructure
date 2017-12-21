using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Recurssion_TotalPermutation
    {
        public static void Init(int n)
        {
            //int differentWays = 3;
            //int n = 4;
            int total = FindTotalPermutation(n);
            Console.Write("Total permuataions are: {0}", total.ToString());
        }

        //Total = (n-1)+(n-2)+....(n-differentWays);
        public static int FindTotalPermutation(int n)
        {
            if (n == 1)
                return 1;
            if (n == 2)
                return FindTotalPermutation(n - 1) + 1;
            if (n == 3)
                return FindTotalPermutation(n - 2) + FindTotalPermutation(n - 1) + 1;

            return FindTotalPermutation(n - 1) + FindTotalPermutation(n - 2) + FindTotalPermutation(n - 3);
        }
    }
}

//public static int[] A = new int[100];
 
//public static int f3(int n) {
//    if (n <= 2)
//        A[n]= n;
 
//    if(A[n] > 0)
//        return A[n];
//    else
//        A[n] = f3(n-1) + f3(n-2);//store results so only calculate once!
//    return A[n];
//}