using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MyOwnList
{
    public class MyList<@int>
    {
        private @int[] array;

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

        public @int this[int index]
        {
            get
            {
                if (!IsValidCapacity(index))
                {
                    throw new IndexOutOfRangeException("Invalid index");
                }

                return array[index];
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
            Count = 0;
            array = new @int[8];
        }

        public void Clear()
        {
            Count = 0;
            array = new @int[8];
        }
        
        public override string ToString()
        {
            return array.ToString();
        }

        public @int[] ToArray()
        {
            return array;
        }

        public void Add(@int item)
        {
            if (!IsValidCapacity(Count))
            {
                Resize();
            }

            array[Count] = item;
            ++Count;
        }

        //AddStart
        //AddEnd
        //AddPos

        public @int DelPos(int pos)
        {
            if (IsValidCount(pos))
            {
                @int value = array[pos];
                --Count;

                for (int i = pos; i < Count; i++)
                {
                    array[i] = array[i + 1];
                }

                return value;
            }

            throw new ArgumentOutOfRangeException("Invalid position!");
        }

        public @int DelStart()
        {
            return DelPos(0);
        }

        public @int DelEnd()
        {
            return DelPos(Count - 1);
        }

        //MaxPos
        //Max
        //MinPos
        //Min

        public void Set(int pos, @int value)
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

        public @int Get(int pos)
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

        private void Resize()
        {
            array = new @int[Capacity * 2];
        }

        private bool IsValidCapacity(int index)
        {
            return index >= 0 && index < Capacity;
        }

        private bool IsValidCount(int index)
        {
            return index >= 0 && index < Count;
        }

        private void Swap(ref @int a, ref @int b)
        {
            @int temp = a;
            a = b;
            b = temp;
        }
    }
}
