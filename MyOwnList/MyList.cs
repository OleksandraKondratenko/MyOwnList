using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MyOwnList
{
    public class MyList<T>: MyOwnList.IList<T>, IEnumerable<T> where T : IComparable
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
                ResizeUp();
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

        public void AddPos(int pos, T val)
        {
            ++Count;
            if ( IsValidCount(pos) )
            {
                for (int i = Count - 1; i > pos; i--)
                {
                    if (i != (Capacity - 1))
                    {
                        array[i] = array[i - 1];
                    }
                    else
                    {
                        ResizeUp();
                        i--;
                    }
                }
                array[pos] = val;
            }
        }

        public void AddStart(T val)
        {
            AddPos(0, val);
        }

        public void AddEnd(T val)
        {
            Add(val);
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
            Array.Sort(array);
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

        private void ResizeUp()
        {
            array = new T[(int)(Capacity * 1.3 + 1)];
        }

        private bool IsValidCapacity(int index)
        {
            return index >= 0 && index < array.Length;
        }

        private bool IsValidCount(int index)
        {
            return index >= 0 && index < Count+1;
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
    }
}
