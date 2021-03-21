using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyOwnList
{
    public class MyList<T> : IList<T>, IEnumerable<T> where T : IComparable
    {
        private T[] _array;
        private readonly int _initializeIndex=8;
        public int Capacity
        {
            get
            {
                return _array.Length;
            }
        }

        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                if (CheckIndexWithingCapacityValue(index))
                {
                    return _array[index];
                }

                throw new IndexOutOfRangeException("Invalid index");
            }
            set
            {

                if (!CheckIndexWithingCapacityValue(index))

                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                _array[index] = value;
            }
        }

        public MyList()
        {
            InitializeArray();
        }

        public MyList(T val)
        {
            InitializeArray();
            Add(val);
        }

        public MyList(MyList<T> collection)
        {
            InitializeArray();
            AddRange(collection);
        } 

        public MyList(T [] collection)
        {
            InitializeArray();
            AddRange(collection);
        }

        public void Add(T item)
        {
            if (!CheckIndexWithingCapacityValue(Length))
            {
                Resize(1);
            }

            _array[Length++] = item;
        }

        public void Clear()
        {
            InitializeArray();
        }

        public void AddByIndex(int index, T value)
        {
            ++Length;

            if (CheckIndexWithingLenthValue(index))
            {
                Resize(1);

                for (int i = Length - 1; i > index; i--)
                {
                    Swap(ref _array[i], ref _array[i - 1]);
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

            Length += count;

            if (CheckIndexWithingLenthValue(index))
            {
                Resize(1);

                for (int i = Length - 1; i > index && i >= count; i--)
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

        public void AddRangeByIndex(int index, T [] collection)
        {
            int count = collection.Count();

            Length += count;

            if (CheckIndexWithingLenthValue(index))
            {
                Resize(1);

                for (int i = Length - 1; i > index && i >= count; i--)
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
        public void AddRangeStart(MyList<T> collection)
        {
            AddRangeByIndex(index:0, collection);
        }

        public void AddRangeStart(T [] collection)
        {
            AddRangeByIndex(index:0, collection);
        }

        public void AddRange(MyList<T> collection)
        {
            AddRangeByIndex(Length, collection);
        }

        public void AddRange(T[] collection)
        {
            AddRangeByIndex(Length, collection);
        }

        public T RemoveByIndex(int index)
        {
            if (CheckIndexWithingLenthValue(index))
            {
                T value = _array[index];
                --Length;

                for (int i = index; i < Length; i++)
                {
                    _array[i] = _array[i + 1];
                }

                Resize(-1);

                return value;
            }

            throw new ArgumentOutOfRangeException("Invalid position!");
        }

        public T RemoveStart()
        {
            return RemoveByIndex(index: 0);
        }

        public T Remove()
        {
            if (Length != 0)
            {
                T item = _array[Length - 1];

                --Length;
                Resize(-1);

                return item;
            }

            throw new InvalidOperationException("MyList is empty");
        }

        public void RemoveRangeByIndex(int index, int quantity)
        {
            if (quantity <= Length - index && CheckIndexWithingLenthValue(index))
            {
                for (int i = index; i <= Length - index; i++)
                {
                    if (i + quantity < Length)
                    {
                        _array[i] = _array[i + quantity];
                    }
                }

                Length -= quantity;

                Resize(-1);
            }
            else if (!CheckIndexWithingLenthValue(index))
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            else
            {
                throw new InvalidOperationException("Invalid quantity");
            }
        }

        public void RemoveRangeStart(int quantity)
        {
            RemoveRangeByIndex(index:0, quantity);
        }

        public void RemoveRange(int quantity)
        {
            Length = (quantity < Length) ? Length - quantity : 0;

            Resize(-1);
        }

        public int RemoveByValueFirst(T value)
        {
            int resultIndex = -1;

            for (int i = 0; i < Length; i++)
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

        public int RemoveByValueAll(T value)//
        {
            int counter = 0;

            for (int i = 0; i < Length; i++)
            {
                if (_array[i].CompareTo(value) == 0)
                {
                    RemoveByIndex(i);
                    ++counter;
                }
            }

            return counter;
        }

        public int FindIndexByValue(T value)
        {
            int index = -1;

            for (int i = 0; i < Length; i++)
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
            if (Length != 0)
            {
                int minIndex = 0;

                for (int i = 1; i < Length; i++)
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
            if (Length != 0)
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
            for (int i = 1; i < Length; i++)
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
            for (int i = 0; i < Length / 2 ; i++)
            {
                Swap(ref _array[i], ref _array[Length - i - 1]);
            }
        }

        public void HalfReverse()
        {
            if (_array != null)
            {
                int k = Length / 2 + Length % 2;

                for (int i = 0; i < Length / 2; i++)
                {
                    Swap(ref _array[i], ref _array[k + i]);
                }
            }
            else
            {
                throw new NullReferenceException("Array is null");
            }
        }

        public T[] ToArray()
        {
            T[] arrayNew = new T[Length];

            for (int i = 0; i < Length; i++)
            {
                arrayNew[i] = _array[i];
            }

            return arrayNew;
        }
       
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                stringBuilder.Append($"{_array[i]} ");
            }

            return stringBuilder.ToString().Trim();
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        private void Resize( int coefficient)
        {
            T[] temp = _array;

           // _array = new T[(int)(Capacity*(1 +0.33 * coefficient )+1)];
            while (Length >= Capacity)
            {
                _array = new T[(int)(Capacity * 1.3 + 1)];

                for (int i = 0; i < temp.Length; i++)
                {
                    _array[i] = temp[i];
                }
            }

            while (Capacity > Length * 1.33 + 1)
            {
                _array = new T[(int)(Capacity * 0.7)];

                for (int i = 0; i < Length; i++)
                {
                    _array[i] = temp[i];
                }
            }
        }

        private bool CheckIndexWithingCapacityValue(int index)
        {
            return index >= 0 && index < _array.Length;
        }

        private bool CheckIndexWithingLenthValue(int index)
        {
            return index >= 0 && index < Length ;
        }

        private void InitializeArray()
        {
            Length = 0;
            _array = new T[_initializeIndex];
        }
        private void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }
    }
}
