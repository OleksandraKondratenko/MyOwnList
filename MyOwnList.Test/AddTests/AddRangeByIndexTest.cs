using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test.AddTests
{
    class AddRangeByIndexTest
    {
        [TestCaseSource(nameof(DataAddRangeByIndexTest))]
        public void AddRangeByIndex_WhenInputIsValued_ShouldAddItToCollection(
          int pos, MyList<int> collection, MyList<int> result, MyList<int> expected)
        {
            result.AddRangeByIndex(pos, collection);

            CollectionAssert.AreEqual(expected, result);
        }
        private static IEnumerable<object[]> DataAddRangeByIndexTest()
        {
            //yield return new object[] { 3, new MyList<int>(){ 30, 40, 50}, new MyList<int>() { 1, 2, 3, 4, 5, 6 },
            //    new MyList<int>() { 1, 2, 3, 30, 40, 50, 4, 5, 6 } };
            yield return new object[] { 0, new MyList<int>(){ 30, 40, 50}, new MyList<int>(),
                new MyList<int>() { 30, 40, 50} };
        }



        [TestCaseSource(nameof(DataAddRangeByIndexTestWithExeption))]
        public void AddRangeByIndex_WhenInpuISValued_ShouldGenerateExcaption(
          int pos, MyList<int> value, MyList<int> result)
        {
            Assert.Throws<ArgumentException>(() => result.AddRangeByIndex(pos, value));
        }
        private static IEnumerable<object[]> DataAddRangeByIndexTestWithExeption()
        {
            yield return new object[] { -1, new MyList<int>() { 30, 40, 50 }, new MyList<int>() { 1, 2, 3, 4, 5, 6 } };
            yield return new object[] { 25, new MyList<int>() { 30, 40, 50 }, new MyList<int>() { 1, 2, 3, 4, 5, 6 } };
            yield return new object[] { 5, new MyList<int>(){ 30, 40, 50}, new MyList<int>()};
        }
    }
}
