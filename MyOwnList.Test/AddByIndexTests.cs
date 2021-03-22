using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test.AddByIndex
{
    public partial class MyList
    {
        [TestCase(3, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            new int[] { 1, 2, 3, 10, 4, 5, 6, 7, 8, 9, 10 })]

        public void AddByIndex_WhenInputIsValid_ShouldAddItToCollection(
         int index, int value, int[] result, int[] expected)
        {
            MyList<int> listExpected = new MyList<int>(expected);

            MyList<int> listResult = new MyList<int>(result);

            listResult.AddByIndex(index, value);

            CollectionAssert.AreEqual(listExpected, listResult);
        }

        [TestCase(25, 2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(-1, 2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(3, 10, new int[]{ })]
        public void AddByIndex_WhenInpuIsNotValid_ShouldGenerateExcaption(
           int index, int value, int[] result)
        {
            MyList<int> listResult = new MyList<int>(result);
            Assert.Throws<IndexOutOfRangeException>(() => listResult.AddByIndex(index, value));
        }

      
    }
}
