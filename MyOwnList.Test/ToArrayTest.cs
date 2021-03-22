using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test
{
    class ToArrayTest
    {
        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 },
                new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 })]
        public void ToArray_WhenCollectionIsValied_ShouldConvertToArray(
           int [] collection, int[] expected)
        {
            MyList<int> listCollection = new MyList<int>(collection);

            int[] result = listCollection.ToArray();

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
