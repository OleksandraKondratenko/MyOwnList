using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(3, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            new int[] { 1, 2, 3, 10, 4, 5, 6, 7, 8, 9, 10 })]

        public void AddByIndex_WhenInputIsValid_ShouldAddItToCollection(
         int index, int value, int [] result, int [] expected)
        {
            MyList<int> listExpected = new MyList<int>(expected);

            MyList<int> listResult = new MyList<int>(result);

            listResult.AddByIndex(index, value);

            CollectionAssert.AreEqual(listExpected, listResult);
        }

        //private static IEnumerable<object[]> DataAddPosTest()
        //{
        //    yield return new object[] { 3, 10, new MyList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
        //        new MyList<int>() { 1, 2, 3, 10, 4, 5, 6, 7, 8, 9, 10 } };
        //    yield return new object[] { 0, 10, new MyList<int>() ,
        //        new MyList<int>() { 10} };
        //}

        [TestCaseSource(nameof(DataAddByIndexOutOfRangeTest))]
        public void AddByIndex_WhenInpuIsNotValid_ShouldGenerateExcaption(
           int index, int value, MyList<int> result)
        {
            Assert.Throws<IndexOutOfRangeException>(() => result.AddByIndex(index, value));
        }

        private static IEnumerable<object[]> DataAddByIndexOutOfRangeTest()
        {
            yield return new object[] { -1, 2, new MyList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } };
            yield return new object[] { 25, 2, new MyList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } };
            yield return new object[] { 3, 10, new MyList<int>() };
        }
    }
}
