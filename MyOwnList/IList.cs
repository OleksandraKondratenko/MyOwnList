using System;
using System.Collections.Generic;

namespace MyOwnList
{
     public interface IList<T> : IEnumerable<int>
    {
        
        int Size();
        void Clear();
        String ToString();
        T[] ToArray();
        void AddStart(int val);
        void AddEnd(int val);
        void AddPos(int pos, int val);
        T DelPos(int pos);
        T DelStart();
        T DelEnd();
        int MaxPos();
        T Max();
        int MinPos();
        T Min();
        void Set(int pos, int val);
        T Get(int pos);
        void Sort();
        void Reverse();
        void HalfReverse();
    }
}
