using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test.AddTests
{
    class AddEndTest
    {
        [TestCaseSource(nameof(DataAddTest))]
        public void Add_WhenInputIsValid_ShouldAddItToCollection(
           int value, MyList<int> result, MyList<int> expected)
        {
            result.Add(value);

            CollectionAssert.AreEqual(expected, result);
        }
        private static IEnumerable<object[]> DataAddTest()
        {
            yield return new object[] { 10, new MyList<int>() { 1, 2, 3, 4, 5, 6 },
            new MyList<int>() { 1, 2, 3, 4, 5, 6, 10} };
            yield return new object[] { 10, new MyList<int>() ,
            new MyList<int>() { 10} };
        }
    }
}
