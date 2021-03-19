using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test.AddByIndex
{
    class AddByIndexTests
    {
        MyList<int> myList = new MyList<int>();

        [TestCaseSource(nameof(DataAddPosTest))]
        public void AddByIndex_WhenInputIsValid_ShouldAddItToCollection(
            int pos, int value, MyList<int> result, MyList<int> expected)
        {
            result.AddByIndex(pos, value);

            CollectionAssert.AreEqual(expected, result);
        }

        private static IEnumerable<object[]> DataAddPosTest()
        {
            yield return new object[] { 3, 10, new MyList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
            new MyList<int>() { 1, 2, 3, 10, 4, 5, 6, 7, 8, 9, 10 } };
            yield return new object[] { 0, 10, new MyList<int>() ,
            new MyList<int>() { 10} };
        }

        [TestCaseSource(nameof(DataAddByIndexOutOfRangeTest))]
        public void AddByIndex_WhenInpuIsNotValid_ShouldGenerateExcaption(
           int index, int value, MyList<int> result)
        {
            Assert.Throws<IndexOutOfRangeException>(()=>result.AddByIndex(index,value));
        }

        private static IEnumerable<object[]> DataAddByIndexOutOfRangeTest()
        {
            yield return new object[] { -1, 2, new MyList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}};
            yield return new object[] { 25, 2, new MyList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}};
            yield return new object[] { 3, 10, new MyList<int>() };
        }
    }
}
