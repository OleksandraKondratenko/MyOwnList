using System;
using System.Collections.Generic;


namespace MyOwnList
{
     public interface IList<T>
    {
        void Clear();
        string ToString();
        T[] ToArray();
        void AddStart(T value);
        void Add(T value);
        void AddByIndex(int index, T value);
        T RemoveByIndex(int index);
        T RemoveStart();
        T Remove();
        int RemoveByValueFirst(T value);
        int RemoveByValueAll(T value);
        int FindIndexByValue(T value);
        int GetMaxIndex();
        T GetMax();
        int GetMinIndex();
        T GetMin();
        void Sort( bool isAscending);
        void Reverse();
        void HalfReverse();
    }
}
