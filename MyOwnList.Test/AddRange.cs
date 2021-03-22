using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test.AddTests
{
    public partial class MyList
    {
        [TestCase(new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, 
            new int[] { 1, 2, 3, 4, 5, 6, 30, 40, 50 })]
        public void AddRange_WhenInputIsValued_ShouldAddItToCollection(
            int [] collection, int [] result, int [] expected)
        {

            MyList<int> listExpected = new MyList<int>(expected);

            MyList<int> listResult = new MyList<int>(result);

            listResult.AddRange(collection);

            CollectionAssert.AreEqual(listExpected, listResult);
        }
    }
}
