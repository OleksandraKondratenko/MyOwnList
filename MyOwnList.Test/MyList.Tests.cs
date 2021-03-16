using NUnit.Framework;
using System.Collections.Generic;
using System;

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
        public void AddStart_WhenInputValue_ShouldAddItToCollection(int value,
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

        [TestCaseSource(nameof(DataAddStartTest))]
        public void AddEnd_WhenInputValue_ShouldAddItToCollection(int value,
           MyList<int> result, MyList<int> expected)
        {
            result.AddStart(value);

            CollectionAssert.AreEqual(expected, result);
        }

        private static IEnumerable<object[]> DataAddEndTest()
        {
            yield return new object[] { 10, new MyList<int>() { 1, 2, 3, 4, 5, 6 },
            new MyList<int>() {10, 1, 2, 3, 4, 5, 6 } };
        }

        [TestCaseSource(nameof(DataDelEndValidTest))]
        public void DelEnd_WhenValidIndexPassed_ShouldDeleteLastElement(
            int expectedElement, MyList<int> inputList, MyList<int> expectedList)
        {
            int actualElement = inputList.DelEnd();

            Assert.AreEqual(expectedElement, actualElement);
            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataDelEndValidTest()
        {
            yield return new object[] { -17, new MyList<int>() { 2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { 2, 34, 5, 6, 57, 68, 65 } };

            yield return new object[] { 34, new MyList<int>() { 2, 34 },
                new MyList<int>() { 2 } };

            yield return new object[] { 2, new MyList<int>() { 2 },
                new MyList<int>() { } };
        }

        [TestCaseSource(nameof(DataDelEndThrowExceptionTest))]
        public void DelEnd_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException(
            MyList<int> inputList)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                inputList.DelEnd());
        }

        private static IEnumerable<object[]> DataDelEndThrowExceptionTest()
        {
            yield return new object[] { new MyList<int>()};
        }

        [TestCaseSource(nameof(DataDelFirstValidTest))]
        public void DelStart_WhenValidIndexPassed_ShouldDeleteFirstElement(
            int expectedElement, MyList<int> inputList, MyList<int> expectedList)
        {
            int actualElement = inputList.DelStart();

            Assert.AreEqual(expectedElement, actualElement);
            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataDelFirstValidTest()
        {
            yield return new object[] { -2, new MyList<int>() { -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { 34, 5, 6, 57, 68, 65, -17 } };

            yield return new object[] { 34, new MyList<int>() { 34, 96 },
                new MyList<int>() { 96 } };

            yield return new object[] { -117, new MyList<int>() { -117 },
                new MyList<int>() { } };
        }

        //[TestCaseSource(nameof(DataDelFirstThrowExceptionTest))]
        [Test]
        public void DelStart_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException(
            )
        {
            MyList<int> inputList = new MyList<int>() { };

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                inputList.DelEnd());
        }

        private static IEnumerable<object[]> DataDelFirstThrowExceptionTest()
        {
            yield return new object[] { new MyList<int>() };
        }

        [TestCaseSource(nameof(DataDelPosValidTest))]
        public void DelPos_WhenValidIndexPassed_ShouldDeleteElementByPosition(
            int deletedPosition, int expectedElement, MyList<int> inputList, MyList<int> expectedList)
        {
            int actualElement = inputList.DelPos(deletedPosition);

            Assert.AreEqual(expectedElement, actualElement);
            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataDelPosValidTest()
        {
            yield return new object[] { 0, -2, new MyList<int>() { -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { 34, 5, 6, 57, 68, 65, -17 } };

            yield return new object[] { 1, 34, new MyList<int>() {  -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { -2, 5, 6, 57, 68, 65, -17 } };

            yield return new object[] { 6, 65, new MyList<int>() {  -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { -2, 34, 5, 6, 57, 68, -17 } };

            yield return new object[] { 7, -17, new MyList<int>() {  -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { -2, 34, 5, 6, 57, 68, 65 } };
        }

        [TestCaseSource(nameof(DataDelPosThrowExceptionTest))]
        public void DelPos_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException(
            MyList<int> inputList)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                inputList.DelEnd());
        }

        private static IEnumerable<object[]> DataDelPosThrowExceptionTest()
        {
            yield return new object[] { new MyList<int>() };
        }
    }
}