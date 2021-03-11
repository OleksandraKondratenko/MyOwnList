using System;

namespace MyOwnList
{
    public class List<T>
    {
        private T[] array;
        int a;
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
            if (IsValid(Count))
            {
                array[Count] = item;
                ++Count;
            }
            
            //TODO: Resize();
        }

        private bool IsValid(int index) => (index >= 0 && index < array.Length);



    }
}
