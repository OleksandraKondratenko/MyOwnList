using NUnit.Framework;
using System.Collections.Generic;

namespace MyOwnList.Test.AddTests
{
    public partial class MyList
    {
        //[TestCase(10, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 10 })]
        [TestCase(10, new int[] { }, new int[] { 10 })]
        public void Add_WhenInputIsValid_ShouldAddItToCollection(
           int value, int[] result, int [] expected)
        {
            MyList<int> listExpected = new MyList<int>(expected);

            MyList<int> listResult = new MyList<int>(result);

            listResult.Add(value);

            CollectionAssert.AreEqual(listExpected, listResult);
        }
        
    }
}
