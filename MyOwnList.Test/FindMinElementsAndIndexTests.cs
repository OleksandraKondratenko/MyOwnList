using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test.FindMaxMin
{
    class FindMinElementsAndIndexTests
    {
        [TestCase(new int[] { 1, 2, 10, 0, 4, 5, 6 }, 3)]
        [TestCase(new int[] { 2, 2, 10, 3, 4, 5, 1 }, 6)]
        [TestCase(new int[] { 1 }, 0)]
        public void GetMinIndex_WhenInputIsValid_ShouldFindIndexMinElement(int [] result, int indexExpected)
        {
            MyList<int> listResult = new MyList<int>(result);

            int indexResult = listResult.GetMinIndex();

            Assert.AreEqual(indexExpected, indexResult);
        }

        [TestCase(new int[] { })]
        public void GetMinIndex_WhenInputIsNotValid_ShouldGenerateInvalidOperationInvalidOperationExeption(int [] result)
        {
            MyList<int> listResult = new MyList<int>(result);

            Assert.Throws<InvalidOperationException>(() => listResult.GetMinIndex());
        }

        [TestCase(null)]
        public void GetMaxIndex_WhenInputIsNotValid_ShouldGenerateNullReferenceExeption(int [] result)
        {
            MyList<int> listResult = new MyList<int>(result);

            Assert.Throws<NullReferenceException>(() => listResult.GetMinIndex());
        }

        [TestCase(new int[] { 1, 2, 10, 0, 4, 5, 6 }, 0)]
        [TestCase(new int[] { 2, 2, 10, 3, 4, 5, 1 }, 1)]
        [TestCase(new int[] { 1 }, 1)]
        public void Min_WhenInputIsValued_ShouldFindMaxElement(int[] result, int intExpected)
        {
            MyList<int> listResult = new MyList<int>(result);

            int posResult = listResult.GetMin();

            Assert.AreEqual(intExpected, posResult);
        }
        private static IEnumerable<object[]> DataMinTest()
        {
            yield return new object[] { new int [] { 1, 2, 10, 0, 4, 5, 6 }, 0 };
            yield return new object[] { new int [] { 2, 2, 10, 3, 4, 5, 1 }, 1 };
            yield return new object[] { new int [] { 1 }, 1 };
        }
    }
}
