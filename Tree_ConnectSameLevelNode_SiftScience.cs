using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Tree_ConnectSameLevelNode_SiftScience
    {
        public static void Init()
        {
            //       A
            //      / \
            //     /   \
            //    B --> C
            //   /  \    /\
            //  b1->D-> E-> F
            //    /        \
            //   G -------->H

            Node A = new Node('A');
            Node B = new Node('B');
            Node B1 = new Node('1');
            Node C = new Node('C');
            Node D = new Node('D');
            Node E = new Node('E');
            Node F = new Node('F');
            Node G = new Node('G');
            Node H = new Node('H');

            A.Left = B;
            A.Right = C;

            B.Left = B1;
            B.Right = D;
            C.Left = E;
            C.Right = F;

            //PreOrder Traversal - Works for complete binary trees
            Console.WriteLine("Print populated Tree using PreOrder Traversal:");
            A.ConnectUsingPreOrder(A);
            A.PrintTree();

            //Add leaf nodes. Now tree is not a complete binary tree.
            D.Left = G;
            F.Right = H;

            //Using Dictionary
            Console.WriteLine("");
            Console.WriteLine("Print populated Tree using using Dictionary:");
            A.ConnectUsingDictionary();
            A.PrintTree();

            //Using Queue
            Console.WriteLine("");
            Console.WriteLine("Print populated Tree using Queue:");
            A.connectUsingQueue();
            A.PrintTree();

            ///* Constructed binary tree is
            //          10
            //        /   \
            //      8      2
            //    /         \
            //  3            90
            //*/
            //Node root = new Node(10);
            //root.Left = new Node(8);
            //root.Right = new Node(2);
            //root.Left.Left = new Node(3);
            //root.Right.Right = new Node(90);

            //// Populates Next pointer in all nodes
            //root.connectUsingQueue();
            //// Let us check the values of nextRight pointers
            //Console.WriteLine("");          
            //Console.WriteLine("Following are populated nextRight pointers in \n" + "the tree (-1 is printed if there is no nextRight)");
            //Console.WriteLine("Next of " + root.Data + " is " + ((root.Next != null) ? root.Next.Data : -1));
            //Console.WriteLine("Next of " + root.Left.Data + " is " + ((root.Left.Next != null) ? root.Left.Next.Data : -1));
            //Console.WriteLine("Next of " + root.Right.Data + " is " + ((root.Right.Next != null) ? root.Right.Next.Data : -1));
            //Console.WriteLine("Next of " + root.Left.Left.Data + " is " + ((root.Left.Left.Next != null) ? root.Left.Left.Next.Data : -1));
            //Console.WriteLine("Next of " + root.Right.Right.Data + " is " + ((root.Right.Right.Next != null) ? root.Right.Right.Next.Data : -1));
        }

        class Node
        {
            public object Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public Node Next { get; set; }

            public Node(object data)
            {
                Data = data;
            }

            // Sets the nextRight of root and calls connectRecur()
            // for other nodes
            public void ConnectUsingPreOrder(Node p)
            {
                // Set the nextRight for root
                p.Next = null;

                // Set the next right for rest of the nodes (other than root)
                ConnectRecur(p);
            }

            /* Set next right of all descendents of p.
               Assumption:  p is a compete binary tree */
            void ConnectRecur(Node p)
            {
                // Base case
                if (p == null)
                    return;

                // Set the Next pointer for p's left child
                if (p.Left != null)
                    p.Left.Next = p.Right;

                // Set the Next pointer for p's right child
                // p->Next will be NULL if p is the right most child at its level
                if (p.Right != null)
                    p.Right.Next = (p.Next != null) ?
                                                 p.Next.Left : null;

                // Set nextRight for other nodes in pre order fashion
                ConnectRecur(p.Left);
                ConnectRecur(p.Right);
            }

            public void ConnectUsingDictionary()
            {
                Dictionary<int, List<Node>> tempStore = new Dictionary<int, List<Node>>();
                int index = 0;
                this.RecurseTree(index, tempStore);
                foreach (int i in tempStore.Keys)
                {
                    List<Node> row = tempStore[i];
                    if (row.Count > 0)
                    {
                        for (int j = 0; j < row.Count - 1; j++)
                        {
                            row[j].Next = row[j + 1];
                        }
                    }
                }
            }

            public void RecurseTree(int index, Dictionary<int, List<Node>> tempStore)
            {
                Node current = this;

                if (!tempStore.ContainsKey(index))
                {
                    List<Node> temp = new List<Node>();
                    temp.Add(this);
                    tempStore[index] = temp;
                }
                else
                {
                    tempStore[index].Add(this);
                }

                index++;

                if (current.Left != null)
                    current.Left.RecurseTree(index, tempStore);
                if (current.Right != null)
                    current.Right.RecurseTree(index, tempStore);
                index--;
            }


            // Sets nextRight of all nodes of a tree
            public void connectUsingQueue()
            {
                Node root = this;
                Queue<Node> q = new Queue<Node>();
                q.Enqueue(root);

                // null marker to represent end of current level
                q.Enqueue(null);

                // Do Level order of tree using NULL markers
                while (q.Count > 0)
                {
                    Node p = q.Dequeue();
                    if (p != null)
                    {

                        // next element in queue represents next 
                        // node at current Level 
                        p.Next = q.Peek();

                        // push left and right children of current
                        // node
                        if (p.Left != null)
                            q.Enqueue(p.Left);
                        if (p.Right != null)
                            q.Enqueue(p.Right);
                    }

                    // if queue is not empty, push NULL to mark 
                    // nodes at this level are visited
                    else if (q.Count > 0)
                        q.Enqueue(null);
                }
            }

            public void PrintTree()
            {
                Node current = this;
                if (current != null)
                {
                    Console.WriteLine("Current: " + current.Data.ToString()
                        + ((null != current.Left) ? " Left = " + current.Left.Data.ToString() : " Left = Null")
                        + ((null != current.Right) ? " Right = " + current.Right.Data.ToString() : " Right = Null")
                        + ((null != current.Next) ? " Next = " + current.Next.Data.ToString() : " Next = Null"));

                    //Traverse left
                    if (current.Left != null)
                    {
                        current.Left.PrintTree();
                    }

                    //Traverse Right
                    if (current.Right != null)
                    {
                        current.Right.PrintTree();
                    }
                }
            }
        
        
        }
    }
}


