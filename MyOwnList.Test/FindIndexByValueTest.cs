using NUnit.Framework;

namespace MyOwnList.Test
{
    public partial class MyList
    {
        [TestCase(-2, 0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        public void FindIndexByValue_WhenValidIndexPassed_ShouldReturnIndex(
            int valueToInsert, int expectedIndex, int [] inputArray)
        {
            MyList<int> list = new MyList<int>(inputArray);
            int actualIndex = list.FindIndexByValue(valueToInsert);

            Assert.AreEqual(expectedIndex, actualIndex);
        }
    }
}
