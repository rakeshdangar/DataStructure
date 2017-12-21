using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DataStructureImplementation
{
    // Linked List
    class Node 
    {
        public Node next = null;
        public int data;
        public Node(int d) { data = d; }
        
        void appendToTail(int d) 
        {
            Node end = new Node(d);
            Node n = this;
            while (n.next != null) 
            { 
                n = n.next; 
            }
            n.next = end;
        }

        void deleteNode(Node head, int d)
        {
            Node n = head;
            if (n.data == d)
            {
                head = head.next; /* moved head */
            }
            while (n.next != null)
            {
                if (n.next.data == d)
                {
                    n.next = n.next.next;                    
                }
                n = n.next;
            }
        }
    }

    // Stack
    class Stack 
    { 
        Node top;
        int pop() 
        {
            if (top != null) 
            {
                int item = top.data;
                top = top.next;
                return item;
            }
            return -1;
        }
    
        void push(int item) 
        { 
            Node t = new Node(item);
            t.next = top;
            top = t;
        } 
    }
    
 
    // Queue
    class Queue 
    {
        Node first, last;
        Node back = null;
        Node front = null;
        void enqueue(int item) 
        { 
            if (null != first) 
            {
                back = new Node(item);
                first = back;
            } 
            else 
            {
                back.next = new Node(item);
                back = back.next;
            }
        }
    
        int dequeue(Node n) 
        { 
            if (front != null) 
            {
                int item = front.data;
                front = front.next;
                return item;
            }
            return -1;
        } 
    }

    //HEAP
    public abstract class Heap<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 0;
        private const int GrowFactor = 2;
        private const int MinGrow = 1;

        private int _capacity = InitialCapacity;
        private T[] _heap = new T[InitialCapacity];
        private int _tail = 0;

        public int Count { get { return _tail; } }
        public int Capacity { get { return _capacity; } }

        protected Comparer<T> Comparer { get; private set; }
        protected abstract bool Dominates(T x, T y);

        protected Heap()
            : this(Comparer<T>.Default)
        {
        }

        protected Heap(Comparer<T> comparer)
            : this(Enumerable.Empty<T>(), comparer)
        {
        }

        protected Heap(IEnumerable<T> collection)
            : this(collection, Comparer<T>.Default)
        {
        }

        protected Heap(IEnumerable<T> collection, Comparer<T> comparer)
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (comparer == null) throw new ArgumentNullException("comparer");

            Comparer = comparer;

            foreach (var item in collection)
            {
                if (Count == Capacity)
                    Grow();

                _heap[_tail++] = item;
            }

            for (int i = Parent(_tail - 1); i >= 0; i--)
                BubbleDown(i);
        }

        public void Add(T item)
        {
            if (Count == Capacity)
                Grow();

            _heap[_tail++] = item;
            BubbleUp(_tail - 1);
        }

        private void BubbleUp(int i)
        {
            if (i == 0 || Dominates(_heap[Parent(i)], _heap[i]))
                return; //correct domination (or root)

            Swap(i, Parent(i));
            BubbleUp(Parent(i));
        }

        public T GetMin()
        {
            if (Count == 0) throw new InvalidOperationException("Heap is empty");
            return _heap[0];
        }

        public T ExtractDominating()
        {
            if (Count == 0) throw new InvalidOperationException("Heap is empty");
            T ret = _heap[0];
            _tail--;
            Swap(_tail, 0);
            BubbleDown(0);
            return ret;
        }

        private void BubbleDown(int i)
        {
            int dominatingNode = Dominating(i);
            if (dominatingNode == i) return;
            Swap(i, dominatingNode);
            BubbleDown(dominatingNode);
        }

        private int Dominating(int i)
        {
            int dominatingNode = i;
            dominatingNode = GetDominating(YoungChild(i), dominatingNode);
            dominatingNode = GetDominating(OldChild(i), dominatingNode);

            return dominatingNode;
        }

        private int GetDominating(int newNode, int dominatingNode)
        {
            if (newNode < _tail && !Dominates(_heap[dominatingNode], _heap[newNode]))
                return newNode;
            else
                return dominatingNode;
        }

        private void Swap(int i, int j)
        {
            T tmp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = tmp;
        }

        private static int Parent(int i)
        {
            return (i + 1) / 2 - 1;
        }

        private static int YoungChild(int i)
        {
            return (i + 1) * 2 - 1;
        }

        private static int OldChild(int i)
        {
            return YoungChild(i) + 1;
        }

        private void Grow()
        {
            int newCapacity = _capacity * GrowFactor + MinGrow;
            var newHeap = new T[newCapacity];
            Array.Copy(_heap, newHeap, _capacity);
            _heap = newHeap;
            _capacity = newCapacity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _heap.Take(Count).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MaxHeap<T> : Heap<T>
    {
        public MaxHeap()
            : this(Comparer<T>.Default)
        {
        }

        public MaxHeap(Comparer<T> comparer)
            : base(comparer)
        {
        }

        public MaxHeap(IEnumerable<T> collection, Comparer<T> comparer)
            : base(collection, comparer)
        {
        }

        public MaxHeap(IEnumerable<T> collection)
            : base(collection)
        {
        }

        protected override bool Dominates(T x, T y)
        {
            return Comparer.Compare(x, y) >= 0;
        }
    }

    public class MinHeap<T> : Heap<T>
    {
        public MinHeap()
            : this(Comparer<T>.Default)
        {
        }

        public MinHeap(Comparer<T> comparer)
            : base(comparer)
        {
        }

        public MinHeap(IEnumerable<T> collection)
            : base(collection)
        {
        }

        public MinHeap(IEnumerable<T> collection, Comparer<T> comparer)
            : base(collection, comparer)
        {
        }

        protected override bool Dominates(T x, T y)
        {
            return Comparer.Compare(x, y) <= 0;
        }
    }

    // [TestClass] for HEAP
    public class HeapTests
    {
        //[TestMethod]
        public void TestHeapBySorting()
        {
            var minHeap = new MinHeap<int>(new[] { 9, 8, 4, 1, 6, 2, 7, 4, 1, 2 });
            AssertHeapSort(minHeap, minHeap.OrderBy(i => i).ToArray());

            minHeap = new MinHeap<int> { 7, 5, 1, 6, 3, 2, 4, 1, 2, 1, 3, 4, 7 };
            AssertHeapSort(minHeap, minHeap.OrderBy(i => i).ToArray());

            var maxHeap = new MaxHeap<int>(new[] { 1, 5, 3, 2, 7, 56, 3, 1, 23, 5, 2, 1 });
            AssertHeapSort(maxHeap, maxHeap.OrderBy(d => -d).ToArray());

            maxHeap = new MaxHeap<int> { 2, 6, 1, 3, 56, 1, 4, 7, 8, 23, 4, 5, 7, 34, 1, 4 };
            AssertHeapSort(maxHeap, maxHeap.OrderBy(d => -d).ToArray());
        }

        private static void AssertHeapSort(Heap<int> heap, IEnumerable<int> expected)
        {
            var sorted = new List<int>();
            while (heap.Count > 0)
                sorted.Add(heap.ExtractDominating());

            //Assert.IsTrue(sorted.SequenceEqual(expected));
        }
    }
    
}
