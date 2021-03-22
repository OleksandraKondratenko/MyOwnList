using NUnit.Framework;
using System;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(3, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 10, 4, 5, 6, 7, 8, 9, 10 })]
        public void AddByIndex_WhenInputIsValid_ShouldAddItToCollection(
            int index, int valueToInsert, int[] inputArray, int[] expectedArray)
        {
            MyList<int> expectedList = new MyList<int>(expectedArray);
            MyList<int> actualList = new MyList<int>(inputArray);

            actualList.AddByIndex(index, valueToInsert);

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestCase(25, 2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(-1, 2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(3, 10, new int[] { })]
        public void AddByIndex_WhenInpuIsNotValid_ShouldThrowIndexOutOfRangeException(
            int index, int value, int[] result)
        {
            MyList<int> listResult = new MyList<int>(result);

            Assert.Throws<IndexOutOfRangeException>(() => listResult.AddByIndex(index, value));
        }
    }
}
