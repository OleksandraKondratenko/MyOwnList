using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            private set
            {
                value = array.Length;
            }
        }
        public int Count { get; private set; }


        public MyList()
        {
            Count = 0;
            array = new T[8];
        }
        public MyList(T val)
        {
            Count = 0;
            array = new T[8];
            Add(val);
        }
        public MyList(MyList<T> collection)
        {
            Count = 0;
            array = new T[8];
            AddRange(collection);
        }

        public T this[int index]
        {
            get
            {
                if (index < Count)
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

        public void Add(T item)
        {

            if (!IsValidCapacity(Count))
            {
                Resize();
            }

            array[Count] = item;
            ++Count;
        }

        public void Clear()
        {
            Count = 0;
            array = new T[8];
        }

        public override string ToString()
        {
            string s = "";

            for (int i = 0; i < Count; i++)
            {
                s += array[i];
            }
            return s;
        }

        public T[] ToArray()
        {
            T[] arrayNew = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                arrayNew[i] = array[i];
            }
            return arrayNew;
        }

        public void AddPos(int pos, T val)
        {
            if (IsValidCount(pos))
            {
                ++Count;
                if (Count >= Capacity)
                {
                    Resize();
                }
                for (int i = Count - 1; i > pos; i--)
                {

                    array[i] = array[i - 1];

                }
                array[pos] = val;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void AddStart(T val)
        {
            AddPos(0, val);
        }

        public T DelPos(int pos)
        {
            if (IsValidCount(pos))
            {
                T value = array[pos];
                --Count;

                for (int i = pos; i < Count; i++)
                {
                    array[i] = array[i + 1];
                }

                return value;
            }

            throw new ArgumentOutOfRangeException("Invalid position!");
        }

        public T DelStart()
        {
            return DelPos(0);
        }

        public T DelEnd()
        {
            return DelPos(Count - 1);
        }

        public void DelPosRange(int quanity)
        {

        }

        public void DelStartRange(int quantity)
        {

        }

        public void DelEndRange(int quantity)//Check equality to zero
        {
            Count = (quantity < Count) ? Count - quantity : 0;

            while (Capacity > (int)(Count * 1.33 + 1))
            {
                Resize();
            }
        }

        public int DelByValueFirst(T value)
        {
            int i;//

            for (i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    DelPos(i);
                    break;
                }
            }

            return i;
        }

        public int DelByValueAll(T value)
        {
            int counter = 0;

            for (int i = 0; i < Count; i++)
            {
                if (array[i].CompareTo(value) == 0)
                {
                    DelPos(i);
                    ++counter;
                }
            }

            return counter;
        }

        public int MinPos()
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

        public int MaxPos()
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

        public T Max()
        {
            return array[MaxPos()];
        }
        public T Min()
        {
            return array[MinPos()];
        }

        public void Set(int pos, T value)
        {
            if (IsValidCount(pos))
            {
                array[pos] = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid position!");
            }
        }

        public T Get(int pos)
        {
            if (IsValidCount(pos))
            {
                return array[pos];
            }
            else
            {
                throw new ArgumentOutOfRangeException("Invalid position!");
            }
        }

        public void Sort()
        {
            T current;
            int index;

            for (int i = 1; i < Count; i++)
            {
                current = array[i];
                index = i;
                while (index > 0 && array[index - 1].CompareTo(current)==1)
                {
                    Swap(ref array[index - 1], ref array[index]);
                    index--;
                }
            }
        }
        public void SortDescending()
        {
            T current;
            int index;

            for (int i = 1; i < Count; i++)
            {
                current = array[i];
                index = i;
                while (index > 0 && array[index - 1].CompareTo(current) == -1)
                {
                    Swap(ref array[index - 1], ref array[index]);
                    index--;
                }
            }
        }

        public void Reverse()
        {
            for (int i = 0; i <= Count / 2 - 1; i++)
            {
                Swap(ref array[i], ref array[Count - i - 1]);
            }
        }

        public void HalfReverse()
        {
            int k = Count / 2 + Count % 2;

            for (int i = 0; i < Count / 2; i++)
            {
                Swap(ref array[i], ref array[k + i]);
            }
        }

        public void AddRangeByIndex(int pos, MyList<T> collection)
        {
            int count = collection.Count();
            Count += count;
            if (IsValidCount(pos))
            {
                while (Count >= Capacity)
                {
                    Resize();
                }

                for (int i = Count - 1; i > pos; i--)
                {
                    if (i >= count)
                    {
                        array[i] = array[i - count];
                    }
                }

                foreach (var item in collection)
                {
                    array[pos] = item;
                    ++pos;
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
            AddRangeByIndex(Count, collection);
        }
        private void Resize()
        {
            T[] temp = array;
            while (Count >= Capacity)
            {
                array = new T[(int)(Capacity * 1.3 + 1)];
            }
            while (Capacity > Count * 1.33 + 1)
            {
                array= new T[(int)(Capacity * 0.7 + 1)];
            }
               // array = (Capacity <= Count) ? new T[(int)(Capacity * 1.3 + 1)] : new T[(int)(Capacity * 0.7+1)];

            for (int i = 0; i < temp.Length; i++)
            {
                array[i] = temp[i];
            }
        }

        private bool IsValidCapacity(int index)
        {
            return index >= 0 && index < array.Length;
        }

        private bool IsValidCount(int index)
        {
            return index >= 0 && index <= Count - 1;
        }

        private void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }

        public override bool Equals(object obj)
        {
            return obj is MyList<T> list &&
                   EqualityComparer<T[]>.Default.Equals(array, list.array) &&
                   Capacity == list.Capacity &&
                   Count == list.Count;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(array, Capacity, Count);
        }
    }
}
