using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test
{
    class GetTest
    {
        [TestCaseSource(nameof(DataGetValidTest))]
        public void Get_WhenValidIndexPassed_ShouldGetValueByIndex(
            int index, int expected, MyList<int> inputList)
        {
            int actual = inputList.Get(index);

            Assert.AreEqual(expected, actual);
        }

        private static IEnumerable<object[]> DataGetValidTest()
        {
            yield return new object[] { 0, -2, new MyList<int>() { -2, 34, 5, 6, 57, 68, 65, -17 }};
            yield return new object[] { 1, 34, new MyList<int>() { -2, 34, 5, 6, 57, 68, 65, -17 } };
            yield return new object[] { 4, 57, new MyList<int>() { -2, 34, 5, 6, 57, 68, 65, -17 } };
            yield return new object[] { 7, -17, new MyList<int>() { -2, 34, 5, 6, 57, 68, 65, -17 } };
        }

        [TestCaseSource(nameof(DataGetWrongIndexTest))]
        public void Get_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException(
            int index, MyList<int> inputList)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                inputList.Get(index));
        }

        private static IEnumerable<object[]> DataGetWrongIndexTest()
        {
            yield return new object[] { -1, new MyList<int>() { -2, 34, 5, 6 } };
            yield return new object[] { 0, new MyList<int>() };
            yield return new object[] { 4, new MyList<int>() { -2, 34, 5, 6 } };
        }
    }
}
