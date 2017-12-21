using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital;
using TaskManagement; 

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[][] image = new int[][] 
            //{
            //  new int[] {1, 1, 1, 1, 1, 1, 0},
            //  new int[] {1, 1, 1, 1, 1, 1, 0},
            //  new int[] {1, 1, 1, 1, 1, 1, 0},
            //  new int[] {1, 1, 1, 1, 1, 1, 1},
            //  new int[] {1, 1, 1, 1, 1, 1, 1}
            //};
            //Console.WriteLine(image.GetLength(0)); -- 5
            //Console.WriteLine(image[0].Length); -- 7

            Init();
        }
                   
        static void Init()
        {
            //Array_FindTwoElementsInArrayToSum.Init();
            //Array_MaxProductProfit.Init();
            //Array_Monotonic.Init();
            //Array_RemoveDuplicatesFromArray.Init("aaabbb".ToCharArray());
            //Array_Stock.findMostProfit(); 
            //BalancedBrackets.hasBalancedBrackets("(){}[]<>");
            //CountChangeForDollarBill.Init();
            //Dictionary_FindChildParent.Init();
            //GraphDFS.Graph.Init();
            //GraphShortestPath.Graph.Init();
            //GraphTopologicalSort.Graph.Init();
            //Hospital.Person.Init();
            //LinkListUtil.Init();
            //LinkListReverse.Init();
            //ListMethods.Init();
            //Matrix3_4.draw();
            //MatrixRectangleCoOrdinates.Init();
            //PrintCollectionImplementIEnumerable.Init();
            //RansomNote.Init();
            //Recurssion_TotalPermutation.Init(4);
            //SimpleRegex.Init();
            //String_Anagram.Init("rakesh", "rshake");  //Contains same number of each characters
            //String_Anagram.Init("rakesh", "rakesha");
            //String_Palindrome.Init();
            //String_Palindrome.IsPalindrome("levvell");
            //String_ReverseOrder.PrintPyramidOfNumbers(10);
            //String_ReverseOrder.ReverseWordsOrder("this is funny not as much");      
            //String_ReverseWordsInAString.Init();
            //String_SortCharactersInAString.Init();
            //String_SubSequenceNumberDecoding.Init();
            //String_TitalCase.Init();
            //String_TotalSubStringPermutation.Init("abc");
            ////TaskManagement.Task.Init() - Amazon.
            //TaskAndWorkers.Init();
            //Tree_ArrayPostTraversal.Init();
            //Tree_CommonAncestorIn.Init();
            //Tree_ConnectSameLevelNode_SiftScience.Init();
            //Tree_DistanceBetweenNodeInBST.Init();
            //Tree_LevelOrderTraversal.Init();
            //TreeToListUtil.Init();
            //TreeUtil.Init(); //Leaves and outerleaves
            //UnionOfInterval.Init();

            //S3API.SimpleListBuckets("", "");
            S3API.UploadToS3Bucket("", "", "");

            Console.Read();
        }
    }
}