using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test
{
    class DelEndTest
    {
        [TestCaseSource(nameof(DataDelEndValidTest))]
        public void DelEnd_WhenValidIndexPassed_ShouldDeleteLastElement(
            int expectedElement, MyList<int> inputList, MyList<int> expectedList)
        {
            int actualElement = inputList.DelEnd();

            Assert.AreEqual(expectedElement, actualElement);
            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataDelEndValidTest()
        {
            yield return new object[] { -17, new MyList<int>() { 2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { 2, 34, 5, 6, 57, 68, 65 } };

            yield return new object[] { 34, new MyList<int>() { 2, 34 },
                new MyList<int>() { 2 } };

            yield return new object[] { 2, new MyList<int>() { 2 },
                new MyList<int>() { } };
        }

        [Test]
        public void DelEnd_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException()
        {
            MyList<int> inputList = new MyList<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                inputList.DelEnd());
        }
    }
}
