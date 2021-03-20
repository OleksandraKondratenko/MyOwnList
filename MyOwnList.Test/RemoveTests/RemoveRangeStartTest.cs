using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test.RemoveTests
{
    class RemoveRangeStartTest
    {
        [TestCaseSource(nameof(DataRemoveRangeStartValidTest))]
        public void RemoveRangeByIndex_WhenValidIndexPassed_ShouldRemoveRangeStart(
            int quantity, MyList<int> inputList, MyList<int> expectedList)
        {
            inputList.RemoveRangeStart(quantity);

            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataRemoveRangeStartValidTest()
        {
            yield return new object[] { 0, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 4, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 7, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { 65, -2, -17 } };

            yield return new object[] { 10, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { } };
        }

        [TestCaseSource(nameof(DataRemoveRangeStartWrongQuantityTest))]
        public void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowInvalidOperationException(
            int quantity, MyList<int> inputList)
        {
            Assert.Throws<InvalidOperationException>(() => inputList.RemoveRangeStart(quantity));
        }

        private static IEnumerable<object[]> DataRemoveRangeStartWrongQuantityTest()
        {
            yield return new object[] { 100, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };
            yield return new object[] { 5, new MyList<int>() { -2, 34, 5, 6 } };
        }
    }
}
