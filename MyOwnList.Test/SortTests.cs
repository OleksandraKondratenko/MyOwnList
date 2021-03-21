using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 },
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void Sort_WhenCollectionIsUnsorted_ShouldSortCollection(
           int[] result,int [] expected)
        {
            MyList<int> listExpected = new MyList<int>(expected);

            MyList<int> listResult = new MyList<int>(result);

            listResult.Sort(true);

            CollectionAssert.AreEqual(listExpected, listResult);
        }


        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 },
           new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        public void SortDesc_WhenCollectionIsUnsorted_ShouldSortCollection(
            int[] result,int [] expected)
        {
            MyList<int> listExpected = new MyList<int>(expected);

            MyList<int> listResult = new MyList<int>(result);

            listResult.Sort(false);

            CollectionAssert.AreEqual(listExpected, listResult);
        }
       
    }
}