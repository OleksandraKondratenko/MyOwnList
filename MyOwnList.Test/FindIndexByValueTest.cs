using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyOwnList.Test
{
    class FindIndexByValueTest
    {
        [TestCase(-2, 0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        public void FindIndexByValue_WhenValidIndexPassed_ShouldReturnIndex(
            int value, int expectedIndex, int [] inputList)
        {
            MyList<int> list = new MyList<int>(inputList);
            int actualIndex = list.FindIndexByValue(value);

            Assert.AreEqual(expectedIndex, actualIndex);
        }
    }
}
