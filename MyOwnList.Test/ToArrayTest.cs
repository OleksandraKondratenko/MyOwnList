using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test
{
    class ToArrayTest
    {
        [TestCaseSource(nameof(DataToStringTest))]
        public void ToArray_WhenCollectionIsValied_ShouldConvertToArray(
           MyList<int> collection, int[] expected)
        {
            int[] result = collection.ToArray();

            CollectionAssert.AreEqual(expected, result);
        }
        private static IEnumerable<object[]> DataToStringTest()
        {
            yield return new object[] { new MyList<int>() { 6,7, 2, 1 ,5, 3, 4, 10, 8, 9 },
                new int [] { 6,7, 2, 1 ,5, 3, 4, 10, 8, 9 } };
        }
    }
}
