using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test.DelTests
{
    class RemoveByValueAllTest
    {
        [TestCaseSource(nameof(DataRemoveByValueAllValidTest))]
        public void RemoveByValueAll_WhenValidIndexPassed_ShouldRemoveFirstValue(
            int value, int expectedCounter, MyList<int> inputList, MyList<int> expectedList)
        {
            int actualCounter = inputList.RemoveByValueAll(value);

            Assert.AreEqual(expectedCounter, actualCounter);
            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataRemoveByValueAllValidTest()
        {
            yield return new object[] { -2, 3, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { 34, 5, 6, 57, 68, 65, -17 } };

            yield return new object[] { 34, 2, new MyList<int>() { -2, 34, 5, 6, -2, 57, 34, 68, 65, -2, -17 },
                new MyList<int>() { -2, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 13, 0, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() {-2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 13, 0, new MyList<int>() { },
                new MyList<int>() { } };
        }
    }
}
