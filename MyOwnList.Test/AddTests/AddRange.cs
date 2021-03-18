using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test.AddTests
{
    class AddRange
    {
        [TestCaseSource(nameof(DataAddRangeTest))]
        public void AddRange_WhenInputIsValued_ShouldAddItToCollection(
            MyList<int> collection, MyList<int> result, MyList<int> expected)
        {
            result.AddRange(collection);

            CollectionAssert.AreEqual(expected, result);
        }
        private static IEnumerable<object[]> DataAddRangeTest()
        {
            yield return new object[] { new MyList<int>(){ 30, 40, 50}, new MyList<int>() { 1, 2, 3, 4, 5, 6 },
                new MyList<int>() { 1, 2, 3, 4, 5, 6, 30, 40, 50 } };
        }
    }
}
