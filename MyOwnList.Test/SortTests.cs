using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test
{
    public class Tests
    {
        [TestCaseSource(nameof(DataSortTest))]
        public void Sort_WhenCollectionIsUnsorted_ShouldSortCollection(
           MyList<int> result, MyList<int> expected)
        {
            result.SortAscending();

            CollectionAssert.AreEqual(expected, result);
        }
        private static IEnumerable<object[]> DataSortTest()
        {
            yield return new object[] { new MyList<int>() { 6,7,2,1,5,3,4,10,8,9 },
                new MyList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } };
        }

        [TestCaseSource(nameof(DataSortDescTest))]
        public void SortDesc_WhenCollectionIsUnsorted_ShouldSortCollection(
            MyList<int> result, MyList<int> expected)
        {
            result.SortDescending();

            CollectionAssert.AreEqual(expected, result);
        }
        private static IEnumerable<object[]> DataSortDescTest()
        {
            yield return new object[] { new MyList<int>() { 6,7,2,1,5,3,4,10,8,9 },
                new MyList<int>() { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 } };
        }
    }
}