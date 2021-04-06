using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lists
{
    public class MyLinkedList<T> : IList<T>, IEnumerable<T> where T : IComparable
    {
        private class Node<U>
        {
            public U Data { get; set; }

            public Node<U> Next { get; set; }

            public Node(U data)
            {
                Data = data;
            }
        }

        private Node<T> _head;
        private Node<T> _tail;

        public int Count { get; set; }

        public T this[int index]
        {
            get
            {
                if (IsValidIndex(index))
                {
                    Node<T> current = _head;

                    for (int i = 1; i <= index; i++)
                    {
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
                        Node<T> current = _head;

                        for (int i = 1; i <= index; i++)
                        {
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

        public MyLinkedList()
        {
            Count = 0;
            _head = null;
            _tail = null;
        }

        public static MyLinkedList<T> Create(T data)
        {
            if (!(data is null))
            {
                return new MyLinkedList<T>(data);
            }
            else
            {
                throw new ArgumentNullException("Null data passed");
            }
        }

        public static MyLinkedList<T> Create(IEnumerable<T> data)
        {
            if (!(data is null))
            {
                return new MyLinkedList<T>(data);
            }
            else
            {
                throw new ArgumentNullException("Null data passed!");
            }
        }

        private MyLinkedList(T data)
        {
            Count = 1;
            _head = new Node<T>(data);
            _tail = _head;
        }

        private MyLinkedList(IEnumerable<T> data)
        {
            Count = data.Count();

            if (data.Count() > 0)
            {
                _head = new Node<T>(data.First());
                _tail = _head;

                for (int i = 1; i < data.Count(); i++)
                {
                    _tail.Next = new Node<T>(data.ElementAt(i));
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
                Node<T> item = new Node<T>(data);

                if (index != 0)
                {
                    Node<T> current = _head;

                    for (int i = 1; i <= index; i++)
                    {
                        if (i == index)
                        {
                            item.Next = current.Next;
                            current.Next = item;
                        }

                        current = current.Next;

                        if (current.Next == null)
                        {
                            _tail = current.Next;
                        }
                    }
                }
                else
                {
                    item.Next = _head;
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
            AddRangeByIndex(index: Count, collection);
        }

        public void AddRangeByIndex(int index, T[] collection)
        {
            if (index >= 0 && index <= Count && !(collection is null))
            {
                var temp = default(Node<T>);
                Node<T> current = _head;

                if (index != 0)
                {
                    int j = 0;
                    int length = index + collection.Length;

                    for (int i = 1; i < length; i++)
                    {
                        if (i >= index)
                        {
                            if (i == index)
                            {
                                temp = current.Next;
                            }
                            current.Next = current.Next = new Node<T>(collection[j++]);
                        }
                        current = current.Next;
                    }
                    current.Next = temp;

                    if (temp == null)
                    {
                        _tail = current;
                    }
                }
                else
                {
                    temp = _head;
                    _head = new Node<T>(collection[0]);
                    current = _head;

                    for (int i = 1; i < collection.Length; i++)
                    {
                        current.Next = new Node<T>(collection[i]);
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
                    data = RemoveStart();
                }
                else
                {
                    Node<T> current = _head;

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

                            break;
                        }

                        current = current.Next;
                    }

                    --Count;
                }

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
            if (!(_head is null))
            {
                T data = _head.Data;

                if (Count == 1)
                {
                    _head = null;
                    _tail = null;
                }
                else
                {
                    _head = _head.Next;
                }

                --Count;

                return data;
            }

            throw new NullReferenceException("List is empty!");
        }

        public T Remove()
        {
            return RemoveByIndex(Count - 1);
        }

        public void RemoveRangeByIndex(int index, int quantity)
        {
            if (IsValidIndex(index) && !(_head is null) && quantity <= Count - index)
            {
                Node<T> current = _head;
                Node<T> item = default;
                int indexLastDeletItem = index + quantity;

                if (index == 0)
                {
                    for (int i = 0; i < quantity; i++)
                    {
                        current = current.Next;
                    }

                    _head = current;
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
            RemoveRangeByIndex(index: 0, quantity: quantity);
        }

        public void RemoveRange(int quantity)
        {
            Node<T> current = _head;

            if (quantity < Count)
            {
                Count -= quantity;
            }
            else
            {
                _head = null;
                Count = 0;
            }
            for (int i = 0; i < Count - 1; i++)
            {
                current = current.Next;
            }

            current.Next = null;
        }

        public int RemoveByValueFirst(T data)
        {
            int index = -1;
            Node<T> current = _head;

            for (int i = 0; i < Count; i++)
            {
                if (current.Data.CompareTo(data) == 0)
                {
                    RemoveByIndex(i);
                    index = i;
                    break;
                }

                current = current.Next;
            }

            return index;
        }

        public int RemoveByValueAll(T data)
        {
            int counter = 0;
            Node<T> current = _head;

            for (int i = 0; i < Count; i++)
            {
                if (current.Data.CompareTo(data) == 0)
                {
                    RemoveByIndex(i);
                    ++counter;
                    --i;
                }

                current = current.Next;
            }

            return counter;
        }

        public int FindIndexByValue(T data)
        {
            int index = -1;
            Node<T> current = _head;

            for (int i = 0; i < Count; i++)
            {
                if (current.Data.CompareTo(data) == 0)
                {
                    index = i;
                    break;
                }

                current = current.Next;
            }

            return index;
        }

        public int GetMaxIndex()
        {
            if (!(_head is null))
            {
                Node<T> current = _head;
                T dataMax = _head.Data;
                int index = 0;

                for (int i = 1; i < Count; i++)
                {
                    if (dataMax.CompareTo(current.Next.Data) == -1)
                    {
                        index = i;
                        dataMax = current.Next.Data;
                    }

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
                Node<T> current = _head;
                T dataMax = _head.Data;

                for (int i = 1; i < Count; i++)
                {
                    if (dataMax.CompareTo(current.Next.Data) == -1)
                    {
                        dataMax = current.Next.Data;
                    }
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
                Node<T> current = _head;
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
                Node<T> current = _head;
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

        public void Sort(bool isAscending = true)
        {
            Node<T> sorted = null;
            Node<T> current = _head;
            int coefficient = isAscending ? -1 : 1;

            while (current != null)
            {
                Node<T> next = current.Next;

                sorted = InstertionSort(current, sorted, coefficient);
                current = next;
            }

            _head = sorted;
        }

        public void Reverse()
        {
            if (!(_head is null))
            {
                Node<T> current = _head;
                Node<T> previos = null;
                Node<T> next;

                do
                {
                    next = current.Next;
                    current.Next = previos;
                    previos = current;
                    current = next;
                }
                while (!(current is null));

                _head = previos;
            }
        }

        public void HalfReverse()
        {
            if (!(_head is null))
            {
                Node<T> current = _head;
                Node<T> temp = _head;
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

                        current = current.Next;
                    }

                    current.Next = null;
                }
                else
                {
                    Node<T> item = default;

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

                        current = current.Next;
                    }

                    current.Next = null;
                }
            }
        }

        public override string ToString()
        {
            if (Count != 0)
            {
                Node<T> current = _head;
                StringBuilder stringBuilder = new StringBuilder($"{current.Data} ");

                while (!(current.Next is null))
                {
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

        private Node<T> InstertionSort(Node<T> newnode, Node<T> sorted, int coefficient)
        {
            if (sorted == null || sorted.Data.CompareTo(newnode.Data) != coefficient)
            {
                newnode.Next = sorted;
                sorted = newnode;
            }
            else
            {
                Node<T> current = sorted;

                while (current.Next != null
                        && current.Next.Data.CompareTo(newnode.Data) == coefficient)
                {
                    current = current.Next;
                }

                newnode.Next = current.Next;
                current.Next = newnode;
            }

            return sorted;
        }

        private bool IsValidIndex(int index)
        {
            return index >= 0 && index < Count;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}