using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace ConsoleApplication1
//{
//    class TreeToList
//    {
//        using System;
//using System.Collections.Generic;
//using System.Collections;

//// To execute C#, please define "static void Main" on a class
//// named Solution.

//// Given a binary tree, can you convert the tree into linked lists for each level?

////        1
////     2     3
////   4      5      6      7
//// 8   9  10  11 12 13  14 15

//// Output:
////0 [1,
////1 2 -> 3,
////2 4 -> 5 -> 6 -> 7
////3 4 -> 5 -> 6 -> 7]

public class TreeToListUtil
{
    public static void Init()
    {
        Node root = new Node(1);
        Node child2 = new Node(2);
        Node child3 = new Node(3);
        Node child4 = new Node(4);
        Node child5 = new Node(5);
        Node child6 = new Node(6);
        Node child7 = new Node(7);
        Node child8 = new Node(8);
        Node child9 = new Node(9);
        Node child10 = new Node(10);
        Node child11 = new Node(11);
        Node child12 = new Node(12);
        Node child13 = new Node(13);
        Node child14 = new Node(14);
        Node child15 = new Node(15);

        root.LeftNode = child2;
        root.RightNode = child3;

        child2.LeftNode = child4;
        child2.RightNode = child5;

        child3.LeftNode = child6;
        child3.RightNode = child7;

        child4.LeftNode = child8;
        child4.RightNode = child9;

        child5.LeftNode = child10;
        child5.RightNode = child11;

        child6.LeftNode = child12;
        child6.RightNode = child13;

        child7.LeftNode = child14;
        child7.RightNode = child15;

        //root.PrintTree();

        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        root.TraversTree(graph, -1);

        foreach (int i in graph.Keys)
        {
            foreach (int j in graph[i])
            {
                Console.Write(j.ToString());
            }
            Console.WriteLine("");
        }
    }
}

class Node
{
    //public String Name { get; private set; }
    public int Data { get; private set; }
    public IList<Node> Childs { get; private set; }
    public Node LeftNode { get; set; }
    public Node RightNode { get; set; }

    public Node(int data)
    {
        Data = data;
        Childs = new List<Node>();
    }

    public void TraversTree(Dictionary<int, List<int>> graph, int level)
    {
        level++;
        Node current = this;
        if (current != null)
        {
            if (graph.ContainsKey(level))
            {
                List<int> list = graph[level];
                list.Add(current.Data);
                graph[level] = list;
            }
            else
            {
                List<int> list = new List<int>();
                list.Add(current.Data);
                graph.Add(level, list);
            }

            //Traverse left
            if (current.LeftNode != null)
            {
                current.LeftNode.TraversTree(graph, level);
            }

            //Traverse right
            if (current.RightNode != null)
            {
                current.RightNode.TraversTree(graph, level);
            }
        }
        level--;
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

            //Traverse right
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
}

//class Solution
//{
//    static void Main(string[] args)
//    {
//        LinkList a = new LinkList();
//        LinkList b = new LinkList();
//        LinkList c = new LinkList();

//        Node root = new Node(10);

//        Dictionary<int, List<int> 

//        a.Add(root.content);
//        b.Add(root.Retrieve(root));
//        c.Add(root.Retrieve(root.LeftNode));
//        c.Add(root.Retrieve(root.RightNode))
//    }
//}

//class Node
//{
//    pubclic int nodeContent { get; private set}
//    public Node LeftNode { get; private set}    
//    public Node RightNode { get; private set}

//    public rootNode;

//    public Node (int data)
//    {
//        Data = data;
//        rootNode = null;
//    }

//    public List<int> Retrieve()
//    {
//        List<int> data = new List<int>();

//        if(this == rootNode)
//            data.Add(rootNode.nodeContent);
//        else
//        {
//            Node current = this;
//            if(current != null)
//            {
//                if(current.LeftNode != null)
//                {
//                    data.Add(current.LeftNode.nodeContent);
//                }
//                if(current.RightNode != null)
//                {
//                    data.Add(current.RightNode.nodeContent);
//                }
//            }
//        }
//        return data;
//    }
//}

//public class LinkList
//{
//    public class ListNode
//    {
//        public int nodeContent;
//        public ListNode next;
//    }

//    public ListNode head;
//    public ListNode current;

//    public LinkList()
//    {
//        head = null;
//    }

//    public void Add(int contect)
//    {
//        var node = new ListNode()
//        {
//            nodeContent = content
//        };

//        if(head == null)
//        {
//            head = node;
//        }
//        else
//        {
//            current.next = node;
//        }
//        current = node;
//    }
//}
//    }
//}
