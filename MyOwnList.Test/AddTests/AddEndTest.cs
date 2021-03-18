using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test.AddTests
{
    class AddEndTest
    {
        [TestCaseSource(nameof(DataAddEndTest))]
        public void AddEnd_WhenInputValue_ShouldAddItToCollection(
           int value, MyList<int> result, MyList<int> expected)
        {
            result.Add(value);

            CollectionAssert.AreEqual(expected, result);
        }
        private static IEnumerable<object[]> DataAddEndTest()
        {
            yield return new object[] { 10, new MyList<int>() { 1, 2, 3, 4, 5, 6 },
            new MyList<int>() { 1, 2, 3, 4, 5, 6, 10} };
        }
    }
}
