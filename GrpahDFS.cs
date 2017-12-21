using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphDFS
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
            adj = new Dictionary<int, List<int>>(v);
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }

        // Function to add an edge into the graph
        void addEdge(int v, int w) { adj[v].Add(w); }

        // A recursive function used by DFS
        void DFSUtil(int v, bool[] visited)
        {
            // Mark the current node as visited.
            visited[v] = true;

            Console.WriteLine(v + " ");

            // Recur for all the vertices adjacent to this vertex
            foreach (int i in adj[v])
            {
                if (!visited[i])
                    DFSUtil(i, visited);
            }
        }

        // The function to do DFS traversal. It uses recursive DFSUtil()
        void DFS(int v)
        {
            // Mark all the vertices as not visited(set as
            // false by default in java)
            bool[] visited = new bool[V];
 
            // Call the recursive helper function to print DFS traversal
            DFSUtil(v, visited);
        }

        // Driver method
        public static void Init()
        {
            Graph g = new Graph(4);
 
            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(1, 2);
            g.addEdge(2, 0);
            g.addEdge(2, 3);
            g.addEdge(3, 3);
 
            Console.WriteLine("Following is Depth First Traversal "+ "(starting from vertex 2)");
 
            g.DFS(2);
        }
    }
}
