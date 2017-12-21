using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
  
    class Node
    {
        //public String Name { get; private set; }
        public int Data { get; private set; }
        public IList<Node> Childs { get; private set; }
        public Node LeftNode { get; private set; }
        public Node RightNode { get; private set; }

        public Node(int data)
        {
            Data = data;
            Childs = new List<Node>();
        }

        public List<Node> Depth
        {
            get
            {
                List<Node> path = new List<Node>();
                foreach (Node node in this.Childs)
                {
                    List<Node> temp = node.Depth;
                    if (temp.Count > path.Count)
                        path = temp;
                }
                path.Insert(0, this);
                return path;
            }
        }

        public void PrintTree()
        {
            Node current = this;
            if (current != null)
            {
                //Console.WriteLine("Current: " + current.Data.ToString());

                //Traverse left
                if (current.LeftNode != null)
                {
                    current.LeftNode.PrintTree();
                }
                Console.WriteLine(current.Data.ToString());

                //Traverse left
                if (current.RightNode != null)
                {
                    current.RightNode.PrintTree();
                }
            }
        }

        public void Insert(int value)
        {
            Node current = this;
            while (current != null)
            {
                if (current.Data > value)
                    if (current.LeftNode == null)
                    { current.LeftNode = new Node(value); break; }
                    else current = current.LeftNode;
                else
                    if (current.RightNode == null)
                    { current.RightNode = new Node(value); break; }
                    else current = current.RightNode;
            }
        }

        public override string ToString()
        {
            return Data.ToString();
        }

        public static bool IsPresent(Node root, int val)
        {
            if (root == null) return false;
            bool ret = false;
            Node current = root;
            while (current != null)
            {
                if (current.Data == val)
                {
                    ret = true;
                    break;
                }

                if (current.Data > val)
                    current = current.LeftNode;
                else
                    current = current.RightNode;
            }
            return ret;
        }

        public void PrintLeaves()
        {
            PrintLeavesHelper(this);
        }

        private void PrintLeavesHelper(Node root)
        {
            if (root == null)
                return;
            if (root.LeftNode == null && root.RightNode == null)
                Console.WriteLine(root.Data.ToString());
            else
            {
                PrintLeavesHelper(root.LeftNode);
                PrintLeavesHelper(root.RightNode);
            }
        }

        //public void PrintOuterNodes()
        //{
        //    PrintOuterNodesHelper(this, this.Data, false, false);
        //}

        //private static void PrintOuterNodesHelper(Node root, int rootValue, bool printLeftOuter, bool printRightOuter)
        //{
        //    if (root == null)
        //        return;
        //    if ((root.LeftNode == null && root.RightNode == null) || (printLeftOuter && !printRightOuter) || (!printLeftOuter && printRightOuter))
        //        Console.WriteLine(root.Data.ToString());
            
        //    printLeftOuter = true;
        //    PrintOuterNodesHelper(root.LeftNode, root.Data, printLeftOuter, printRightOuter);
        //    if(root.Data >= rootValue)
        //        printLeftOuter = false;
                
        //    printRightOuter = true;
        //    PrintOuterNodesHelper(root.RightNode, root.Data, printLeftOuter, printRightOuter);
        //    if (root.Data <= rootValue)
        //        printRightOuter = false;
        //}

        public void PrintOuterNodes()
        {
            Console.WriteLine(this.Data.ToString());
            PrintLeftOuterNodesHelper(this.LeftNode, true);
            PrintRightOuterNodesHelper(this.RightNode, true);
        }

        private static void PrintLeftOuterNodesHelper(Node root, bool printLeftOuter)
        {
            if (root == null)
                return;
            if ((root.LeftNode == null && root.RightNode == null) || (printLeftOuter))
                Console.WriteLine(root.Data.ToString());

            PrintLeftOuterNodesHelper(root.LeftNode, printLeftOuter);
            PrintRightOuterNodesHelper(root.RightNode, false);
        }

        private static void PrintRightOuterNodesHelper(Node root, bool printRightOuter)
        {
            if (root == null)
                return;

            PrintLeftOuterNodesHelper(root.LeftNode, false);
            PrintRightOuterNodesHelper(root.RightNode, printRightOuter);
            
            if ((root.LeftNode == null && root.RightNode == null) || (printRightOuter))
                Console.WriteLine(root.Data.ToString());
        }
    }

    class TreeUtil
    {
        public static void Init()
        {
            //Node node1111 = new Node(1111);
            //Node node111 = new Node(111);
            //Node node11 = new Node(11);
            //Node node12 = new Node(12);
            //Node node1 = new Node(1);
            //Node root = new Node(0);
            //Node node2 = new Node(2);
            //Node node21 = new Node(21);
            //Node node211 = new Node(211);
            //root.Childs.Add(node1);
            //root.Childs.Add(node2);
            //node1.Childs.Add(node11);
            //node1.Childs.Add(node12);
            //node11.Childs.Add(node111);
            //node111.Childs.Add(node1111);
            //node2.Childs.Add(node21);
            //node21.Childs.Add(node211);

            //List<Node> path = root.Depth;
            //foreach (Node n in path)
            //    Console.Write(String.Format("{0} - ", n.ToString()));

            //Console.WriteLine();

            //Node node2111 = new Node(2111);
            //node2111.Childs.Add(new Node(21111));
            //node211.Childs.Add(node2111);

            //path = root.Depth;
            //foreach (Node n in path)
            //    Console.Write(String.Format("{0} - ", n.ToString()));

            //Console.WriteLine();

            //            15
            //   5                 25
            //2    10          22       29
            //   7    12     21  23  27    30
            // 6   8                    28

            Console.WriteLine("Print after insert Node");
            Node rootRD = new Node(15);
            rootRD.Insert(5);
            rootRD.Insert(10);
            rootRD.Insert(25);
            rootRD.Insert(22);
            rootRD.Insert(29);
            rootRD.Insert(2);
            rootRD.Insert(7);
            rootRD.Insert(12);
            rootRD.Insert(6);
            rootRD.Insert(8);
            rootRD.Insert(21);
            rootRD.Insert(23);
            rootRD.Insert(27);
            rootRD.Insert(30);
            rootRD.Insert(28);
            rootRD.PrintTree();
            Console.WriteLine("Is node with value 13 present? " + Node.IsPresent(rootRD, 13).ToString());
            Console.WriteLine("Leave nodes are :"); rootRD.PrintLeaves();
            Console.WriteLine("Outer nodes are :"); rootRD.PrintOuterNodes();
        }
    }
}
