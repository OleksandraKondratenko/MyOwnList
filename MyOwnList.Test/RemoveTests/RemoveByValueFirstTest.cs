using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test.DelTests
{
    class RemoveByValueFirstTest
    {
        [TestCaseSource(nameof(DataRemoveByValueFirstValidTest))]
        public void RemoveByValueFirst_WhenValidIndexPassed_ShouldRemoveFirstValue(
            int value, int expectedIndex, MyList<int> inputList, MyList<int> expectedList)
        {
            int actualIndex = inputList.RemoveByValueFirst(value);

            Assert.AreEqual(expectedIndex, actualIndex);
            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataRemoveByValueFirstValidTest()
        {
            yield return new object[] { -2, 0, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 34, 1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { -2, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 68, 6, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { -2, 34, 5, 6, -2, 57, 65, -2, -17 } };

            yield return new object[] { -17, 9, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2 } };

            yield return new object[] { -10, -1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { -1, -1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 10, -1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 13, -1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 },
                new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };
        }
    }
}
