using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTopologicalSort
{
    // This class represents a directed graph using adjacency
    // list representation
    class Graph
    {
        private int V;   // No. of vertices
        private Dictionary<int, List<int>> adj; // Adjacency List
 
        //Constructor
        Graph(int v)
        {
            V = v;
            adj = new Dictionary<int,List<int>>(v);
            for (int i=0; i<v; ++i)
                adj[i] = new List<int>();
        }
 
        // Function to add an edge into the graph
        void addEdge(int v,int w) { adj[v].Add(w); }
 
        // A recursive function used by topologicalSort
        void topologicalSortUtil(int v, bool[] visited, Stack stack)
        {
            // Mark the current node as visited.
            visited[v] = true;
 
            // Recur for all the vertices adjacent to this vertex
            foreach(int i in adj[v])
            {
                if (!visited[i])
                    topologicalSortUtil(i, visited, stack);
            }
 
            // Push current vertex to stack which stores result
            stack.Push((int)v);
        }
 
        // The function to do Topological Sort. It uses
        // recursive topologicalSortUtil()
        void topologicalSort()
        {
            Stack stack = new Stack();
 
            // Mark all the vertices as not visited
            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
                visited[i] = false;
 
            // Call the recursive helper function to store
            // Topological Sort starting from all vertices
            // one by one
            for (int i = 0; i < V; i++)
                if (visited[i] == false)
                    topologicalSortUtil(i, visited, stack);
 
            // Print contents of stack
            while (stack.Count > 0)
                Console.WriteLine(stack.Pop() + " ");
        }
 
        // Driver method
        public static void Init()
        {
            // Create a graph given in the above diagram
            Graph g = new Graph(6);
            g.addEdge(5, 2);
            g.addEdge(5, 0);
            g.addEdge(4, 0);
            g.addEdge(4, 1);
            g.addEdge(2, 3);
            g.addEdge(3, 1);
 
            Console.WriteLine("Following is a Topological " + "sort of the given graph");
            g.topologicalSort();
        }
    }
}
