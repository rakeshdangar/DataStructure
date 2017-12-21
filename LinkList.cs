using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class LinkList
    {
        private int size;
        public Node Current;
        public Node Head;

        public class Node
        {
            public int content;
            public Node Next;
        }

        public int count
        {
            get{ return size; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public LinkList()
        {
            size = 0;
            Head = null;
        }

        public void PrintList()
        {
            Node temp = Head;
            while (temp != null)
            {
                Console.Write(temp.content);
                temp = temp.Next;
            }
        }

        public void Add(int n)
        {
            var node = new Node() { content = n };

            if (Head == null)
                Head = node;
            else
            {                
                Current.Next = node;
            }
            Current = node;
            size++;
        }

        public void DeleteByContent(int n)
        {
            if (Head == null)
            {
                Console.Write("List is empty");
                return;
            }
            else if (Head.content == n)
            {
                Head = null;
                Current = null;
                Console.WriteLine("Deleting head");
            }
            else
            {
                Node temp = Head;
                Node previous = null;
                while (temp.content != n)
                {
                    previous = temp;
                    temp = temp.Next;
                }
                if (temp == Current)
                    Current = previous;
                previous.Next = temp.Next;
            }
            size--;
        }

        public void DeleteByPosition(int pos)
        {
            if(pos > count)
            {
                Console.WriteLine("List content less element than position specified to be deleted");
            }
            else if (pos == 1)
            {
                Head = Head.Next;
                Console.WriteLine("Deleting head");
            }
            else
            {
                Node temp = Head;
                Node previous = null;
                int index = 1;
                while (temp != null)
                {
                    if (index == pos)
                    {
                        if (temp == Current)
                            Current = previous;
                        previous.Next = temp.Next;
                    }
                    previous = temp;
                    temp = temp.Next;
                    index++;
                }
            }
            size--;
        }

        public void Retrieve(int pos)
        {
            if (pos > count)
            {
                Console.WriteLine("List content less element than position specified to be retrived");
            }
            else if (pos == 1)
                Console.WriteLine(Head.content);
            else
            {
                Node temp = Head;
                int index = 1;
                while (temp != null)
                {
                    if (index == pos)
                    {
                        Console.WriteLine(temp.content);
                    }
                    temp = temp.Next;
                    index++;
                }
            }
        }
    }

    public class LinkListUtil
    {
        public static void Init()
        {
            LinkList list = new LinkList();
            Console.WriteLine("This is the initial list");
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.PrintList();

            Console.WriteLine();
            Console.WriteLine("List after delete by content operation");
            list.DeleteByContent(3);
            list.DeleteByContent(5);
            list.PrintList();

            Console.WriteLine();
            Console.WriteLine("Add after delete operation");
            list.Add(6);
            list.PrintList();

            Console.WriteLine();
            Console.WriteLine("List after delete by position operation");
            list.DeleteByPosition(4);
            list.PrintList();

            Console.WriteLine();
            Console.WriteLine("Add after delete by position operation");
            list.Add(7);
            list.PrintList();

            Console.WriteLine();
            Console.WriteLine("Retrieve node content at position");
            list.Retrieve(9);
            list.PrintList();
        }
    }
}
