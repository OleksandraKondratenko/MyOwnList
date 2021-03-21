using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test
{
    class HalfReverseTest
    {
        [TestCaseSource(nameof(DataHalfReverseValidTest))]
        public void HalfReverse_WhenValidListPassed_ShouldReverseListByHalves(
            MyList<int> inputList, MyList<int> expectedList)
        {
            inputList.HalfReverse();

            CollectionAssert.AreEqual(expectedList, inputList);
        }

        private static IEnumerable<object[]> DataHalfReverseValidTest()
        {
            yield return new object[] { new MyList<int>() { -2, 34, 5, 57, 68, 65},
                new MyList<int>() {57, 68, 65, -2, 34, 5 } };

            yield return new object[] { new MyList<int>() {  -2, 34, 5, 1057, 57, 68, 65 },
                new MyList<int>() { 57, 68, 65, 1057, -2, 34, 5 } };

            yield return new object[] { new MyList<int>() { }, new MyList<int>() { } };
        }

        [TestCase(null)]
        public void HalfReverse_WhenValidListPassed_ShouldReverseListByHalves(
            MyList<int> inputList)
        {
            Assert.Throws<NullReferenceException>(() => inputList.HalfReverse());
        }
    }
}
