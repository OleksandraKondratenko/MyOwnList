using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test
{
    class ReverseTest
    {
        [TestCaseSource(nameof(DataReverseValidTest))]
        public void Reverse_WhenValidListPassed_ShouldReverseList(
            MyList<int> inputList, MyList<int> expectedList)
        {
            inputList.Reverse();

            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataReverseValidTest()
        {
            yield return new object[] { new MyList<int>() { -2, 34, 5, 6, 57, 68, 65, -17 },
                new MyList<int>() { -17, 65, 68, 57, 6, 5, 34, -2} };

            yield return new object[] { new MyList<int>() {  -2, 34, 5, 6, 57, 68, 65 },
                new MyList<int>() { 65, 68, 57, 6, 5, 34, -2 } };

            yield return new object[] { new MyList<int>() { }, new MyList<int>() { } };
        }
    }
}
