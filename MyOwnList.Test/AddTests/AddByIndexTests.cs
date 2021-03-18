using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test.AddByIndex
{
    class AddByIndexTests
    {
        MyList<int> myList = new MyList<int>();

        [TestCaseSource(nameof(DataAddPosTest))]
        public void AddPos_WhenInputValue_ShouldAddItToCollection(
            int pos, int value, MyList<int> result, MyList<int> expected)
        {
            result.AddByIndex(pos, value);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(-1,2 )]
        [TestCase(25,2 )]
        public void AddPos_WhenInpuISValued_ShouldGenerateExcaption(
           int pos, int value)
        {
            MyList<int> result = new MyList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Assert.Throws<ArgumentException>(()=>result.AddByIndex(pos,value));
        }

        private static IEnumerable<object[]> DataAddPosTest()
        {
            yield return new object[] { 3, 10, new MyList<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
            new MyList<int>() { 1, 2, 3, 10, 4, 5, 6, 7, 8, 9, 10 } };
        }
    }
}
