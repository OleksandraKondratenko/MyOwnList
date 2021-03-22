using NUnit.Framework;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(10, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 10 })]
        [TestCase(10, new int[] { }, new int[] { 10 })]
        public void Add_WhenInputIsValid_ShouldAddItToCollection(
            int valueToInsert, int[] inputArray, int[] expectedArray)
        {
            MyList<int> expectedList = new MyList<int>(expectedArray);
            MyList<int> actualList = new MyList<int>(inputArray);

            actualList.Add(valueToInsert);

            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
