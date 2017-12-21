using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphShortestPath
{          
    class adjListNode
    {
        int v;
        int weight;
        public adjListNode(int _v, int _weight)
        {
            v = _v;
            weight = _weight;
        }
        public int GetV() { return v; }
        public int GetWeight() { return weight; }
    }

    // This class represents a directed graph using adjacency
    // list representation
    class Graph
    {
        static int INF= int.MaxValue;
        private int V;   // No. of vertices
        private Dictionary<int, List<adjListNode>> adj; // Adjacency List

        //Constructor
        public Graph(int v)
        {
            V = v;
            adj = new Dictionary<int, List<adjListNode>>(v);
            for (int i = 0; i < v; ++i)
                    adj[i] = new List<adjListNode>();
        }

        // Function to add an edge into the graph
        void addEdge(int u, int v, int w) { adj[u].Add(new adjListNode(v,w)); }

        // A recursive function used by topologicalSort
        void topologicalSortUtil(int v, bool[] visited, Stack stack)
        {
            // Mark the current node as visited.
            visited[v] = true;

            // Recur for all the vertices adjacent to this vertex
            foreach (adjListNode i in adj[v])
            {
                if (!visited[i.GetV()])
                    topologicalSortUtil(i.GetV(), visited, stack);
            }

            // Push current vertex to stack which stores result
            stack.Push((int)v);
        }

        // The function to do Topological Sort. It uses
        // recursive topologicalSortUtil()
        void ShoretestPath(int s)
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

            // Mark all the vertices as not visited
            int[] dist = new int[V];
            for (int i = 0; i < V; i++)
                dist[i] = INF;
            dist[s] = 0;

            // Process vertices in topological order
            while (stack.Count > 0)
            {
                // Get the next vertex from topological order
                int u = (int)stack.Pop();
 
                // Update distances of all adjacent vertices
                if (dist[u] != INF)
                {
                    foreach(adjListNode i in adj[u])
                    {
                        if (dist[i.GetV()] > dist[u] + i.GetWeight())
                            dist[i.GetV()] = dist[u] + i.GetWeight();
                    }
                }
            }
 
            // Print the calculated shortest distances
            for (int i = 0; i < V; i++)
            {
                if (dist[i] == INF)
                    Console.WriteLine( "INF ");
                else
                    Console.WriteLine( dist[i] + " ");
            }
        }
            
        //// Method to create a new graph instance through an object    
        //// of ShortestPath class.
        //public Graph newGraph(int number)
        //{
        //    return new Graph(number);
        //}
 
        public static void Init()
        {
            // Create a graph given in the above diagram.  Here vertex
            // numbers are 0, 1, 2, 3, 4, 5 with following mappings:
            // 0=r, 1=s, 2=t, 3=x, 4=y, 5=z
            //ShortestPath t = new ShortestPath();
            Graph g = new Graph(6);
            g.addEdge(0, 1, 5);
            g.addEdge(0, 2, 3);
            g.addEdge(1, 3, 6);
            g.addEdge(1, 2, 2);
            g.addEdge(2, 4, 4);
            g.addEdge(2, 5, 2);
            g.addEdge(2, 3, 7);
            g.addEdge(3, 4, -1);
            g.addEdge(4, 5, -2);
 
            int s = 1;
            Console.WriteLine("Following are shortest distances "+ "from source " + s );
            g.ShoretestPath(s);
        }
    }
}
