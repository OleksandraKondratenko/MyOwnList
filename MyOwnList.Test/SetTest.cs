using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test
{
    class SetTest
    {
        [TestCaseSource(nameof(DataSetValidTest))]
        public void Set_WhenValidIndexPassed_ShouldSetValueByIndex(
            int index, int value, MyList<int> inputList, MyList<int> expectedList)
        {
            inputList.Set(index, value);

            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataSetValidTest()
        {
            yield return new object[] { 0, -40, new MyList<int>() { -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { -40, 34, 5, 6, 57, 68, 65, -17 } };

            yield return new object[] { 1, 197, new MyList<int>() {  -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { -2, 197, 5, 6, 57, 68, 65, -17 } };

            yield return new object[] { 6, -116, new MyList<int>() {  -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { -2, 34, 5, 6, 57, 68, -116, -17 } };

            yield return new object[] { 7, 1351, new MyList<int>() {  -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { -2, 34, 5, 6, 57, 68, 65, 1351 } };
        }

        [TestCaseSource(nameof(DataSetWrongIndexTest))]
        public void Set_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException(
            int index, int value, MyList<int> inputList)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                inputList.Set(index, value));
        }

        private static IEnumerable<object[]> DataSetWrongIndexTest()
        {
            yield return new object[] { -1, 135, new MyList<int>() {  -2, 34, 5, 6 } };
            yield return new object[] { 0, 135, new MyList<int>() };
            yield return new object[] { 4, 135, new MyList<int>() { -2, 34, 5, 6 } };
            yield return new object[] { 10, 135, new MyList<int>() { -2, 34, 5, 6 } };
        }
    }
}
