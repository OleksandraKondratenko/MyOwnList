using NUnit.Framework;
using System;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(new int[] { -2, 34, 5, 57, 68, 65 }, new int[] { 57, 68, 65, -2, 34, 5 })]
        [TestCase(new int[] { -2, 34, 5, 1057, 57, 68, 65 }, new int[] { 57, 68, 65, 1057, -2, 34, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        public void HalfReverse_WhenValidListPassed_ShouldReverseListByHalves(
            int[] inputArray, int[] expectedArray)
        {
            MyList<int> axtualList = new MyList<int>(inputArray);
            MyList<int> expectedList = new MyList<int>(expectedArray);

            axtualList.HalfReverse();

            CollectionAssert.AreEqual(expectedList, axtualList);
        }

        [TestCase(null)]
        public void HalfReverse_WhenValidListPassed_ShouldReverseListByHalves(
            int[] inputArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);

            Assert.Throws<NullReferenceException>(() => actualList.HalfReverse());
        }
    }
}
