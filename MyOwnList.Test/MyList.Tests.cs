using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test
{
    public class Tests
    {
        MyList<int> myList = new MyList<int>();

        [TestCaseSource(nameof(DataAddPosTest))]
        public void AddPos_WhenInputValue_ShouldAddItToCollection(int pos, int value, 
            MyList<int> result, MyList<int> expected)
        {
            result.AddPos(pos, value);

            CollectionAssert.AreEqual(expected, result);
        }

        private static IEnumerable<object[]> DataAddPosTest()
        {
            yield return new object[] { 3, 10, new MyList<int>() { 1, 2, 3, 4, 5, 6 }, 
            new MyList<int>() { 1, 2, 3, 10, 4, 5, 6 } };
        }

        [TestCaseSource(nameof(DataAddStartTest))]
        public void AddStart_WhenInputValue_ShouldAddItToCollection( int value,
            MyList<int> result, MyList<int> expected)
        {
            result.AddStart(value);

            CollectionAssert.AreEqual(expected, result);
        }

        private static IEnumerable<object[]> DataAddStartTest()
        {
            yield return new object[] { 10, new MyList<int>() { 1, 2, 3, 4, 5, 6 },
            new MyList<int>() {10, 1, 2, 3, 4, 5, 6 } };
        }

        [TestCaseSource(nameof(DataAddEndTest))]
        public void AddEnd_WhenInputValue_ShouldAddItToCollection(int value,
           MyList<int> result, MyList<int> expected)
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