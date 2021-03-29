using NUnit.Framework;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public override void Sort_WhenCollectionIsUnsorted_ShouldSortCollectionInAscendingOrder(
           int[] inpuatArray, int[] expectedArray)
        {
            MyList<int> expectedList = new MyList<int>(expectedArray);
            MyList<int> actualList = new MyList<int>(inpuatArray);

            actualList.Sort();

            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        public override void SortDesc_WhenCollectionIsUnsorted_ShouldSortCollectionInDescendingOrder(
            int[] inputArray, int[] expectedArray)
        {
            MyList<int> expectedList = new MyList<int>(expectedArray);
            MyList<int> actualList = new MyList<int>(inputArray);

            actualList.Sort(false);

            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}