using NUnit.Framework;
using System;

namespace MyOwnList.Test.RemoveTests
{
    public partial class MyList
    {
        [TestCase(0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(4, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 57, 68, 65, -2, -17 })]
        [TestCase(7, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 65, -2, -17 })]
        [TestCase(10, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { })]
        public void RemoveRangeStart_WhenValidIndexPassed_ShouldRemoveRangeStart(
            int quantity, int[] inputArray, int[] expectedArray)
        {
            MyList<int> inputList = new MyList<int>(inputArray);
            MyList<int> expectedList = new MyList<int>(expectedArray);

            inputList.RemoveRangeStart(quantity);

            CollectionAssert.AreEqual(expectedList, inputList);
        }

        [TestCase(100, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(5, new int[] { -2, 34, 5, 6 })]
        public void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowInvalidOperationException(
            int quantity, int[] inputArray)
        {
            MyList<int> inputList = new MyList<int>(inputArray);

            Assert.Throws<InvalidOperationException>(() => inputList.RemoveRangeStart(quantity));
        }
    }
}
