using System;

namespace MyOwnList
{
    public class List<T>
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
                
            }
        }
        public int Count
        {
            get
            {
                return array.Length;
            }
            set
            {

            }
        }
        public List()
        {
            Count = 0;
            array = new T[8];
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public void Add(T item)
        {
            if(IsValid(Count))
        }
        



    }
}
