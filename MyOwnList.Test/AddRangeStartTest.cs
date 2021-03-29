using NUnit.Framework;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 30, 40, 50, 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 30, 40, 50 }, new int[] { }, new int[] { 30, 40, 50 })]
        public override void AddRangeStart_WhenInputIsValued_ShouldAddItToCollection(
            int[] collectionToInsert, int[] inputArray, int[] expectedArray)
        {
            MyList<int> expectedList = new MyList<int>(expectedArray);
            MyList<int> actualList = new MyList<int>(inputArray);

            actualList.AddRangeStart(collectionToInsert);

            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
