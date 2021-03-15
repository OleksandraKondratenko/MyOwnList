using System;
using System.Collections.Generic;

namespace Lists
{
     public interface IList : IEnumerable<int>
    {
        void Init(int[] ini);
        int Size();
        void Clear();
        String ToString();
        int[] ToArray();
        void AddStart(int val);
        void AddEnd(int val);
        void AddPos(int pos, int val);
        int DelPos(int pos);
        int DelStart();
        int DelEnd();
        int MaxPos();
        int Max();
        int MinPos();
        int Min();
        void Set(int pos, int val);
        int Get(int pos);
        void Sort();
        void Reverse();
        void HalfReverse();
    }
}
