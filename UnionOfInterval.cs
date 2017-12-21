using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class UnionOfInterval
    {
        public static void Init()
        {
            UnionOfInterval UI = new UnionOfInterval();
            UI.NumberOfElementInUnion();
        }

        private void NumberOfElementInUnion()
        {
            string s = "";
            HashSet<int> union = new HashSet<int>();
            while (!string.IsNullOrEmpty(s = Console.ReadLine()))
            {
                s = s.Trim();
                string[] strArr = s.Split(' ');
                for (int i = 0; i < strArr.Length; i++)
                {
                    union.Add(int.Parse(strArr[i]));
                }
            }

            Console.WriteLine(union.Count.ToString());
        }
    }    
}
