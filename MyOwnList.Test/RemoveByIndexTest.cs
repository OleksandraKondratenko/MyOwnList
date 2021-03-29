using NUnit.Framework;
using System;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(0, -2, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { 34, 5, 6, 57, 68, 65, -17 })]
        [TestCase(1, 34, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -2, 5, 6, 57, 68, 65, -17 })]
        [TestCase(6, 65, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -2, 34, 5, 6, 57, 68, -17 })]
        [TestCase(7, -17, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -2, 34, 5, 6, 57, 68, 65 })]
        public override void RemoveByIndex_WhenValidIndexPassed_ShouldDeleteElementByPosition(
            int index, int expectedValueToRemove, int[] inputArray, int[] expectedArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);
            MyList<int> expectedList = new MyList<int>(expectedArray);

            int actualValueToRemove = actualList.RemoveByIndex(index);

            Assert.AreEqual(expectedValueToRemove, actualValueToRemove);
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestCase(-1, new int[] { -2, 34, 5, 6 })]
        [TestCase(0, new int[] { })]
        [TestCase(4, new int[] { -2, 34, 5, 6 })]
        [TestCase(10, new int[] { -2, 34, 5, 6 })]
        public override void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException(
            int index, int[] inputArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);

            Assert.Throws<ArgumentOutOfRangeException>(() => actualList.RemoveByIndex(index));
        }
    }
}
