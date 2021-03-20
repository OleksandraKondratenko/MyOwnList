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
        void Set(int index, T value);
        T Get(int value);
        void SortAscending();
        void SortDescending();
        void Reverse();
        void HalfReverse();
    }
}
