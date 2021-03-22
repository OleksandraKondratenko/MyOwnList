using NUnit.Framework;
using System;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(2, new int[] { 1, 2, 10, 4, 5, 6 })]
        [TestCase(5, new int[] { 1, 2, 10, 4, 5, 50 })]
        [TestCase(0, new int[] { 1 })]
        public void GetMaxIndex_WhenInputIsValued_ShouldFindIndexMaxElement(
            int expectedIndex, int[] inputArray)
        {
            MyList<int> acualList = new MyList<int>(inputArray);

            int actualIndex = acualList.GetMaxIndex();

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase(new int[] { })]
        public void GetMaxIndex_WhenInputIsNotValid_ShouldThrowInvalidOperationExeption(
            int[] inputArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);

            Assert.Throws<InvalidOperationException>(() => actualList.GetMaxIndex());
        }

        [TestCase(null)]
        public void GetMaxIndex_WhenInputIsNotValid_ShouldThrowNullReferenceExeption(
            int[] inputArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);

            Assert.Throws<NullReferenceException>(() => actualList.GetMaxIndex());
        }

        [TestCase(10, new int[] { 1, 2, 10, 4, 5, 6, 7, 8, 9, 6 })]
        [TestCase(50, new int[] { 1, 2, 10, 4, 5, 50 })]
        [TestCase(1, new int[] { 1 })]
        public void GetMax_WhenInputIsValued_ShouldFindMaxElement(
            int expectedMax, int[] inputArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);
            int actualMax = actualList.GetMax();

            Assert.AreEqual(expectedMax, actualMax);
        }
    }
}
