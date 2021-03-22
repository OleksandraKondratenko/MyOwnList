using NUnit.Framework;

namespace MyOwnList.Test
{
    class ToArrayTest
    {
        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 })]
        public void ToArray_WhenCollectionIsValied_ShouldConvertToArray(
           int [] collectionToArray, int[] expectedArray)
        {
            MyList<int> listCollection = new MyList<int>(collectionToArray);

            int[] actualArray = listCollection.ToArray();

            CollectionAssert.AreEqual(expectedArray, actualArray);
        }
    }
}
