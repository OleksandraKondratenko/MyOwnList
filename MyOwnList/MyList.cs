using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyOwnList
{
    public class MyList<T> : IList<T>, IEnumerable<T> where T : IComparable
    {
        private T[] array;

        public int Capacity
        {
            get
            {
                return array.Length;
            }
        }
        public int Length { get; private set; }

        public T this[int index]
        {
            get
            {
                if (index < Length)
                {
                    return array[index];
                }

                throw new IndexOutOfRangeException("Invalid index");
            }
            set
            {

                if (!IsValidCapacity(index))

                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                array[index] = value;
            }
        }

        public MyList()
        {
            Length = 0;
            array = new T[8];
        }

        public MyList(T val)
        {
            Length = 0;
            array = new T[8];
            Add(val);
        }

        public MyList(MyList<T> collection)
        {
            Length = 0;
            array = new T[8];
            AddRange(collection);
        }

        public void Add(T item)
        {
            if (!IsValidCapacity(Length))
            {
                Resize();
            }

            array[Length] = item;
            ++Length;
        }

        public void Clear()
        {
            Length = 0;
            array = new T[8];
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < Length; i++)
            {
                stringBuilder.Append(array[i]);
            }

            return stringBuilder.ToString();
        }

        public T[] ToArray()
        {
            T[] arrayNew = new T[Length];

            for (int i = 0; i < Length; i++)
            {
                arrayNew[i] = array[i];
            }

            return arrayNew;
        }

        public void AddByIndex(int index, T value)
        {
            if (IsValidLength(index))
            {
                ++Length;

                if (Length >= Capacity)
                {
                    Resize();
                }

                for (int i = Length - 1; i > index; i--)
                {
                    Swap(ref array[i], ref array[i - 1]);
                }

                array[index] = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddStart(T value)
        {
            AddByIndex(0, value);
        }

        public void AddRangeByIndex(int index, MyList<T> collection)
        {
            int count = collection.Count();
            Length += count;

            if (IsValidLength(index))
            {
                while (Length >= Capacity)
                {
                    Resize();
                }

                for (int i = Length - 1; i > index; i--)
                {
                    if (i >= count)
                    {
                        Swap(ref array[i], ref array[i - count]);
                    }
                }

                foreach (var item in collection)
                {
                    array[index++] = item;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddRangeStartPos(MyList<T> collection)
        {
            AddRangeByIndex(0, collection);
        }

        public void AddRange(MyList<T> collection)
        {
            AddRangeByIndex(Length, collection);
        }

        public T RemoveByIndex(int index)
        {
            if (IsValidLength(index))
            {
                T value = array[index];
                --Length;

                for (int i = index; i < Length; i++)
                {
                    Swap(ref array[i], ref array[i + 1]);
                }

                if (Capacity > Length * 1.33 + 1)
                {
                    Resize();
                }

                return value;
            }

            throw new ArgumentOutOfRangeException("Invalid position!");
        }

        public T RemoveStart()
        {
            return RemoveByIndex(0);
        }

        public T Remove()
        {
            if (Capacity > Length * 1.33 + 1)
            {
                Resize();
            }

            if (Length > 0)
            {
                return RemoveByIndex(Length - 1);
            }

            throw new InvalidOperationException("MyList is empty");
        }

        public void RemoveRangeByIndex(int index, int quantity)
        {
            if (quantity <= Length - index && IsValidLength(index))
            {
                for (int i = index; i < Length - index; i++)
                {
                    array[i] = array[i + quantity];
                }

                Length -= quantity;

                while (Capacity > Length * 1.33 + 1)
                {
                    Resize();
                }
            }
            else
            {
                throw new InvalidOperationException();
            }

        }

        public void RemoveRangeStart(int quantity)
        {
            RemoveRangeByIndex(0, quantity);
        }

        public void RemoveRange(int quantity)//Check equality to zero
        {
            Length = (quantity < Length) ? Length - quantity : 0;

            while (Capacity > (int)(Length * 1.33 + 1))
            {
                Resize();
            }
        }

        public int RemoveByValueFirst(T value)
        {
            int resultIndex = -1;

            for (int i = 0; i < Length; i++)
            {
                if (array[i].CompareTo(value) == 0)
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
                if (array[i].CompareTo(value) == 0)
                {
                    RemoveByIndex(i);
                    ++counter;
                }
            }

            return counter;
        }

        public int GetMinIndex()
        {
            int minIndex = 0;

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[minIndex].CompareTo(array[i]) == 1)
                {
                    minIndex = i;
                }
            }

            return minIndex;
        }

        public int GetMaxIndex()
        {
            int maxIndex = 0;

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[maxIndex].CompareTo(array[i]) == -1)
                {
                    maxIndex = i;
                }
            }

            return maxIndex;
        }

        public T GetMax()
        {
            return array[GetMaxIndex()];
        }

        public T GetMin()
        {
            return array[GetMinIndex()];
        }

        public void Set(int pos, T value)
        {
            if (IsValidLength(pos))
            {
                array[pos] = value;
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
                return array[index];
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
                current = array[i];
                index = i;

                while (index > 0 && array[index - 1].CompareTo(current) == 1)
                {
                    Swap(ref array[index - 1], ref array[index]);
                    --index;
                }
            }
        }

        public void SortDescending()
        {
            SortAscending();
            Reverse();
        }

        public void Reverse()
        {
            for (int i = 0; i <= Length / 2 - 1; i++)
            {
                Swap(ref array[i], ref array[Length - i - 1]);
            }
        }

        public void HalfReverse()
        {
            int k = Length / 2 + Length % 2;

            for (int i = 0; i < Length / 2; i++)
            {
                Swap(ref array[i], ref array[k + i]);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is MyList<T> list &&
                   EqualityComparer<T[]>.Default.Equals(array, list.array) &&
                   Capacity == list.Capacity &&
                   Length == list.Length;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(array, Capacity, Length);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return array[i];
            }
        }

        private void Resize()
        {
            T[] temp = array;

            //while (Length >= Capacity)
            //{
            //    array = new T[(int)(Capacity * 1.3 + 1)];
            //}

            //while (Capacity > Length * 1.33 + 1)
            //{
            //    array = new T[(int)(Capacity * 0.7 + 1)];
            //}

            array = (Capacity <= Length) ? new T[(int)(Capacity * 1.3 + 1)] : new T[(int)(Capacity * 0.7 + 1)];

            for (int i = 0; i < temp.Length; i++)
            {
                array[i] = temp[i];
            }
        }

        private bool IsValidCapacity(int index)
        {
            return index >= 0 && index < array.Length;
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
                yield return array[i];
            }
        }
    }
}
