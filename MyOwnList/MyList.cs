using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyOwnList
{
    public class MyList<T> : IList<T>, IEnumerable<T> where T : IComparable
    {
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
                if (index < Length)
                {
                    return _array[index];
                }

                throw new IndexOutOfRangeException("Invalid index");
            }
            set
            {

                if (!IsValidCapacity(index))

                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                _array[index] = value;
            }
        }

        private T[] _array;

        public MyList()
        {
            Length = 0;
            _array = new T[8];
        }

        public MyList(T val)
        {
            Length = 0;
            _array = new T[8];
            Add(val);
        }

        public MyList(MyList<T> collection)
        {
            Length = 0;
            _array = new T[8];
            AddRange(collection);
        }

        public void Add(T item)
        {
            if (!IsValidCapacity(Length))
            {
                Resize();
            }

            _array[Length] = item;
            ++Length;
        }

        public void Clear()
        {
            Length = 0;
            _array = new T[8];
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                stringBuilder.Append(_array[i]).Append(" ");
            }

            return stringBuilder.ToString().Trim();
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

        public void AddByIndex(int index, T value)
        {
            ++Length;
            if (IsValidLength(index))
            {
                Resize();

                for (int i = Length - 1; i > index; i--)
                {
                    Swap(ref _array[i], ref _array[i - 1]);
                }

                _array[index] = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void AddStart(T value)
        {
            int index = 0;
            AddByIndex(index, value);
        }

        public void AddRangeByIndex(int index, MyList<T> collection)
        {
            int count = collection.Count();

            Length += count;

            if (IsValidLength(index))
            {
                Resize();

                for (int i = Length - 1; i > index; i--)
                {
                    if (i >= count)
                    {
                        _array[i] = _array[i - count];
                    }
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

        public void AddRangeStartPos(MyList<T> collection)
        {
            int index = 0;
            AddRangeByIndex(index, collection);
        }

        public void AddRange(MyList<T> collection)
        {
            AddRangeByIndex(Length, collection);
        }

        public T RemoveByIndex(int index)
        {
            if (IsValidLength(index))
            {
                T value = _array[index];
                --Length;

                for (int i = index; i < Length; i++)
                {
                    _array[i] = _array[i + 1];
                }

                Resize();

                return value;
            }

            throw new ArgumentOutOfRangeException("Invalid position!");
        }

        public T RemoveStart()
        {
            int index = 0;

            return RemoveByIndex(index);
        }

        public T Remove()
        {
            if (Length != 0)
            {
                T item = _array[Length - 1];

                --Length;
                Resize();

                return item;
            }

            throw new InvalidOperationException("MyList is empty");
        }



        public void RemoveRangeByIndex(int index, int quantity)
        {
            if (quantity <= Length - index && IsValidLength(index))
            {
                for (int i = index; i <= Length - index; i++)
                {
                    if (i + quantity < Length)
                    {
                        _array[i] = _array[i + quantity];
                    }
                }

                Length -= quantity;

                Resize();
            }
            else if (!IsValidLength(index))
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
            int index = 0;

            RemoveRangeByIndex(index, quantity);
        }

        public void RemoveRange(int quantity)
        {
            Length = (quantity < Length) ? Length - quantity : 0;

            Resize();
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

        public int RemoveByValueAll(T value)
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

        public int GetMinIndex()
        {
            if (Length != 0)
            {
                int minIndex = 0;

                for (int i = 1; i < Length ; i++)
                {
                    if (_array[minIndex].CompareTo(_array[i]) == 1)
                    {
                        minIndex = i;
                    }
                }

                return minIndex;
            }
            throw new InvalidOperationException();
            
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

            throw new InvalidOperationException();
        }

        public T GetMax()
        {
            return _array[GetMaxIndex()];
        }

        public T GetMin()
        {
            return _array[GetMinIndex()];
        }

        public void Set(int pos, T value)
        {
            if (IsValidLength(pos))
            {
                _array[pos] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid position!");
            }
        }

        public T Get(int index)
        {
            if (IsValidLength(index))
            {
                return _array[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid position!");
            }
        }

        public void SortAscending()
        {
            T current;
            int index;

            for (int i = 1; i < Length; i++)
            {
                current = _array[i];
                index = i;

                while (index > 0 && _array[index - 1].CompareTo(current) == 1)
                {
                    Swap(ref _array[index - 1], ref _array[index]);
                    --index;
                }
            }
        }

        public void SortDescending()
        {
            T current;
            int index;

            for (int i = 1; i < Length; i++)
            {
                current = _array[i];
                index = i;

                while (index > 0 && _array[index - 1].CompareTo(current) == -1)
                {
                    Swap(ref _array[index - 1], ref _array[index]);
                    --index;
                }
            }
        }

        public void Reverse()
        {
            for (int i = 0; i <= Length / 2 - 1; i++)
            {
                Swap(ref _array[i], ref _array[Length - i - 1]);
            }
        }

        public void HalfReverse()
        {
            int k = Length / 2 + Length % 2;

            for (int i = 0; i < Length / 2; i++)
            {
                Swap(ref _array[i], ref _array[k + i]);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is MyList<T> list &&
                   EqualityComparer<T[]>.Default.Equals(_array, list._array) &&
                   Capacity == list.Capacity &&
                   Length == list.Length;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_array, Capacity, Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        private void Resize()
        {
            T[] temp = _array;

            while (Length >= Capacity)
            {
                array = new T[Length];

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

        private bool IsValidCapacity(int index)
        {
            return index >= 0 && index < _array.Length;
        }

        private bool IsValidLength(int index)
        {
                return index >= 0 && index <= Length - 1;
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