//Problem statement:

//You will write a method which accepts the root node binary tree. When it's passed to your method the tree might look like this:

//       A
//      / \
//     /   \
//    B     C
//     \    /\
//     D   E  F
//    /        \
//   G          H

//Note that the tree is not assured to be balanced. Each node has exactly 3 fields: left, right and next

//  - left and right are the normal tree links (i.e. if populated, they point at the left and right children)
//  - The next pointer is empty when you receive the tree. Your method will populate these pointers to satisfy the following rules:
//    - if x is the right-most node at its depth, x.next will remain empty (or null, undefined, depending on your language of choice)
//    - for every node which is not the right-most node at its depth, x.next points to the node immediately to its right

//When your method returns, the our example tree would look like this (where the next pointers are represented as horizontal arrows):

//       A
//      / \
//     /   \
//    B --> C
//   /  \    /\
//  b1->D-> E-> F
//    /        \
//   G -------->H

//Naturally you want to do this as efficiently as possible, both with respect to time complexity and space complexity.


//public Dictionary<int, List<Node>> GetResultTree(Node root)
//{
//    Dictionary<int, List<Node>> tempStore = new Dictionary<int, List<Node>>();
//    if(root == null)
//    return null;
//  int index = 0;
  
//  RecurseTree(root);  
//  foreach(int i in tempStore.Keys)
//  {
//    List<Node> row = tempStore[i];
//    if(row.Count > 0)
//        {
//        for(int j=0; j<row.Count-1; j++)
//        {
//            row[j].Next = roj[j+1];
//        }
//      }
//  }
//}

//public void RecurseTree(Node root, index, Dictionary<int, List<Node>> tempStore)
//{
//    Node current = root;
//    While ( current != null)
//  {
//    List<Node> temp0 = new List<Node>();
//    temp0.Add(root);
//    tempStore[index] = temp0;
//    index++;
//    if(current.Left != nul)
//        RecurseTree(current.Left, index, Dictionary<int, List<Node>> tempStore);
//    if(current.Right != null);
//        RecurseTree(current.Left, index, Dictionary<int, List<Node>> tempStore);    
//  }
//  index--;
//}











