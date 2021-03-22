using NUnit.Framework;
using System;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(-17, new int[] { 2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { 2, 34, 5, 6, 57, 68, 65 })]
        [TestCase(34, new int[] { 2, 34 }, new int[] { 2 })]
        [TestCase(2, new int[] { 2 }, new int[] { })]
        public void Remove_WhenValidIndexPassed_ShouldDeleteLastElement(
            int expectedElement, int[] inputArray, int[] expectedArray)
        {
            MyList<int> inputList = new MyList<int>(inputArray);
            MyList<int> expectedList = new MyList<int>(expectedArray);

            int actualElement = inputList.Remove();

            Assert.AreEqual(expectedElement, actualElement);
            CollectionAssert.AreEqual(expectedList, inputList);
        }

        [Test]
        public void Remove_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException()
        {
            MyList<int> inputList = new MyList<int>();

            Assert.Throws<InvalidOperationException>(() => inputList.Remove());
        }
    }
}
