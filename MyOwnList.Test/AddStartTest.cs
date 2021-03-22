using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test.AddTests
{
    class AddStartTest
    {
        [TestCase(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void AddStart_WhenInputValue_ShouldAddItToCollection(
            int value, int[] result, int[] expected)
        {
            MyList<int> listExpected = new MyList<int>(expected);

            MyList<int> listResult = new MyList<int>(result);

            listResult.AddStart(value);

            CollectionAssert.AreEqual(listExpected, listResult);
        }
    }
}
