
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class LinkListReverse
    {

        //Load Latency (GO, protobuf) user, authentication services.
        //dynamo and mongo
        //android and swift
        //react 
        //geoEvent

        public static void Init()
        {
            List list = new List();

            list.append(1);
            list.append(2);
            list.append(3);
            list.append(4);
            list.append(5);

            Console.WriteLine("List is reversed using other data structure:");
            list.reverse();
            Console.WriteLine("");
            Console.WriteLine("List is reversed in place:");
            list.reverseInPlace();

        }

        class Node
        {
            private Object value;
            private Node next;

            public Node(Object value)
            {
                this.value = value;
            }

            public Object getValue()
            {
                return value;
            }

            public void setNext(Node next)
            {
                this.next = next;
            }

            public Node getNext()
            {
                return this.next;
            }
        }

        class List
        {
            private Node head = null;

            public Node first()
            {
                return head;
            }

            public void append(Object value)
            {
                // TODO
                Node current = new Node(value);
                if (head == null)
                    head = current;
                else
                {
                    Node temp = head;
                    while (temp.getNext() != null)
                    {
                        temp = temp.getNext();
                    }
                    temp.setNext(current);
                }
            }

            public void reverse()
            {
                // TODO
                if (head != null)
                {
                    List<object> tempStore = new List<object>();
                    Node current = head;
                    do
                    {
                        tempStore.Add(current.getValue());
                        current = current.getNext();
                    } while (current != null);

                    tempStore.Reverse();
                    head = null;
                    foreach (object o in tempStore)
                    {
                        this.append(o);
                    }
                }

                Print();
            }

            public void reverseInPlace()
            {
                // TODO
                if (head != null)
                {
                    Node current = head;
                    Node Next = current.getNext();
                    current.setNext(null); //Mark it as last node
                    do
                    {
                        Node temp = Next.getNext();
                        Next.setNext(current);
                        current = Next;
                        Next = temp;
                    } while (Next != null);

                    head = current;
                }

                Print();
            }

            public void Print()
            {
                if(head == null)
                {
                    Console.Write("List is empty");
                    return;
                }

                Node current = head;
                while (current != null)
                {
                    Console.Write(current.getValue());
                    current = current.getNext();
                }
            }
        }
    }
}
