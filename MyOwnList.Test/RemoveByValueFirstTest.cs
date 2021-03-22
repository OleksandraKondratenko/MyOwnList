using NUnit.Framework;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(-2, 0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(34, 1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(68, 6, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 65, -2, -17 })]
        [TestCase(-17, 9, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2 })]
        [TestCase(-10, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(-1, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(10, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(13, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(19, -1, new int[] { }, new int[] { })]
        public void RemoveByValueFirst_WhenValidIndexPassed_ShouldRemoveFirstValue(
            int valueToRemove, int expectedIndex, int[] inputArray, int[] expectedArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);
            MyList<int> expectedList = new MyList<int>(expectedArray);

            int actualIndex = actualList.RemoveByValueFirst(valueToRemove);

            Assert.AreEqual(expectedIndex, actualIndex);
            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
