using NUnit.Framework;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -17, 65, 68, 57, 6, 5, 34, -2 })]
        [TestCase(new int[] { -2, 34, 5, 6, 57, 68, 65 }, new int[] { 65, 68, 57, 6, 5, 34, -2 })]
        [TestCase(new int[] { }, new int[] { })]
        public override void Reverse_WhenValidListPassed_ShouldReverseList(
            int[] inputArray, int[] expectedArray)
        {
            MyList<int> actualList = new MyList<int>(inputArray);
            MyList<int> expectedList = new MyList<int>(expectedArray);

            actualList.Reverse();

            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
