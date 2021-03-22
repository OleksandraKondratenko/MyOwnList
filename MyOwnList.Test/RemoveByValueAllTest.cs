using NUnit.Framework;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(-2, 3, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 34, 5, 6, 57, 68, 65, -17 })]
        [TestCase(34, 2, new int[] { -2, 34, 5, 6, -2, 57, 34, 68, 65, -2, -17 }, new int[] { -2, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(13, 0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(13, 0, new int[] { }, new int[] { })]
        public void RemoveByValueAll_WhenValidIndexPassed_ShouldRemoveFirstValue(
            int valueToRemove, int expectedCounter, int[] inputArray, int[] expectedArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);
            MyList<int> expectedList = new MyList<int>(expectedArray);

            int actualCounter = actualList.RemoveByValueAll(valueToRemove);

            Assert.AreEqual(expectedCounter, actualCounter);
            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
