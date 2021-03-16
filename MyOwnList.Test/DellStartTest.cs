﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test
{
    class DellStartTest
    {
        [TestCaseSource(nameof(DataDelStarttValidTest))]
        public void DelStart_WhenValidIndexPassed_ShouldDeleteFirstElement(
            int expectedElement, MyList<int> inputList, MyList<int> expectedList)
        {
            int actualElement = inputList.DelStart();

            Assert.AreEqual(expectedElement, actualElement);
            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataDelStarttValidTest()
        {
            yield return new object[] { -2, new MyList<int>() { -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { 34, 5, 6, 57, 68, 65, -17 } };

            yield return new object[] { 34, new MyList<int>() { 34, 96 },
                new MyList<int>() { 96 } };

            yield return new object[] { -117, new MyList<int>() { -117 },
                new MyList<int>() { } };
        }

        [Test]
        public void DelStart_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException()
        {
            MyList<int> inputList = new MyList<int>() { };

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                inputList.DelEnd());
        }
    }
}
