using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement
{
    class Task
    {
        /*
        We are designing a task management system that processes a series of tasks.  For every task ran a number of follow-up tasks are defined that continue the processing initiated in the initial task.  Tasks are described like so;

        A => B

        Meaning that after running “Task A” the system will run “Task B”.

        For this task we are only concerned with outputting a plan of how to run the tasks.

        Given the following task definition.
        A => B
        A => C
        A => D
        B => E
        C => F

        Create a method to print the following output, given Task A as an input.
        A
        -B
        --E
        -C
        --F
        -D
        */

        class Node
        {
            public char Value { get; private set; }
            public IList<Node> Children { get; private set; }

            //Constructor
            public Node(char value)
            {
                Value = value;
                Children = new List<Node>();
            }

            public static void PrintTasks(Node root, int level)
            {
                if (root == null)
                    return;

                string hiphan = string.Empty;
                for (int i = 0; i < level; i++)
                {
                    hiphan += "-";
                }
                Console.WriteLine(hiphan + root.Value.ToString());

                if (root.Children != null)
                {
                    foreach (Node n in root.Children)
                    {
                        level++;
                        PrintTasks(n, level);
                        level--;
                    }
                }
            }
        }

        public static void Init()
        {
            Node A = new Node('A');
            Node B = new Node('B');
            Node E = new Node('E');
            Node C = new Node('C');
            Node F = new Node('F');
            Node D = new Node('D');

            A.Children.Add(B);
            B.Children.Add(E);
            A.Children.Add(C);
            C.Children.Add(F);
            A.Children.Add(D);

            Node.PrintTasks(A, 0);
        }
    }
}
