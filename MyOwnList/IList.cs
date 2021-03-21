using System;
using System.Collections.Generic;


namespace MyOwnList
{
     public interface IList<T>
    {
        void Clear();
        String ToString();
        T[] ToArray();
        void AddStart(T val);
        void AddByIndex(int pos, T val);
        T RemoveByIndex(int pos);
        T RemoveStart();
        T Remove();
        int GetMaxIndex();
        T GetMax();
        int GetMinIndex();
        T GetMin();
        void Sort( bool isAscending);
        void Reverse();
        void HalfReverse();
    }
}
