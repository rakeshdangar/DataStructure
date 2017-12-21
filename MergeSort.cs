using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MergeSort
    {
        static void Init()
        {
            int[] arr1 = { 1, 9, 5, 8, 4 }; //System.Linq.Enumerable.Repeat(-1, 10).ToArray();,8,3,9,1,4,6

            int[] arrSorted = new int[arr1.Length];
            copyArrary(arr1, arrSorted);
            //int[] arrSorted2 = (int[])arr1.Clone();

            Console.WriteLine("Initial Array");
            foreach (int i in arr1)
            {
                Console.Write(i);
            }
            Console.WriteLine();

            Sort(arr1, 0, arr1.Length - 1, arrSorted);
            Console.WriteLine("Sorted array using mergesort");
            foreach (int j in arrSorted)
            {
                Console.Write(j);
            }
        }

        static void copyArrary(int[] a, int[] b)
        {
            for (var i = 0; i < a.Length; i++)
            {
                b[i] = a[i];
            }
        }

        static void Sort(int[] a, int begin, int end, int[] b)
        {

            if (end > begin)
            {
                int middle = (end + begin) / 2;
                Sort(b, begin, middle, a);
                Sort(b, middle + 1, end, a);

                Merge(a, begin, middle + 1, end, b);
            }
        }

        static void Merge(int[] a, int left, int middle, int end, int[] b)
        {
            int left_end = middle - 1;
            int tmp_pos = left;

            while ((left <= left_end) && (middle <= end))
            {
                if (a[left] <= a[middle])
                    b[tmp_pos++] = a[left++];
                else
                    b[tmp_pos++] = a[middle++];
            }

            while (left <= left_end)
                b[tmp_pos++] = a[left++];

            while (middle <= end)
                b[tmp_pos++] = a[middle++];

            copyArrary(b, a);

        }
    }    
}


//using System;

//// To execute C#, please define "static void Main" on a class
//// named Solution.

//class Solution
//{

//    static void Main(string[] args)
//    {        
//        int[] arr1 = {3, 8, 7, 5, 2, 1, 9, 6, 4}; //System.Linq.Enumerable.Repeat(-1, 10).ToArray();,8,3,9,1,4,6



//        MergeSort(arr1,0,arr1.Length-1);
//        Console.WriteLine("Sorted array using mergesort");
//        foreach (int j in arr1)
//        {
//            Console.Write(j);
//        }
//    }    

//    static void MergeSort(int[] a, int begin, int end)
//    {

//        if(end > begin)
//        {            
//            int middle = (end + begin) / 2;  
//            MergeSort(a, begin, middle);
//            MergeSort(a, middle+1, end);

//            Merge(a, begin, middle+1, end);
//        }
//    }

//    static void Merge(int[] a, int left, int middle, int end)
//    {        
//        int left_end = middle-1;
//        int tmp_pos = left;
//        int num_elements = end-left+1;
//        int[] tempArr = new int[a.Length];

//        while((left <= left_end) && (middle <= end))
//        {
//            if(a[left] <= a[middle])
//                tempArr[tmp_pos++] = a[left++];
//            else
//                tempArr[tmp_pos++] = a[middle++];
//        }

//        while(left <= left_end)
//                tempArr[tmp_pos++] = a[left++]; 

//        while (middle <= end)
//                tempArr[tmp_pos++] = a[middle++];  

//        for (int i = 0; i < num_elements; i++)
//        {
//            a[end] = tempArr[end];
//            end--;
//        }

//    }    

//}
//    }
//}