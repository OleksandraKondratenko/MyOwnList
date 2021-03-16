using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test
{
    public class Tests
    {
        [TestCaseSource(nameof(DataDelEndTest))]
        public void DelEnd_WhenValidIndexPassed_ShouldDeleteLastElement(
            int expectedElement, MyList<int> inputList, MyList<int> expectedList)
        {
            int actualElement = inputList.DelEnd();
            MyList<int> actualList = inputList;

            Assert.AreEqual(expectedElement, actualElement);
            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataDelEndTest()
        {
            yield return new object[] { -17, new MyList<int>() { 2, 34, 5, 6, 57, 68, 65, -17 }, 
                new MyList<int>() { 2, 34, 5, 6, 57, 68, 65 } };
        }

        public void DelEnd_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException(
            )
        {

        }
    }
}