//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleApplication1
//{
//    class ShortestRoute
//    {

//        struct dstwt
//        {
//            string dist;
//            int time;

//            public dstwt(string d, int t)
//            {
//                dist = d;
//                time = t;
//            }
//        };

//        class Graph
//        {
//            List<string> destinations;
//            Dictionary<string, List<dstwt>> adj;
            
//        //    public Graph(List<string> destinations);
//        //    void AddEdge(string src, string dst, int time);
//        //    int SP(string src, string dst);
//        //};

//            void Graph(List<string> dests)
//            {
//                foreach (var dest in dests)
//                    destinations.Add(dest);
//            }

//            void AddEdge(string src, string dst, int time)
//            {
//                if (!adj.ContainsKey(src))
//                {
//                    adj[src] = new List<dstwt>{ new dstwt(dst,time) };
//                }
//                else
//                {
//                    adj[src].Add(new dstwt(dst,time));
//                }

//                if (!adj.ContainsKey(dst))
//                {
//                    adj[dst] = new List<dstwt>{ new dstwt(src,time) };
//                }
//                else
//                {
//                    adj[dst].Add(new dstwt(src,time));
//                }
//            }

//            int SP(string src, string dst)
//            {
//                Dictionary<string, dstwt> distances = new Dictionary<string,dstwt>();
//                foreach (var dest in destinations)
//                {
//                    distances[dest] = new dstwt("", 9999);
//                }
//                //set the starting point as 0
//                distances[src] = new dstwt("", 0);

//                var comparefn = [](const dstwt& lhs, const dstwt& rhs) {return lhs.time > rhs.time; };

//                priority_queue<dstwt, vector<dstwt>, decltype(comparefn)> min_heap(comparefn);
//                min_heap.push({ src,0 });

//                while (!min_heap.empty())
//                {
//                    auto u = min_heap.top();
//                    min_heap.pop();
//                    for (auto c : adj[u.point])
//                    {
//                        string v = c.point;
//                        int time = c.time;
//                        if (distances[v].time > distances[u.point].time + time)
//                        {
//                            distances[v].time = distances[u.point].time + time;
//                            min_heap.push({ v,distances[u.point].time + time });
//                        }
//                    }
//                }

//                return distances[dst].time;

//            }
//    }
//}
