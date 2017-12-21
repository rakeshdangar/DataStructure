using System;
using System.Collections.Generic;
using System.Collections;

// To execute C#, please define "static void Main" on a class
// named Solution.

namespace ConsoleApplication1
{
    public class Array_UniqueNumbersInArray
    {
        static void Init()
        {
            int[] a = { 1, 3, 5, 4, 5, 3, 2, 6, 7, 5, 6, 7, 8, 9, 10, 15, 12, 11, 101, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, };
            //FindUniqueBrute(a);
            FindUniqueDict(a);
        }

        static void FindUniqueDict(int[] a)
        {
            Dictionary<int, int> uniqueNumbers = new Dictionary<int, int>();
            for (int i = 0; i < a.Length; i++)
            {
                if (uniqueNumbers.ContainsKey(a[i]))
                {
                    uniqueNumbers[a[i]] = uniqueNumbers[a[i]]++;
                }
                else
                    uniqueNumbers.Add(a[i], 1);
            }

            Console.WriteLine("Unique numbers are:");
            foreach (var item in uniqueNumbers)
            {
                if (item.Value == 1)
                    Console.Write(item.Key.ToString() + ",");
            }
        }

        static void FindUniqueBrute(int[] a)
        {
            List<int> uniqueNumbers = new List<int>();
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                count = 0;
                for (int j = 0; j < a.Length; j++)
                {
                    if (a[i] == a[j])
                        count++;
                    if (count == 2)
                        break;
                }
                if (count == 1)
                    uniqueNumbers.Add(a[i]);
            }

            Console.WriteLine("Unique numbers are:");
            foreach (int k in uniqueNumbers)
                Console.Write(k.ToString() + ",");
        }
    }
}
