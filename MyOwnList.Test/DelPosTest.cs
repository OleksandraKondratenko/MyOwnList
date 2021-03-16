using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test
{
    class DelPosTest
    {
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
