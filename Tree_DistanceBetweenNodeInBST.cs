using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Tree_DistanceBetweenNodeInBST
    {
        public static void Init()
        {
            int[] values = { 5, 6, 3, 1, 2, 4 };
            Console.WriteLine(bstDistance(values, 6, 3, 4).ToString());
        }

        public static int bstDistance(int[] values, int n, int node1, int node2)
	    {
		    // WRITE YOUR CODE HERE
            if (null == values || values.Length == 0 || n <= 0 )
                return -1;

            Node root = new Node(values[0]);
            for (int i = 1; i < n; i++)
            {
                root.Insert(values[i]);            
            }
            
            //int distNode1 = root.Distance(root, node1) - 1;
            //int distNode2 = root.Distance(root, node2) - 1;
            //int commonParentNode = root.CommonParentNode(root, node1, node2).Value;
            //int distToCommongParent = root.Distance(root, commonParentNode) - 1;

            //if (distNode1 == -1 || distNode2 == -1)
            //    return -1;
            //else
            //    return (distNode1 + distNode2) - 2 * distToCommongParent;

            Node commonParentNode = CommonParentNode(root, node1, node2); //One of both nodes are not found in tree. 
            if (commonParentNode == null)
                return -1;
            else
            {
                //Recursive
                int distNode1 = Distance(commonParentNode, node1) - 1;
                int distNode2 = Distance(commonParentNode, node2) - 1;
                
                ////Iterative
                //int distNode1 = Distance(commonParentNode, node1);
                //int distNode2 = Distance(commonParentNode, node2);

                if (distNode1 == -1 || distNode2 == -1)
                    return -1;
                else
                    return (distNode1 + distNode2);
            }
        }

        public static int Distance(Node parent, int value)
        {
            if (parent != null)
            {
                int dist = 0;
                //Recursive
                if ((parent.Value == value) || (dist = Distance(parent.LeftNode, value)) > 0 || (dist = Distance(parent.RightNode, value)) > 0)
                {
                    return dist + 1;
                }

                ////Iterative - Ugly
                //Node current = parent;
                //while (current.Value != value)
                //{
                //    if (current.Value > value && null != current.LeftNode)
                //    {
                //        if (current.LeftNode.Value == value)
                //        {
                //            dist += 1;
                //            break;
                //        }
                //        else
                //            current = current.LeftNode;
                //    }
                //    else if(current.Value < value && null != current.RightNode)
                //    {
                //        if (current.RightNode.Value == value)
                //        {
                //            dist += 1;
                //            break;
                //        }
                //        else
                //            current = current.RightNode;
                //    }
                //    else
                //        break;
                //}
                //return dist;
            }
            return 0;
        }

        public static Node CommonParentNode(Node root, int node1, int node2)
        {
            if (root != null)
            {
                if (root.Value == node1 || root.Value == node2)
                {
                    return root;
                }
                Node left = CommonParentNode(root.LeftNode, node1, node2);
                Node right = CommonParentNode(root.RightNode, node1, node2);

                if (left != null && right != null)
                {
                    return root;
                }
                if (left != null)
                {
                    return left;
                }
                if (right != null)
                {
                    return right;
                }
                else return null;
            }
            else return null;
        }

        public class Node
        {
            public int Value { get; private set; }
            public Node LeftNode { get; set; }
            public Node RightNode { get; set; }

            public Node(int value)
            {
                Value = value;
            }

            public void Insert(int inputValue)
            {
                Node current = this;
                while (current != null)
                {
                    if (current.Value > inputValue)
                    {
                        if (current.LeftNode == null)
                        {
                            current.LeftNode = new Node(inputValue);
                            break;
                        }
                        else
                            current = current.LeftNode;
                    }
                    else
                    {
                        if (current.RightNode == null)
                        {
                            current.RightNode = new Node(inputValue);
                            break;
                        }
                        else
                            current = current.RightNode;
                    }
                }
            }
        }
    }
}
