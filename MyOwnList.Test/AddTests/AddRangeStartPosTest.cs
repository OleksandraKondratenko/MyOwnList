using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test.AddTests
{
    class AddRangeStartPosTest
    {
        [TestCaseSource(nameof(DataAddRangeStartPosTest))]
        public void AddRangeStartPos_WhenInputIsValued_ShouldAddItToCollection(
           MyList<int> collection, MyList<int> result, MyList<int> expected)
        {
            result.AddRangeStartPos(collection);

            CollectionAssert.AreEqual(expected, result);
        }
        private static IEnumerable<object[]> DataAddRangeStartPosTest()
        {
            yield return new object[] { new MyList<int>(){ 30, 40, 50}, new MyList<int>() { 1, 2, 3, 4, 5, 6 },
                new MyList<int>() { 30, 40, 50, 1, 2, 3, 4, 5, 6 } };
            yield return new object[] { new MyList<int>(){ 30, 40, 50}, new MyList<int>(), new MyList<int>() { 30, 40, 50} };
        }
    }
}
