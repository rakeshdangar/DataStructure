using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class PrintCollectionImplementIEnumerable
    {
        public static void Init()
        {
            MyArray myArray = new MyArray(new int[] { 3, 4, 5 });
            PrintCollectionImplementIEnumerable.PrintCollection(myArray);
        }

        public static void PrintCollection<T>(IEnumerable<T> collection)
        {
            using (var item = collection.GetEnumerator())
            {
                while (item.MoveNext())
                {
                    Console.WriteLine(item.Current);
                }
            }
        }
    }
    // My collection class API, which simply wraps over int array 
    class MyArray : IEnumerable<int>
    {
        public MyArray(int[] arr)
        {
            array = arr;
        }
        private int[] array;

        public IEnumerator<int> GetEnumerator()
        {
            return array.ToList<int>().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
