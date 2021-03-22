﻿using NUnit.Framework;
using System;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(-2, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { 34, 5, 6, 57, 68, 65, -17 })]
        [TestCase(34, new int[] { 34, 96 }, new int[] { 96 })]
        [TestCase(-117, new int[] { -117 }, new int[] { })]
        public void RemoveStart_WhenValidIndexPassed_ShouldDeleteFirstElement(
            int expectedElement, int[] inputArray, int[] expectedArray)
        {
            MyList<int> inputList = new MyList<int>(inputArray);
            MyList<int> expectedList = new MyList<int>(expectedArray);

            int actualElement = inputList.RemoveStart();

            Assert.AreEqual(expectedElement, actualElement);
            CollectionAssert.AreEqual(expectedList, inputList);
        }

        [Test]
        public void RemoveStart_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException()
        {
            MyList<int> inputList = new MyList<int>() { };

            Assert.Throws<InvalidOperationException>(() =>
                inputList.Remove());
        }
    }
}
