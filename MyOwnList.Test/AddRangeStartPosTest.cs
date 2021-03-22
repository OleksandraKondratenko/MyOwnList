using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test.AddTests
{
    public partial class MyList
    {
        [TestCase(new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 },
           new int[] { 30, 40, 50, 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 30, 40, 50 }, new int[] { }, new int[] { 30, 40, 50 })]
        public void AddRangeStart_WhenInputIsValued_ShouldAddItToCollection(
           int [] collection, int [] result, int [] expected)
        {
            MyList<int> listExpected = new MyList<int>(expected);

            MyList<int> listResult = new MyList<int>(result);

            listResult.AddRangeStart(collection);

            CollectionAssert.AreEqual(listExpected, listResult);
        }
    }
}
