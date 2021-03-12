using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace MyOwnList
{
    public class MyList<T> : IComparable<T>
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

        public object Current => throw new NotImplementedException();

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

        public T Min()
        {
            if (Count == 0)
            {
                throw new IndexOutOfRangeException("List is empty");
            }

            T min = array[0];

            for (int i = 0; i < Count; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        private void Resize()
        {
            array = new T[Capacity * 2];
        }

        private bool IsValid(int index)
        {
            return index >= 0 && index < array.Length;
        }

        public int CompareTo(T other)
        {
            T item = other is T;
            if()
        }

        //private 
    }
}
