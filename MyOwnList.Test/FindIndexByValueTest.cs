using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test
{
    class FindIndexByValueTest
    {
        [TestCaseSource(nameof(DataFindIndexByValueValidTest))]
        public void FindIndexByValue_WhenValidIndexPassed_ShouldReturnIndex(
            int value, int expectedIndex, MyList<int> inputList)
        {
            int actualIndex = inputList.FindIndexByValue(value);

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        private static IEnumerable<object[]> DataFindIndexByValueValidTest()
        {
            yield return new object[] { -2, 0, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 34, 1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 68, 6, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { -17, 9, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { -10, -1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { -1, -1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 10, -1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };

            yield return new object[] { 13, -1, new MyList<int>() { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 } };
        }
    }
}
