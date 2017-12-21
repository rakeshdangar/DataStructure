using System;

// To execute C#, please define "static void Main" on a class
// named Solution.

namespace ConsoleApplication1
{
    class Fibonacci
    {
        public static void Init()
        {
            int n = 5;

            Console.WriteLine("Hello World ! Here is my implementation of Fibonacci");
            Console.WriteLine("Sum: " + (GetNthFibonacci_Item(n) - 1).ToString());
            Fibonacci_Iterative(n);
            //int[] arrF = new int[n];
            //arrF = PrintFibonacciSeries(n);
            //foreach(int i in arrF)
            //Console.WriteLine(i.ToString());
        }

        static void Fibonacci_Iterative(int len)
        {
            int a = 0, b = 1, c = 0;
            Console.Write("{0} {1}", a, b);

            for (int i = 2; i < len; i++)
            {
                c = a + b;
                Console.Write(" {0}", c);
                a = b;
                b = c;
            }
        }

        static int GetNthFibonacci_Item(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return GetNthFibonacci_Item(n - 2) + GetNthFibonacci_Item(n - 1);
            }
        }

        static int[] PrintFibonacciSeries(int count)
        {
            int[] temp = new int[count];
            if (count == 1)
                temp[0] = 0;
            else if (count >= 1)
            {
                temp[0] = 0;
                temp[1] = 1;

                int i = 2;
                while (i < count)
                {
                    temp[i] = temp[i - 1] + temp[i - 2];
                    i++;
                }
            }

            return temp;
        }
    }
}
