using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test.RemoveTests
{
    class RemoveRangeByIndexTest
    {
        [TestCaseSource(nameof(DataRemoveRangeByIndexValidTest))]
        public void RemoveRangeByIndex_WhenValidIndexPassed_ShouldRemoveRangeByIndex(
            int index, int quantity, MyList<int> inputList, MyList<int> expectedList)
        {
            inputList.RemoveRangeByIndex(index, quantity);

            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataRemoveRangeByIndexValidTest()
        {
            yield return new object[] { 4, 3, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { -2, 34, 5, 6, 65, -2, -17 } };

            yield return new object[] { 0, 7, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { 65, -2, -17 } };

            yield return new object[] { 6, 4, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { -2, 34, 5, 6, -2, 57} };

            yield return new object[] { 0, 10, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { } };
        }

        [TestCase(3, 100, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        public void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowInvalidOperationException(
            int index, int quantity, int[] inputList)
        {
            MyList<int> list = new MyList<int>();
            list.AddRange(inputList);

            Assert.Throws<InvalidOperationException>(() =>
                list.RemoveRangeByIndex(index, quantity));
        }

        private static IEnumerable<object[]> DataRemoveRangeByIndexWrongQuantityTest()
        {
            yield return new object[] { 3, 100, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };
            yield return new object[] { 2, 4, new MyList<int>() { -2, 34, 5, 6} };
        }

        [TestCaseSource(nameof(DataRemoveRangeByIndexWrongIndexTest))]
        public void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowIndexOutOfRangeException(
            int index, int quantity, MyList<int> inputList)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
                inputList.RemoveRangeByIndex(index, quantity));
        }

        private static IEnumerable<object[]> DataRemoveRangeByIndexWrongIndexTest()
        {
            yield return new object[] { -1, 1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };
            yield return new object[] { -10, 1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };
            yield return new object[] { 10, 1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };        
            yield return new object[] { 100, 1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };
        }
    }
}
