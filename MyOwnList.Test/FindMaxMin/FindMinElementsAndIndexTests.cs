using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test.FindMaxMin
{
    class FindMinElementsAndIndexTests
    {
        [TestCaseSource(nameof(DataMinPosTest))]
        public void MinPos_WhenInputIsValued_ShouldFindIndexMinElement(MyList<int> result, int posExpected)
        {
            int posResult = result.GetMinIndex();

            Assert.AreEqual(posExpected, posResult);
        }
        private static IEnumerable<object[]> DataMinPosTest()
        {
            yield return new object[] { new MyList<int>() { 1, 2, 10, 0, 4, 5, 6 }, 3 };
        }

        [TestCaseSource(nameof(DataMinTest))]
        public void Min_WhenInputIsValued_ShouldFindMaxElement(MyList<int> result, int posExpected)
        {
            int posResult = result.GetMin();

            Assert.AreEqual(posExpected, posResult);
        }
        private static IEnumerable<object[]> DataMinTest()
        {
            yield return new object[] { new MyList<int>() { 1, 2, 10, 0, 4, 5, 6 }, 0 };
        }
    }
}
