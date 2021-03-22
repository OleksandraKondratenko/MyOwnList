﻿using NUnit.Framework;

namespace MyOwnList.Test
{
    class AddStartTest
    {
        [TestCase(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void AddStart_WhenInputValue_ShouldAddItToCollection(
            int valueToInsert, int[] inputArray, int[] expectedArray)
        {
            MyList<int> expectedList = new MyList<int>(expectedArray);
            MyList<int> actualList = new MyList<int>(inputArray);

            actualList.AddStart(valueToInsert);

            CollectionAssert.AreEqual(expectedList, actualList);
        }
    }
}
