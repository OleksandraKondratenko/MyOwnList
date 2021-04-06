using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lists
{
    public class MyList<T> : IList<T>, IEnumerable<T> where T : IComparable
    {
        private T[] _array;

        private const int _initializeIndex = 8;

        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }

        public int Count { get; set; }

        public T this[int index]
        {
            get
            {
                if (CheckIndexWithingLengthValue(index))
                {
                    return _array[index];
                }

                throw new IndexOutOfRangeException("Invalid index");
            }
            set
            {
                if (!CheckIndexWithingLengthValue(index))
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                _array[index] = value;
            }
        }

        public static MyList<T> Create(T[] collection)
        {
            if (collection != null)
            {
                return new MyList<T>(collection);
            }

            throw new ArgumentNullException();
        }

        public static MyList<T> Create(MyList<T> collection)
        {
            if (collection != null)
            {
                return new MyList<T>(collection);
            }

            throw new ArgumentNullException();
        }

        public MyList()
        {
            Count = 0;
            _array = new T[_initializeIndex];
        }

        public MyList(T val)
        {
            Count = 0;
            _array = new T[_initializeIndex];
            Add(val);
        }

        private MyList(MyList<T> collection)
        {
            Count = 0;
            _array = new T[_initializeIndex];
            AddRange(collection);
        }

        private MyList(T[] collection)
        {
            Count = 0;
            _array = new T[_initializeIndex];
            AddRange(collection);
        }

        public void Add(T item)
        {
            if (!CheckIndexWithingCapacityValue(Count))
            {
                Resize();
            }

            _array[Count++] = item;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void AddByIndex(int index, T value)
        {
            ++Count;

            if (CheckIndexWithingLengthValue(index))
            {
                Resize();

                for (int i = Count - 1; i > index; i--)
                {
                     _array[i]= _array[i - 1];
                }

                _array[index] = value;

                return;
            }

            throw new IndexOutOfRangeException();
        }

        public void AddStart(T value)
        {
            AddByIndex(index: 0, value: value);
        }

        public void AddRangeByIndex(int index, MyList<T> collection)
        {
            int count = collection.Count();

            Count += count;

            if (CheckIndexWithingLengthValue(index))
            {
                Resize();

                for (int i = Count - 1; i > index && i >= count; i--)
                {
                    _array[i] = _array[i - count];
                }

                foreach (var item in collection)
                {
                    _array[index++] = item;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddRangeByIndex(int index, T[] collection)
        {
            if (collection != null)
            {
                int count = collection.Length;

                Count += count;

                if (CheckIndexWithingLengthValue(index))
                {
                    Resize();

                    for (int i = Count - 1; i > index && i >= count; i--)
                    {
                        _array[i] = _array[i - count];
                    }

                    foreach (var item in collection)
                    {
                        _array[index++] = item;
                    }
                }
                else if (Count != 0)
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void AddRangeStart(MyList<T> collection)
        {
            AddRangeByIndex(index: 0, collection);
        }

        public void AddRangeStart(T[] collection)
        {
            AddRangeByIndex(index: 0, collection);
        }

        public void AddRange(MyList<T> collection)
        {
            AddRangeByIndex(Count, collection);
        }

        public void AddRange(T[] collection)
        {
            AddRangeByIndex(Count, collection);
        }

        public T RemoveByIndex(int index)
        {
            if (CheckIndexWithingLengthValue(index))
            {
                T value = _array[index];

                --Count;

                for (int i = index; i < Count; i++)
                {
                    _array[i] = _array[i + 1];
                }

                Resize();

                return value;
            }

            throw new IndexOutOfRangeException("Invalid position!");
        }

        public T RemoveStart()
        {
            if (CheckIndexWithingLengthValue(index: 0))
            {
                return RemoveByIndex(index: 0);
            }

            throw new NullReferenceException();
        }

        public T Remove()
        {
            if (Count != 0)
            {
                T item = _array[Count - 1];

                --Count;
                Resize();

                return item;
            }

            throw new NullReferenceException("MyList is empty");
        }

        public void RemoveRangeByIndex(int index, int quantity)
        {
            if (quantity <= Count - index && CheckIndexWithingLengthValue(index))
            {
                for (int i = index; i <= Count - index; i++)
                {
                    if (i + quantity < Count)
                    {
                        _array[i] = _array[i + quantity];
                    }
                }

                Count -= quantity;

                Resize();
            }
            else if (Count == 0)
            {
                throw new NullReferenceException();
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid quantity");
            }
        }

        public void RemoveRangeStart(int quantity)
        {
            RemoveRangeByIndex(index: 0, quantity);
        }

        public void RemoveRange(int quantity)
        {
            Count = (quantity < Count) ? Count - quantity : 0;

            Resize();
        }

        public int RemoveByValueFirst(T value)
        {
            int resultIndex = -1;

            for (int i = 0; i < Count; i++)
            {
                if (_array[i].CompareTo(value) == 0)
                {
                    RemoveByIndex(i);
                    resultIndex = i;
                    break;
                }
            }

            return resultIndex;
        }

        public int RemoveByValueAll(T value)
        {
            int counter = 0;

            for (int i = 0; i < Count; i++)
            {
                if (_array[i].CompareTo(value) == 0)
                {
                    for (int j = i; j < Count; j++)
                    {
                        _array[j] = _array[j + 1];
                    }

                    --i;
                    --Count;
                    ++counter;
                }
            }

            Resize();

            return counter;
        }

        public int FindIndexByValue(T value)
        {
            int index = -1;

            for (int i = 0; i < Count; i++)
            {
                if (_array[i].CompareTo(value) == 0)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public int GetMinIndex()
        {
            if (Count != 0)
            {
                int minIndex = 0;

                for (int i = 1; i < Count; i++)
                {
                    if (_array[minIndex].CompareTo(_array[i]) == 1)
                    {
                        minIndex = i;
                    }
                }

                return minIndex;
            }
            else if (_array.Equals(null))
            {
                throw new NullReferenceException();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public int GetMaxIndex()
        {
            if (Count != 0)
            {
                int maxIndex = 0;

                for (int i = 1; i < _array.Length - 1; i++)
                {
                    if (_array[maxIndex].CompareTo(_array[i]) == -1)
                    {
                        maxIndex = i;
                    }
                }

                return maxIndex;
            }
            else if (_array.Equals(null))
            {
                throw new NullReferenceException();
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        public T GetMax()
        {
            return _array[GetMaxIndex()];
        }

        public T GetMin()
        {
            return _array[GetMinIndex()];
        }

        public void Sort(bool isAscending = true)
        {
            T current;
            int index;
            int coeficient = isAscending ? 1 : -1;

            for (int i = 1; i < Count; i++)
            {
                current = _array[i];
                index = i;

                while (index > 0 && _array[index - 1].CompareTo(current) == coeficient)
                {
                    Swap(ref _array[index - 1], ref _array[index]);
                    --index;
                }
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < Count / 2; i++)
            {
                Swap(ref _array[i], ref _array[Count - i - 1]);
            }
        }

        public void HalfReverse()
        {
            if (_array != null)
            {
                int coefficient = Count / 2 + Count % 2;

                for (int i = 0; i < Count / 2; i++)
                {
                    Swap(ref _array[i], ref _array[coefficient + i]);
                }
            }
            else
            {
                throw new NullReferenceException("Array is null");
            }
        }

        public T[] ToArray()
        {
            T[] arrayNew = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                arrayNew[i] = _array[i];
            }

            return arrayNew;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                stringBuilder.Append($"{_array[i]} ");
            }

            return stringBuilder.ToString().Trim();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }

        private void Resize()//
        {
            T[] temp = new T[(int)(Count * 1.3 + 1)];

            int tempLength = Count < Capacity ? Count : Capacity;

            for (int i = 0; i < tempLength; i++)
            {
                temp[i] = _array[i];
            }

            _array = temp;
        }

        private bool CheckIndexWithingCapacityValue(int index)
        {
            return index >= 0 && index < _array.Length;
        }

        private bool CheckIndexWithingLengthValue(int index)
        {
            return index >= 0 && index < Count;
        }

        private void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _array[i];
            }
        }
    }
}
