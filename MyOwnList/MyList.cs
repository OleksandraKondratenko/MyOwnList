using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MyOwnList
{
    public class MyList<T>: MyOwnList.IList<T> where T : IComparable
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

        public T this[int index]
        {
            get
            {
                if (!IsValid(index))
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                return array[index];
            }
            set
            {
                if (!IsValid(index))
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                array[index] = value;
            }
        }

        public void Add(T item)
        {
            if (!IsValid(Count))
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
            return array.ToString();
        }

        public T[] ToArray()
        {
            return array;
        }

        private void Resize()
        {
            array = new T[Capacity * 2];
        }

        private bool IsValid(int index)
        {
            return index >= 0 && index < array.Length;
        }

        public void AddPos(int pos, T val)
        {
            T temp;

                for (int i = pos; i < Count; i++)
                {
                    if (i != (Capacity - 1))
                    {
                        temp = array[pos];
                        array[pos] = val;
                        val = array[pos + 1];
                        ++pos;
                        array[pos] = temp;
                        ++pos;

                    }
                    else
                    {
                        Resize();
                        i--;
                    }
                }

            ++Count;
        }

        public void AddStart(T val)
        {
            AddPos(0, val);
        }

        public void AddEnd(T val)
        {
            Add(val);
        }

        public int MinPos()
        {
            int minIndex = 0;

            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[minIndex].CompareTo(array[i])==1)
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

        public void Set(int pos, int val)
        {
            throw new NotImplementedException();
        }

    }
}
