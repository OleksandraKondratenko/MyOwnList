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
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }
        private bool IsValid()
        {
            if(array.Length>)
        }
    }
}
