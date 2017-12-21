using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Tree_CommonAncestorIn
    {
        public class Node1
        {
            public Node1(Node1 parent, string x)
            {
                this.parent = parent; this.x = x;
            }

            public String x;
            public Node1 left;
            public Node1 right;
            public Node1 parent;
        }

        public static void Init()
        {
            Node1 a = new Node1(null, "A");
            Node1 b = new Node1(a, "B");
            Node1 c = new Node1(a, "C");
            a.left = b;
            a.right = c;

            Node1 d = new Node1(b, "D");
            Node1 e = new Node1(b, "E");
            b.left = d;
            b.right = e;

            Node1 h = new Node1(c, "H");
            c.right = h;

            Node1 g = new Node1(d, "G");
            Node1 f = new Node1(d, "F");
            d.right = f;
            d.left = g;

            Console.WriteLine(deep(d, f).x);
            Console.WriteLine(deep(c, g).x);
            Console.WriteLine(deep(e, b).x);
            Console.WriteLine(deep(e, f).x);
        }

        public static Node1 deep(Node1 a1, Node1 a2)
        {
            LinkedList<Node1> first = new LinkedList<Node1>();
            while (a1 != null)
            {
                if (first.Count == 0)
                    first.AddFirst(a1);
                else
                    first.AddAfter(first.Last, a1);
                a1 = a1.parent;
            }

            LinkedList<Node1> second = new LinkedList<Node1>();
            while (a2 != null)
            {
                if (second.Count == 0)
                    second.AddFirst(a2);
                else
                    second.AddAfter(second.Last, a2);
                a2 = a2.parent;
            }

            int c1 = first.Count;
            int c2 = second.Count;
            Node1 common = null;

            while (c1 > 0 && c2 > 0)
            {
                if (first.ElementAt(c1 - 1).x != second.ElementAt(c2 - 1).x)
                {
                    common = first.ElementAt(c1);
                    break;
                }
                c2--;
                c1--;
            }

            if (common == null)
            {
                if (c1 == 0)
                {
                    return second.ElementAt(1);
                }
                if (c2 == 0)
                {
                    return first.ElementAt(1);
                }
            }
            return common;
        }
    }
}
