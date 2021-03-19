using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test
{
    class RemoveByIndexTest
    {
        [TestCaseSource(nameof(DataRemoveByIndexValidTest))]
        public void RemoveByIndex_WhenValidIndexPassed_ShouldDeleteElementByPosition(
            int index, int expectedElement, MyList<int> inputList, MyList<int> expectedList)
        {
            int actualElement = inputList.RemoveByIndex(index);

            Assert.AreEqual(expectedElement, actualElement);
            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataRemoveByIndexValidTest()
        {
            yield return new object[] { 0, -2, new MyList<int>() { -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { 34, 5, 6, 57, 68, 65, -17 } };

            yield return new object[] { 1, 34, new MyList<int>() {  -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { -2, 5, 6, 57, 68, 65, -17 } };

            yield return new object[] { 6, 65, new MyList<int>() {  -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { -2, 34, 5, 6, 57, 68, -17 } };

            yield return new object[] { 7, -17, new MyList<int>() {  -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { -2, 34, 5, 6, 57, 68, 65 } };
        }

        [TestCaseSource(nameof(DataRemoveByIndexWrongIndexTest))]
        public void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException(
            int index, MyList<int> inputList)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                inputList.RemoveByIndex(index));
        }

        private static IEnumerable<object[]> DataRemoveByIndexWrongIndexTest()
        {
            yield return new object[] { -1, new MyList<int>() { -2, 34, 5, 6 } };
            yield return new object[] { 0, new MyList<int>() };
            yield return new object[] { 4, new MyList<int>() { -2, 34, 5, 6 } };
            yield return new object[] { 10, new MyList<int>() { -2, 34, 5, 6 } };
        }
    }
}
