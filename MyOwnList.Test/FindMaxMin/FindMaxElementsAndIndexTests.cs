using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test.FindMaxMin
{
    class FindMaxElementsAndIndexTests
    {
        [TestCaseSource(nameof(DataMaxPosTest))]
        public void MaxPos_WhenInputIsValued_ShouldFindIndexMaxElement(MyList<int> result, int posExpected)
        {
            int posResult = result.MaxPos();

            Assert.AreEqual(posExpected, posResult);
        }

        private static IEnumerable<object[]> DataMaxPosTest()
        {
            yield return new object[] { new MyList<int>() { 1, 2, 10, 4, 5, 6 }, 2 };
        }

        [TestCaseSource(nameof(DataMaxTest))]
        public void Max_WhenInputIsValued_ShouldFindMaxElement(MyList<int> result, int posExpected)
        {
            int posResult = result.Max();

            Assert.AreEqual(posExpected, posResult);
        }

        private static IEnumerable<object[]> DataMaxTest()
        {
            yield return new object[] { new MyList<int>() { 1, 2, 10, 4, 5, 6, 7, 8, 9, 6 }, 10 };
        }
    }
}
