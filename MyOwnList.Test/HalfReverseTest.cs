using NUnit.Framework;
using System;

namespace MyOwnList.Test
{
    public partial class MyOwnList
    {
        [TestCase(new int[] { -2, 34, 5, 57, 68, 65 }, new int[] { 57, 68, 65, -2, 34, 5 })]
        [TestCase(new int[] { -2, 34, 5, 1057, 57, 68, 65 }, new int[] { 57, 68, 65, 1057, -2, 34, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        public void HalfReverse_WhenValidListPassed_ShouldReverseListByHalves(
            int[] inputArray, int[] expectedArray)
        {
            MyList<int> inputList = new MyList<int>(inputArray);
            MyList<int> expectedList = new MyList<int>(expectedArray);

            inputList.HalfReverse();

            CollectionAssert.AreEqual(expectedList, inputList);
        }

        [TestCase(null)]
        public void HalfReverse_WhenValidListPassed_ShouldReverseListByHalves(
            MyList<int> inputList)
        {
            Assert.Throws<NullReferenceException>(() => inputList.HalfReverse());
        }
    }
}
