using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Dictionary_FindChildParent
    {
        // To execute C#, please define "static void Main" on a class
        // named Solution.

        // Suppose we have some input data describing a graph of relationships between parents and children over multiple generations. The data is formatted as a list of (parent, child) pairs, where each individual is assigned a unique integer identifier.

        // For example, in this diagram, 3 is a child of 1 and 2, and 5 is a child of 4:
            
        // 1   2   4
        //  \ /   / \
        //   3   5   8
        //    \ / \   \
        //     6   7   9

        // Write a function that takes this data as input and returns two collections: one containing all individuals with zero known parents, and one containing all individuals with exactly one known parent.

        // Sample output:
        // Zero parents: 1, 2, 4
        // One parent: 5, 7, 8, 9
        public static void Init()
        {            
            var parentChildPairs = new List<Tuple<int, int>>() {
                Tuple.Create(1, 3),
                Tuple.Create(2, 3),
                Tuple.Create(3, 6),
                Tuple.Create(5, 6),
                Tuple.Create(5, 7),
                Tuple.Create(4, 5),
                Tuple.Create(4, 8),
                Tuple.Create(8, 9)
            };
        
            Dictionary<int, List<int>> result = GetCollections(parentChildPairs);
            foreach(int i in result.Keys)
            {
                Console.WriteLine(i);
                foreach(int j in result[i])
                    Console.Write(j);
                Console.WriteLine();
            }
        }    
        
        private static Dictionary<int, List<int>> GetCollections(List<Tuple<int, int>> parentChildPairs)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            foreach(Tuple<int, int> t in parentChildPairs)
            {
                if (!result.ContainsKey(t.Item1))
                {
                    result.Add(t.Item1, 0);
                } 
               
                if(result.ContainsKey(t.Item2))
                {                
                    result[t.Item2]++;
                }
                else
                {
                    result.Add(t.Item2, 1);
                } 
            }
        
            Dictionary<int, List<int>> ret = new Dictionary<int, List<int>>();            
            // Create a list for 0 parent
            List<int> l0 = new List<int>();
            ret.Add(0, l0);
            // Create a list for 1 parent
            List<int> l1 = new List<int>();
            ret.Add(1, l1);
            foreach(int i in result.Keys)
            {
                if(result[i] == 0)
                {
                    l0 = ret[0];
                    if(!l0.Contains(i))
                    {
                        l0.Add(i);
                        ret[0] =  l0;
                    }
                }
                if(result[i] == 1)
                {
                    l1 = ret[1];
                    if(!l1.Contains(i))
                    {
                        l1.Add(i);
                        ret[1] =  l1;
                    }
                }
            }
        
            return ret;
        }
    }
}
