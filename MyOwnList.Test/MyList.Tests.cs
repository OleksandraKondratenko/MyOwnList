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

        [TestCaseSource(nameof(DataMaxPosTest))]
        public void MaxPos_WhenInputIsValued_ShouldFindIndexMaxElement( MyList<int> result, int posExpected)
        {
            int posResult = result.MaxPos();

            Assert.AreEqual(posExpected, posResult);
        }

        private static IEnumerable<object[]> DataMaxPosTest()
        {
            yield return new object[] { new MyList<int>() { 1, 2, 10, 4, 5, 6 }, 2 };
        }

        [TestCaseSource(nameof(DataMinPosTest))]
        public void MinPos_WhenInputIsValued_ShouldFindIndexMinElement(MyList<int> result, int posExpected)
        {
            int posResult = result.MinPos();

            Assert.AreEqual(posExpected, posResult);
        }

        private static IEnumerable<object[]> DataMinPosTest()
        {
            yield return new object[] { new MyList<int>() { 1, 2, 10, 0, 4, 5, 6 }, 3 };
        }

        [TestCaseSource(nameof(DataMaxTest))]
        public void Max_WhenInputIsValued_ShouldFindMaxElement(MyList<int> result, int posExpected)
        {
            int posResult = result.Max();

            Assert.AreEqual(posExpected, posResult);
        }

        private static IEnumerable<object[]> DataMaxTest()
        {
            yield return new object[] { new MyList<int>() { 1, 2, 10, 4, 5, 6 }, 10 };
        }

        [TestCaseSource(nameof(DataMinTest))]
        public void Min_WhenInputIsValued_ShouldFindMaxElement(MyList<int> result, int posExpected)
        {
            int posResult = result.Min();

            Assert.AreEqual(posExpected, posResult);
        }

        private static IEnumerable<object[]> DataMinTest()
        {
            yield return new object[] { new MyList<int>() { 1, 2, 10, 0, 4, 5, 6 }, 0 };
        }
    }
}