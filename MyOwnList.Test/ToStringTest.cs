using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test
{
    class ToStringTest
    {
        [TestCaseSource(nameof(DataToStringTest))]
        public void ToString_WhenCollectionIsValued_ShouldConvertCollectionToString(
          MyList<int> collection, string expected)
        {
            string result = collection.ToString();

           Assert.AreEqual(expected, result);
        }
        private static IEnumerable<object[]> DataToStringTest()
        {
            yield return new object[] { new MyList<int>() { 6, 7, 2, 1 ,5, 3, 4, 10, 8, 9 },
                "67215341089" };
        }
    }
}
