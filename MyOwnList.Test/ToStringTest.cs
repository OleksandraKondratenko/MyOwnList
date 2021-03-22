using NUnit.Framework;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, "6 7 2 1 5 3 4 10 8 9")]
        public void ToString_WhenCollectionIsValued_ShouldConvertCollectionToString(
          int[] inputArray, string expectedString)
        {
            MyList<int> actualList = new MyList<int>(inputArray);

            string actualString = actualList.ToString();

            Assert.AreEqual(expectedString, actualString);
        }
    }
}
