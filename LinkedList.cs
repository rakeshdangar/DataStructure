using System;

// To execute C#, please define "static void Main" on a class
// named Solution.

namespace ConsoleApplication1
{
    public class LinkedList
    {
        public static void Init()
        {
            List list = new List();

            list.Add("A");
            list.Add("B");
            list.Add("C");
            list.Add("D");
            list.Add("E");
            list.Add("F");
            list.Add("G");
            list.Add("H");

            list.ListNodes();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Position 5: " + list.Retrieve(5).nodeContent);

            Console.WriteLine();
            Console.WriteLine("Deleting node 8");
            list.Delete(8);
            list.ListNodes();

            //Console.WriteLine();
            //Console.WriteLine("Deleting node 5");
            //list.Delete(5);
            //list.ListNodes();

            Console.WriteLine();
            if (list.Retrieve(8) != null)
            {
                Console.WriteLine("Position 8: " + list.Retrieve(8).nodeContent);
            }
            else
            {
                Console.WriteLine("Position 8: No element exist at this position");
            }

            Console.WriteLine("Insert Element D");
            list.Add("D");
            Console.WriteLine();
            list.ListNodes();
        }
    }

    public class List
    {
        public class Node
        {
            public object nodeContent;
            public Node next;
        }

        private int size;
        public int Count
        {
            get
            {
                return size;
            }
        }

        public Node Head;
        public Node Current;

        public List()
        {
            size = 0;
            Head = null;
        }

        public void Add(object content)
        {
            var node = new Node()
            {
                nodeContent = content
            };

            if (Head == null)
            {
                Head = node;
            }
            else
            {
                Current.next = node;
            }
            Current = node;
            size++;
        }


        public void ListNodes()
        {
            Node temp = Head;
            while (temp != null)
            {
                Console.WriteLine(temp.nodeContent);
                temp = temp.next;
            }
        }

        public Node Retrieve(int pos)
        {
            Node temp = Head;
            Node retNode = null;
            int count = 0;

            while (temp != null)
            {
                if (count == pos - 1)
                {
                    retNode = temp;
                    break;
                }
                count++;
                temp = temp.next;
            }
            return retNode;
        }

        public bool Delete(int pos)
        {
            if (pos == 1)
            {
                Head = null;
                Current = null;
                return true;
            }
            if (pos > 1 && pos <= size)
            {
                Node temp = Head;
                Node prev = null;
                int count = 0;

                while (temp != null)
                {
                    if (count == pos - 1)
                    {
                        if (temp == Current)
                            Current = prev;
                        prev.next = temp.next;
                        size--;
                        return true;
                    }
                    count++;
                    prev = temp;
                    temp = temp.next;
                }
            }
            return false;
        }
    }
}
