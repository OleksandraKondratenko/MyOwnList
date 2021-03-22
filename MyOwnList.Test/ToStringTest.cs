using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, "6 7 2 1 5 3 4 10 8 9")]
        public void ToString_WhenCollectionIsValued_ShouldConvertCollectionToString(
          int[] inputArray, string expected)
        {
            MyList<int> inputList = new MyList<int>(inputArray);

            string result = inputList.ToString();

            Assert.AreEqual(expected, result);
        }
    }
}
