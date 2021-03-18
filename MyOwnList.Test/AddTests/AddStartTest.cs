using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test.AddTests
{
    class AddStartTest
    {
        [TestCaseSource(nameof(DataAddStartTest))]
        public void AddStart_WhenInputValue_ShouldAddItToCollection(
            int value, MyList<int> result, MyList<int> expected)
        {
            result.AddStart(value);

            CollectionAssert.AreEqual(expected, result);
        }
        private static IEnumerable<object[]> DataAddStartTest()
        {
            yield return new object[] { 10, new MyList<int>() { 1, 2, 3, 4, 5, 6 },
            new MyList<int>() {10, 1, 2, 3, 4, 5, 6 } };
        }
    }
}
