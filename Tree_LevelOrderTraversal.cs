using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Tree_LevelOrderTraversal
    {
        public static void Init()
        {
           BinaryTree tree = new BinaryTree();
           tree.root = new Node(1);
           tree.root.left= new Node(2);
           tree.root.right= new Node(3);
           tree.root.left.left= new Node(4);
           tree.root.left.right= new Node(5);
        
           Console.WriteLine("Level order traversal of binary tree is ");
           tree.printLevelOrder();
           Console.WriteLine();
           Console.WriteLine("Level order traversal of binary tree using queue is ");
           tree.printLevelOrderUsingQueue();
        }

        class Node
        {
            public int data;
            public Node left, right;
            public Node(int item)
            {
                data = item;
                left = right = null;
            }
        }
 
        class BinaryTree
        {
            // Root of the Binary Tree
            public Node root;
 
            public BinaryTree()
            {
                root = null;
            }

            public void printLevelOrderUsingQueue()
            {
                Queue<Node> queue = new Queue<Node>();
                queue.Enqueue(root);
                while (queue.Count > 0)
                {
                    /* poll() removes the present head.
                    For more information on poll() visit 
                    http://www.tutorialspoint.com/java/util/linkedlist_poll.htm */
                    Node tempNode = queue.Dequeue();
                    Console.Write(tempNode.data + " ");

                    /*Enqueue left child */
                    if (tempNode.left != null)
                    {
                        queue.Enqueue(tempNode.left);
                    }

                    /*Enqueue right child */
                    if (tempNode.right != null)
                    {
                        queue.Enqueue(tempNode.right);
                    }
                }
            }
 
            /* function to print level order traversal of tree*/
            public void printLevelOrder()
            {
                int h = height(root);
                int i;
                for (i=1; i<=h; i++)
                    printGivenLevel(root, i);
            }
 
            /* Compute the "height" of a tree -- the number of
            nodes along the longest path from the root node
            down to the farthest leaf node.*/
            int height(Node root)
            {
                if (root == null)
                   return 0;
                else
                {
                    /* compute  height of each subtree */
                    int lheight = height(root.left);
                    int rheight = height(root.right);
             
                    /* use the larger one */
                    if (lheight > rheight)
                        return(lheight+1);
                    else return(rheight+1); 
                }
            }
 
            /* Print nodes at the given level */
            void printGivenLevel (Node root ,int level)
            {
                if (root == null)
                    return;
                if (level == 1)
                    Console.Write(root.data + " ");
                else if (level > 1)
                {
                    printGivenLevel(root.left, level-1);
                    printGivenLevel(root.right, level-1);
                }
            }
        }            
    }
}
