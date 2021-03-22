using NUnit.Framework;
using System;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(3, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 30, 40, 50, 4, 5, 6 })]
        [TestCase(0, new int[] { 30, 40, 50 }, new int[] { }, new int[] { 30, 40, 50 })]
        public void AddRangeByIndex_WhenInputIsValued_ShouldAddItToCollection(
            int index, int[] collectionToInsert, int[] inputArray, int[] expectedArray)
        {
            MyList<int> expectedList = new MyList<int>(expectedArray);
            MyList<int> actualList = new MyList<int>(inputArray);

            actualList.AddRangeByIndex(index, collectionToInsert);

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestCase(-1, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(25, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(5, new int[] { 30, 40, 50 }, new int[] { })]
        public void AddRangeByIndex_WhenInpuISValued_ShouldThrowArgumentException(
          int index, int[] insertCollection, int[] inputArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);

            Assert.Throws<ArgumentException>(() => actualList.AddRangeByIndex(index, insertCollection));
        }
    }
}
