using NUnit.Framework;
using System;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(3, new int[] { 1, 2, 10, 0, 4, 5, 6 })]
        [TestCase(6, new int[] { 2, 2, 10, 3, 4, 5, 1 })]
        [TestCase(0, new int[] { 1 })]
        public void GetMinIndex_WhenInputIsValid_ShouldFindIndexMinElement(
            int expectedIndex, int[] inputArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);

            int actualIndex = actualList.GetMinIndex();

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase(new int[] { })]
        public void GetMinIndex_WhenInputIsNotValid_ShouldThrowInvalidOperationInvalidOperationExeption(
            int[] inputArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);

            Assert.Throws<InvalidOperationException>(() => actualList.GetMinIndex());
        }

        [TestCase(null)]
        public void GetMinIndex_WhenInputIsNotValid_ShouldThrowNullReferenceExeption(
            int[] inputArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);

            Assert.Throws<NullReferenceException>(() => actualList.GetMinIndex());
        }

        [TestCase(0, new int[] { 1, 2, 10, 0, 4, 5, 6 })]
        [TestCase(1, new int[] { 2, 2, 10, 3, 4, 5, 1 })]
        [TestCase(1, new int[] { 1 })]
        public void GetMin_WhenInputIsValued_ShouldFindMaxElement(
            int expectedMin, int[] inputArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);

            int actualMin = actualList.GetMin();

            Assert.AreEqual(expectedMin, actualMin);
        }
    }
}
