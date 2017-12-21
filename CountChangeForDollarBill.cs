using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CountChangeForDollarBill
    {
        /* Q: Given some dollar value in cents (e.g. 200 = 2 dollars, 1000 = 10 dollars),
      find the number of combinations of coins that make up the dollar value.
      There are only penny, nickel, dime, and quarter.
      (quarter = 25 cents, dime = 10 cents, nickel = 5 cents, penny = 1 cent) */
        /* A:
        Reference: http://andrew.neitsch.ca/publications/m496pres1.nb.pdf
        f(n, k): number of ways of making change for n cents, using only the first
                 k+1 types of coins.

                  +- 0,                        n < 0 || k < 0
        f(n, k) = |- 1,                        n == 0
                  +- f(n, k-1) + f(n-C[k], k), else
         */        

        //Let C(i,J) the set of combinations of making i cents using the values in the set J.
        //You can define C as that:
        //         [i/(first(j)]
        // C(i,j) =   U             = first(J) * j x C(i-frist(J)*j, J first(J))
        //           j=0
        // C(i,j) = {} if J is empty
        //enter image description here
        //(first(J) takes in a deterministic way an element of a set)
        //It turns out a pretty recursive function... and reasonably efficient if you use memoization ;)

        int[] C = { 1, 5, 10, 25 };
        List<int> C2 = new List<int> { 25, 10, 5, 1 };

        public static void Init()
        {
            CountChangeForDollarBill cc = new CountChangeForDollarBill();

            //Console.WriteLine("Recursively = {0}", cc.f(20, 3, C));
            Console.WriteLine("Recursively = {0}", cc.f(20, 3));
            Console.WriteLine("Iteratively = {0}", cc.count(cc.C2, 20));
            //Console.WriteLine("Recursively = {0}", cc.f_NonRec(100, 3));
            
            //Console.WriteLine("Recursively = {0}", cc.f(200, 3, C));
            ////Console.WriteLine("Recursively = {0}", cc.f_NonRec(200, 3));
            
            //Console.WriteLine("Recursively = {0}", cc.f(1000, 3, C));
            ////Console.WriteLine("Recursively = {0}", cc.f_NonRec(1000, 3));
        }
        
        // Recursive: very slow, O(2^n)
        private int f(int n, int k)
        {
            if (n < 0 || k < 0)
                return 0;

            if (n == 0)
                return 1;

            return f(n, k-1) + f(n-C[k], k); 
        }

        //Iteratively: Fast O(n*k) with O(n) memory space
        private int count(List<int> s, int n )
        {
          //std::vector<int> table(n+1,0);
            List<int> table = new List<int>();
            for (int i = 0; i <= n; i++)
            {
                table.Add(0);
            }

            table[0] = 1;
            foreach (int k in s)
            {
                for (int j = k; j <= n; ++j)
                {
                    table[j] += table[j - k];
                }
            }

            return table[n];
        }
    }
}
