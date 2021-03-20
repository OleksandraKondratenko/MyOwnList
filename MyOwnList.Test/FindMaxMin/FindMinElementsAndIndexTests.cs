﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test.FindMaxMin
{
    class FindMinElementsAndIndexTests
    {
        [TestCaseSource(nameof(DataGetMinIndexTest))]
        public void GetMinIndex_WhenInputIsValid_ShouldFindIndexMinElement(MyList<int> result, int posExpected)
        {
            int indexResult = result.GetMinIndex();

            Assert.AreEqual(posExpected, indexResult);
        }

        private static IEnumerable<object[]> DataGetMinIndexTest()
        {
            yield return new object[] { new MyList<int>() { 1, 2, 10, 0, 4, 5, 6 }, 3 };
            yield return new object[] { new MyList<int>() { 1 }, 0};
        }

        [TestCaseSource(nameof(DataGetMinIndexForExeptionTest))]
        public void GetMinIndex_WhenInputIsNotValid_ShouldGenerateExeption(MyList<int> result)
        {
            Assert.Throws<InvalidOperationException>(() => result.GetMinIndex());
        }

        private static IEnumerable<object[]> DataGetMinIndexForExeptionTest()
        {
            yield return new object[] { new MyList<int>() };
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
            yield return new object[] { new MyList<int>() { 1 }, 1 };
        }
    }
}
