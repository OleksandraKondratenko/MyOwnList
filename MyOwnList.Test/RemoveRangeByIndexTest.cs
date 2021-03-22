using NUnit.Framework;
using System;

namespace MyOwnList.Test.RemoveTests
{
    public partial class MyList
    {
        [TestCase(4, 3, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, 65, -2, -17 })]
        [TestCase(0, 7, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 65, -2, -17 })]
        [TestCase(6, 4, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57 })]
        [TestCase(0, 10, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { })]
        public void RemoveRangeByIndex_WhenValidIndexPassed_ShouldRemoveRangeByIndex(
            int index, int quantity, int[] inputArray, int[] expectedArray)
        {
            MyList<int> inputList = new MyList<int>(inputArray);
            MyList<int> expectedList = new MyList<int>(expectedArray);

            inputList.RemoveRangeByIndex(index, quantity);

            CollectionAssert.AreEqual(expectedList, inputList);
        }

        [TestCase(3, 100, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(2, 4, new int[] { -2, 34, 5, 6 })]
        public void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowInvalidOperationException(
            int index, int quantity, int[] inputArray)
        {
            MyList<int> inputList = new MyList<int>(inputArray);

            Assert.Throws<InvalidOperationException>(() =>
                inputList.RemoveRangeByIndex(index, quantity));
        }

        [TestCase(-1, 1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(-10, 1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(10, 1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(100, 1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        public void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowIndexOutOfRangeException(
            int index, int quantity, int[] inputArray)
        {
            MyList<int> inputList = new MyList<int>(inputArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
                inputList.RemoveRangeByIndex(index, quantity));
        }
    }
}
