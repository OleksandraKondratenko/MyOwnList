using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test.AddTests
{
    public partial class MyList
    {
        [TestCase(3, new int[] { 30, 40, 50 },
            new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 30, 40, 50, 4, 5, 6 })]
        [TestCase(0, new int[] { 30, 40, 50 }, new int[] { }, new int[] { 30, 40, 50 })]
        public void AddRangeByIndex_WhenInputIsValued_ShouldAddItToCollection(
          int index, int [] collection, int [] result, int [] expected)
        {

            MyList<int> listExpected = new MyList<int>(expected);

            MyList<int> listResult = new MyList<int>(result);

            listResult.AddRangeByIndex(index, collection);

            CollectionAssert.AreEqual(listExpected, listResult);
        }


        [TestCase(-1, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(25, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(5, new int[] { 30, 40, 50 }, new int[] { })]
        public void AddRangeByIndex_WhenInpuISValued_ShouldGenerateExcaption(
          int pos, int[] value, int[] result)
        {

            MyList<int> listResult = new MyList<int>(result);

            Assert.Throws<ArgumentException>(() => listResult.AddRangeByIndex(pos, value));
        }
    }
}
