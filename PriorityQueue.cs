using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class PriorityQueue<TPriority, TValue> //: ICollection<KeyValuePair<TPriority, TValue>>
    {
        //Custom comparer.
        class MyComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                // "inverted" comparison
                // direct comparison of integers should return x - y
                return y - x;
            }
        }

        public static void Init()
        {        
            // this priority queue uses "inverted" comparer, 
            // so in fact it is max-priority queue
            PriorityQueue<int, string> q = new PriorityQueue<int, string>(new MyComparer());    
        }

        private List<KeyValuePair<TPriority, TValue>> _baseHeap;
        private IComparer<TPriority> _comparer;

        #region Constructors
        public PriorityQueue()
            : this(Comparer<TPriority>.Default)
        {
        }

        public PriorityQueue(IComparer<TPriority> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();

            _baseHeap = new List<KeyValuePair<TPriority, TValue>>();
            _comparer = comparer;
        }

        public PriorityQueue(IEnumerable<KeyValuePair<TPriority, TValue>> data, IComparer<TPriority> comparer)
        {
            if (data == null || comparer == null)
                throw new ArgumentNullException();

            _comparer = comparer;
            _baseHeap = new List<KeyValuePair<TPriority, TValue>>(data);
            // heapify data
            for (int pos = _baseHeap.Count / 2 - 1; pos >= 0; pos--)
                HeapifyFromBeginningToEnd(pos);
        }
        #endregion

        public void Enqueue(TPriority priority, TValue value)
        {
            Insert(priority, value);
        }

        public TValue DequeueValue()
        {
            return Dequeue().Value;
        }
        
        public KeyValuePair<TPriority, TValue> Peek()
        {
            if (!IsEmpty)
                return _baseHeap[0];
            else
                throw new InvalidOperationException("Priority queue is empty");
        }

        public TValue PeekValue()
        {
            return Peek().Value;
        }

        public bool IsEmpty
        {
            get { return _baseHeap.Count == 0; }
        }

        private KeyValuePair<TPriority, TValue> Dequeue()
        {
            if (!IsEmpty)
            {
                KeyValuePair<TPriority, TValue> result = _baseHeap[0];
                DeleteRoot();
                return result;
            }
            else
                throw new InvalidOperationException("Priority queue is empty");
        }

        private void Insert(TPriority priority, TValue value)
        {
            KeyValuePair<TPriority, TValue> val =
                new KeyValuePair<TPriority, TValue>(priority, value);
            _baseHeap.Add(val);

            // heapify after insert, from end to beginning
            HeapifyFromEndToBeginning(_baseHeap.Count - 1);
        }

        private int HeapifyFromEndToBeginning(int pos)
        {
            if (pos >= _baseHeap.Count) return -1;

            // heap[i] have children heap[2*i + 1] and heap[2*i + 2] and parent heap[(i-1)/ 2];

            while (pos > 0)
            {
                int parentPos = (pos - 1) / 2;
                if (_comparer.Compare(_baseHeap[parentPos].Key, _baseHeap[pos].Key) > 0)
                {
                    ExchangeElements(parentPos, pos);
                    pos = parentPos;
                }
                else break;
            }
            return pos;
        }

        private void ExchangeElements(int pos1, int pos2)
        {
            KeyValuePair<TPriority, TValue> val = _baseHeap[pos1];
            _baseHeap[pos1] = _baseHeap[pos2];
            _baseHeap[pos2] = val;
        }

        private void DeleteRoot()
        {
            if (_baseHeap.Count <= 1)
            {
                _baseHeap.Clear();
                return;
            }

            _baseHeap[0] = _baseHeap[_baseHeap.Count - 1];
            _baseHeap.RemoveAt(_baseHeap.Count - 1);

            // heapify
            HeapifyFromBeginningToEnd(0);
        }

        private void HeapifyFromBeginningToEnd(int pos)
        {
            if (pos >= _baseHeap.Count) return;

            // heap[i] have children heap[2*i + 1] and heap[2*i + 2] and parent heap[(i-1)/ 2];

            while (true)
            {
                // on each iteration exchange element with its smallest child
                int smallest = pos;
                int left = 2 * pos + 1;
                int right = 2 * pos + 2;
                if (left < _baseHeap.Count &&
                    _comparer.Compare(_baseHeap[smallest].Key, _baseHeap[left].Key) > 0)
                    smallest = left;
                if (right < _baseHeap.Count &&
                    _comparer.Compare(_baseHeap[smallest].Key, _baseHeap[right].Key) > 0)
                    smallest = right;

                if (smallest != pos)
                {
                    ExchangeElements(smallest, pos);
                    pos = smallest;
                }
                else break;
            }
        }

        //Following method works when PriorityQueue implements ICollection
        //public static PriorityQueue<TPriority, TValue> MergeQueues (PriorityQueue<TPriority, TValue> pq1,
        //                                                            PriorityQueue<TPriority, TValue> pq2,
        //                                                            IComparer<TPriority> comparer)
        //{
        //    if (pq1 == null || pq2 == null || comparer == null)
        //        throw new ArgumentNullException();
        //    // merge data
        //    PriorityQueue<TPriority, TValue> result = new PriorityQueue<TPriority, TValue>(pq1.Count + pq2.Count, pq1._comparer);
        //    result._baseHeap.AddRange(pq1._baseHeap);
        //    result._baseHeap.AddRange(pq2._baseHeap);
        //    // heapify data
        //    for (int pos = result._baseHeap.Count / 2 - 1; pos >= 0; pos--)
        //        result.HeapifyFromBeginningToEnd(pos);

        //    return result;
        //}

        //public bool Remove(KeyValuePair<TPriority, TValue> item)
        //{
        //    // find element in the collection and remove it
        //    int elementIdx = _baseHeap.IndexOf(item);
        //    if (elementIdx < 0) return false;

        //    //remove element
        //    _baseHeap[elementIdx] = _baseHeap[_baseHeap.Count - 1];
        //    _baseHeap.RemoveAt(_baseHeap.Count - 1);

        //    // heapify
        //    int newPos = HeapifyFromEndToBeginning(elementIdx);
        //    if (newPos == elementIdx)
        //        HeapifyFromBeginningToEnd(elementIdx);

        //    return true;
        //}
    }
}
