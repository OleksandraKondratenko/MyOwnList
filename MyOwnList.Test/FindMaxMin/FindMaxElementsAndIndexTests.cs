using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test.FindMaxMin
{
    class FindMaxElementsAndIndexTests
    {
        [TestCaseSource(nameof(DataMaxPosTest))]
        public void MaxPos_WhenInputIsValued_ShouldFindIndexMaxElement(MyList<int> result, int IndexExpected)
        {
            int IndexResult = result.GetMaxIndex();

            Assert.AreEqual(IndexExpected, IndexResult);
        }

        private static IEnumerable<object[]> DataMaxPosTest()
        {
            yield return new object[] { new MyList<int>() { 1, 2, 10, 4, 5, 6 }, 2 };
            yield return new object[] { new MyList<int>() { 1 }, 0 };
        }

        [TestCaseSource(nameof(DataGetMaxIndexForExeptionTest))]
        public void GetMaxIndex_WhenInputIsNotValid_ShouldGenerateExeption(MyList<int> result)
        {
            Assert.Throws<InvalidOperationException>(() => result.GetMaxIndex());
        }
        private static IEnumerable<object[]> DataGetMaxIndexForExeptionTest()
        {
            yield return new object[] { new MyList<int>() };
        }

        [TestCaseSource(nameof(DataMaxTest))]
        public void Max_WhenInputIsValued_ShouldFindMaxElement(MyList<int> result, int posExpected)
        {
            int posResult = result.GetMax();

            Assert.AreEqual(posExpected, posResult);
        }

        private static IEnumerable<object[]> DataMaxTest()
        {
            yield return new object[] { new MyList<int>() { 1, 2, 10, 4, 5, 6, 7, 8, 9, 6 }, 10 };
            yield return new object[] { new MyList<int>() { 1 }, 1 };
        }
    }
}
