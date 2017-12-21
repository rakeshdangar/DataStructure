using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PowerOf
    {
        public static void Init()
        {
            double result = power(3, -2);
            Console.Write(result);
        }

        public static double power(double a, int b)
        {
            int tmp = b;
            b = b >= 0 ? b : -1 * b;

            double result = 1;
            while (b != 0)
            {
                if ((b & 1) == 1)
                    result *= a;

                b >>= 1;
                a *= a;
            }

            return tmp > 0 ? result : 1.0 / result;
        }
    }
}
