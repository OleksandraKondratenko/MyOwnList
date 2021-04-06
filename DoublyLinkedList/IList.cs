using System;

namespace Lists
{
    public interface IList<T> where T : IComparable
    {
        public int Count { get; set; }
        T this[int index] { get; set; }
        void Clear();
        string ToString();
        T[] ToArray();
        void AddStart(T value);
        void Add(T value);
        void AddByIndex(int index, T value);
        void AddRangeStart(T[] collection);
        void AddRange(T[] collection);
        void AddRangeByIndex(int index, T[] collection);
        T RemoveByIndex(int index);
        T RemoveStart();
        T Remove();
        void RemoveRangeByIndex(int index, int quantity);
        void RemoveRangeStart(int quantity);
        void RemoveRange(int quantity);
        int RemoveByValueFirst(T value);
        int RemoveByValueAll(T value);
        int FindIndexByValue(T value);
        int GetMaxIndex();
        T GetMax();
        int GetMinIndex();
        T GetMin();
        void Sort(bool isAscending = true);
        void Reverse();
        void HalfReverse();
    }
}
