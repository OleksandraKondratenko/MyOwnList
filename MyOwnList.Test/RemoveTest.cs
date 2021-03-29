using NUnit.Framework;
using System;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(-17, new int[] { 2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { 2, 34, 5, 6, 57, 68, 65 })]
        [TestCase(34, new int[] { 2, 34 }, new int[] { 2 })]
        [TestCase(2, new int[] { 2 }, new int[] { })]
        public override void Remove_WhenValidIndexPassed_ShouldDeleteLastElement(
            int expectedValueToRemove, int[] inputArray, int[] expectedArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);
            MyList<int> expectedList = new MyList<int>(expectedArray);

            int actualValueToRemove = actualList.Remove();

            Assert.AreEqual(expectedValueToRemove, actualValueToRemove);
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [Test]
        public override void Remove_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException()
        {
            MyList<int> actualList = new MyList<int>();

            Assert.Throws<InvalidOperationException>(() => actualList.Remove());
        }
    }
}
