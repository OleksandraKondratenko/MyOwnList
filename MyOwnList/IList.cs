using System;
using System.Collections.Generic;

namespace MyOwnList
{
     public interface IList<T> : IEnumerable<int>
    {
        void Clear();
        String ToString();
        T[] ToArray();
        void AddStart(T val);
        void AddEnd(T val);
        void AddPos(int pos, T val);
        T DelPos(int pos);
        T DelStart();
        T DelEnd();
        int MaxPos();
        T Max();
        int MinPos();
        T Min();
        void Set(int pos, T val);
        T Get(int pos);
        void Sort();
        void Reverse();
        void HalfReverse();
    }
}
