using System;

namespace MyOwnList
{
    public class List<T>
    {
        private T[] array;
        
        public List()
        {
           array = new T[0];
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
        private bool IsValid(int index)
        {
            return index >= 0 && index < array.Length;
        }
    }
}
