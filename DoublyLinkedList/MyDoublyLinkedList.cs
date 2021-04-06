using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lists
{
    public class MyDoublyLinkedList<T> : IList<T>, IEnumerable<T> where T : IComparable
    {
        private class NodeDoubly<U>
        {
            public U Data { get; set; }
            public NodeDoubly<U> Next { get; set; }
            public NodeDoubly<U> Previous { get; set; }

            public NodeDoubly(U data)
            {
                Data = data;
            }
        }

        private NodeDoubly<T> _head;
        private NodeDoubly<T> _tail;

        public int Count { get; set; }

        public T this[int index]
        {
            get
            {
                if (IsValidIndex(index))
                {
                    NodeDoubly<T> current = _head;

                    for (int i = 1; i <= index; i++)
                    {
                        current.Previous = current;
                        current = current.Next;
                    }

                    return current.Data;
                }

                throw new IndexOutOfRangeException("Invalid index!");
            }
            set
            {
                if (!(value is null))
                {
                    if (IsValidIndex(index))
                    {
                        NodeDoubly<T> current = _head;

                        for (int i = 1; i <= index; i++)
                        {
                            current.Previous = current;
                            current = current.Next;
                        }

                        current.Data = value;
                    }
                    else
                    {
                        throw new IndexOutOfRangeException("Invalid index");
                    }
                }
                else
                {
                    throw new NullReferenceException("Data cannot be null");
                }
            }
        }

        public MyDoublyLinkedList()
        {
            Count = 0;
            _head = null;
            _tail = null;
        }

        public static MyDoublyLinkedList<T> Create(T data)
        {
            if (!(data is null))
            {
                return new MyDoublyLinkedList<T>(data);
            }
            else
            {
                throw new ArgumentNullException("Null data passed");
            }
        }

        public static MyDoublyLinkedList<T> Create(IEnumerable<T> data)
        {
            if (!(data is null))
            {
                return new MyDoublyLinkedList<T>(data);
            }
            else
            {
                throw new ArgumentNullException("Null data passed");
            }
        }

        private MyDoublyLinkedList(T data)
        {
            Count = 1;
            _head = new NodeDoubly<T>(data);
            _tail = _head;
        }

        private MyDoublyLinkedList(IEnumerable<T> data)
        {
            Count = data.Count();

            if (data.Count() != 0)
            {
                _head = new NodeDoubly<T>(data.First());
                _head.Previous = null;
                _head.Next = null;
                _tail = _head;

                for (int i = 1; i < data.Count(); i++)
                {
                    _tail.Next = new NodeDoubly<T>(data.ElementAt(i));
                    _tail.Next.Previous = _tail;
                    _tail = _tail.Next;
                }
            }
            else
            {
                _head = null;
                _tail = null;
            }
        }

        public void Clear()
        {
            Count = 0;
            _head = null;
            _tail = null;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int i = 0;

            foreach (var item in this)
            {
                array[i++] = item;
            }

            return array;
        }

        public void AddStart(T data)
        {
            AddByIndex(index: 0, data);
        }

        public void Add(T data)
        {
            AddByIndex(index: Count, data);
        }

        public void AddByIndex(int index, T data)
        {
            if (data != null && index >= 0 && index <= Count)
            {
                NodeDoubly<T> item = new NodeDoubly<T>(data);

                if (index != 0)
                {
                    NodeDoubly<T> current = _head;
                    current.Previous = null;

                    for (int i = 1; i <= index; i++)
                    {
                        if (i == index)
                        {
                            item.Previous = current;
                            item.Next = current.Next;
                            current.Next = item;

                            if (index == Count)
                            {
                                item.Previous = _tail;
                                _tail.Next = item;
                                item.Next = null;
                                _tail = item;
                            }
                        }
                        current.Previous = current;
                        current = current.Next;
                    }
                }
                else
                {
                    item.Next = _head;

                    if (_head != null)
                    {
                        _head.Previous = item;
                    }

                    _head = item;
                }

                ++Count;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddRangeStart(T[] collection)
        {
            AddRangeByIndex(index: 0, collection);
        }

        public void AddRange(T[] collection)
        {
            AddRangeByIndex(Count, collection);
        }

        public void AddRangeByIndex(int index, T[] collection)
        {
            if (index >= 0 && index <= Count && !(collection is null))
            {
                var temp = default(NodeDoubly<T>);
                NodeDoubly<T> current = _head;

                if (index != 0)
                {
                    int j = 0;
                    int lenth = index + collection.Length;

                    for (int i = 1; i < lenth; i++)
                    {
                        if (i >= index)
                        {
                            if (i == index)
                            {
                                temp = current.Next;
                            }
                            current.Next = new NodeDoubly<T>(collection[j++]);
                            current.Next.Previous = current;
                        }

                        current.Previous = current;
                        current = current.Next;
                    }

                    current.Next = temp;

                    if (Count != index)
                    {
                        temp.Previous = current;
                    }
                    else
                    {
                        _tail = current.Next;
                    }
                }
                else
                {
                    temp = _head;
                    _head = new NodeDoubly<T>(collection[0]);
                    current = _head;

                    for (int i = 1; i < collection.Length; i++)
                    {
                        current.Next = new NodeDoubly<T>(collection[i]);
                        current.Next.Previous = current;
                        current = current.Next;
                    }

                    current.Next = temp;

                    if (current.Next == null)
                    {
                        _tail = current;
                    }
                }

                Count += collection.Length;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public T RemoveByIndex(int index)
        {
            if (IsValidIndex(index) && !(_head is null))
            {
                T data = default;

                if (index == 0)
                {
                    data = _head.Data;

                    if (Count == 1)
                    {
                        _head = null;
                        _tail = null;
                    }
                    else
                    {
                        _head = _head.Next;
                        _head.Previous = null;
                    }
                }
                else
                {
                    NodeDoubly<T> current = _head;

                    for (int i = 0; i < index; i++)
                    {
                        if (i == index - 1)
                        {
                            data = current.Next.Data;
                            current.Next = current.Next?.Next;

                            if (index == Count - 1)
                            {
                                _tail = current.Next;
                            }
                            else
                            {
                                current.Next.Previous = current;
                            }
                        }

                        current = current.Next;
                    }
                }

                --Count;
                return data;
            }
            else if (_head is null)
            {
                throw new NullReferenceException("List is empty!");
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid index!");
            }
        }

        public T RemoveStart()
        {
            return RemoveByIndex(index: 0);
        }

        public T Remove()
        {
            return RemoveByIndex(Count - 1);
        }

        public void RemoveRangeByIndex(int index, int quantity)
        {
            if (IsValidIndex(index) && !(_head is null) && quantity <= Count - index)
            {
                NodeDoubly<T> current = _head;
                NodeDoubly<T> item = default;
                int indexLastDeletItem = index + quantity;

                if (index == 0)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        current.Previous = current;
                        current = current.Next;
                    }

                    _head = current;

                    if (current != null)
                    {
                        current.Previous = null;
                    }
                    else
                    {
                        _tail = _head;
                    }
                }
                else
                {
                    for (int i = 1; i <= Count; i++)
                    {
                        if (i == index)
                        {
                            item = current;
                        }
                        else if (i == indexLastDeletItem)
                        {
                            item.Next = current.Next;
                            current = item;
                        }

                        current.Previous = current;
                        current = current.Next;
                    }
                }

                Count -= quantity;
            }
            else if (_head is null)
            {
                throw new NullReferenceException();
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveRangeStart(int quantity)
        {
            RemoveRangeByIndex(index: 0, quantity);
        }

        public void RemoveRange(int quantity)
        {
            if (quantity != 0)
            {
                RemoveRangeByIndex(Count - quantity, quantity);
            }
        }

        public int RemoveByValueFirst(T data)
        {
            int index = -1;
            NodeDoubly<T> current = _head;

            for (int i = 0; i < Count; i++)
            {
                if (current.Data.CompareTo(data) == 0)
                {
                    RemoveByIndex(i);
                    index = i;
                    break;
                }

                current.Previous = current;
                current = current.Next;
            }
            return index;
        }

        public int RemoveByValueAll(T data)
        {
            int counter = 0;
            NodeDoubly<T> current = _head;

            for (int i = 0; i < Count; i++)
            {
                if (current.Data.CompareTo(data) == 0)
                {
                    RemoveByIndex(i);
                    ++counter;
                    --i;
                }

                current.Previous = current;
                current = current.Next;
            }

            return counter;
        }

        public int FindIndexByValue(T data)
        {
            int index = -1;
            NodeDoubly<T> current = _head;

            for (int i = 0; i < Count; i++)
            {
                if (current.Data.CompareTo(data) == 0)
                {
                    index = i;
                    break;
                }

                current.Previous = current;
                current = current.Next;
            }

            return index;
        }

        public int GetMaxIndex()
        {
            if (!(_head is null))
            {
                NodeDoubly<T> current = _head;
                T dataMax = _head.Data;
                int index = 0;

                for (int i = 1; i < Count; i++)
                {
                    if (dataMax.CompareTo(current.Next.Data) == -1)
                    {
                        index = i;
                        dataMax = current.Next.Data;
                    }

                    current.Previous = current;
                    current = current.Next;
                }

                return index;
            }

            throw new InvalidOperationException();
        }

        public T GetMax()
        {
            if (!(_head is null))
            {
                NodeDoubly<T> current = _head;
                T dataMax = _head.Data;

                for (int i = 1; i < Count; i++)
                {
                    if (dataMax.CompareTo(current.Next.Data) == -1)
                    {
                        dataMax = current.Next.Data;
                    }

                    current.Previous = current;
                    current = current.Next;
                }

                return dataMax;
            }

            throw new InvalidOperationException();
        }

        public int GetMinIndex()
        {
            if (!(_head is null))
            {
                NodeDoubly<T> current = _head;
                T dataMin = _head.Data;
                int index = 0;

                for (int i = 1; i < Count; i++)
                {
                    if (dataMin.CompareTo(current.Next.Data) == 1)
                    {
                        index = i;
                        dataMin = current.Next.Data;
                    }
                    current = current.Next;
                }

                return index;
            }

            throw new InvalidOperationException();
        }

        public T GetMin()
        {
            if (!(_head is null))
            {
                NodeDoubly<T> current = _head;
                T dataMin = _head.Data;

                for (int i = 1; i < Count; i++)
                {
                    if (dataMin.CompareTo(current.Next.Data) == 1)
                    {
                        dataMin = current.Next.Data;
                    }
                    current = current.Next;
                }

                return dataMin;
            }

            throw new InvalidOperationException();
        }

        public void Sort(bool isAscending=true)
        {
            NodeDoubly<T> current = _head;
            NodeDoubly<T> sorted = null;
            int coefficient = isAscending ? -1 : 1;

            while (current != null)
            {
                NodeDoubly<T> next = current.Next;
                current.Previous = current.Next = null;

                sorted =InstertionSort(sorted, current, coefficient);

                current = next;
            }

            _head = sorted;
        }

        public override string ToString()
        {
            if (Count != 0)
            {
                NodeDoubly<T> current = _head;
                StringBuilder stringBuilder = new StringBuilder($"{current.Data} ");

                while (!(current.Next is null))
                {
                    current.Previous = current;
                    current = current.Next;
                    stringBuilder.Append($"{current.Data} ");
                }

                return stringBuilder.ToString().Trim();
            }
            else
            {
                return string.Empty;
            }
        }

        public void Reverse()
        {
            if (!(_head is null))
            {
                NodeDoubly<T> temp = null;
                NodeDoubly<T> current = _head;

                while (current != null)
                {
                    temp = current.Previous;
                    current.Previous = current.Next;
                    current.Next = temp;
                    current = current.Previous;
                }

                if (temp != null)
                {
                    _head = temp.Previous;
                }
            }
        }

        public void HalfReverse()
        {
            if (!(_head is null))
            {
                NodeDoubly<T> current = _head;
                NodeDoubly<T> temp = _head;
                int coefficient = (Count + Count % 2) / 2;

                if (Count % 2 == 0)
                {
                    for (int i = 0; i < Count + coefficient - 1; i++)
                    {
                        if (i == coefficient)
                        {
                            _head = current;
                        }

                        if (i == Count - 1)
                        {
                            current.Next = temp;
                        }

                        current.Previous = current;
                        current = current.Next;
                    }

                    current.Next = null;
                }
                else
                {
                    NodeDoubly<T> item = default;

                    for (int i = 1; i < Count + coefficient; i++)
                    {
                        if (i == coefficient)
                        {
                            item = current;
                            _head = current.Next;
                        }

                        if (i == Count)
                        {
                            current.Next = item;
                            current.Next.Next = temp;
                        }

                        current.Previous = current;
                        current = current.Next;
                    }

                    current.Next = null;
                }
            }
        }

        private NodeDoubly<T> InstertionSort(NodeDoubly<T> sorted, NodeDoubly<T> newNode, int coefficient)
        {
            NodeDoubly<T> current;

            if (sorted == null)
            {
                sorted = newNode;
            }

            else if (sorted.Data.CompareTo(newNode.Data)!=coefficient || sorted.Data.CompareTo(newNode.Data)==0)
            {
                newNode.Next = sorted;
                newNode.Next.Previous = newNode;
                sorted = newNode;
            }
            else
            {
                current = sorted;

                while (current.Next != null &&
                       current.Next.Data.CompareTo(newNode.Data) == coefficient)
                {
                    current = current.Next;
                }

                newNode.Next = current.Next;

                if (current.Next != null)
                {
                    newNode.Next.Previous = newNode;
                }

                current.Next = newNode;
                newNode.Previous = current;
            }
            return sorted;
        }

        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            NodeDoubly<T> current = _head;

            while (current != null)
            {
                yield return current.Data;
                current.Previous = current;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
