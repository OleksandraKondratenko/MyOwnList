using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyOwnList.Test.FindMaxMin
{
    class FindMaxElementsAndIndexTests
    {
        [TestCase(new int[] { 1, 2, 10, 4, 5, 6 }, 2)]
        [TestCase(new int[] { 1, 2, 10, 4, 5, 50 }, 5)]
        [TestCase(new int[] { 1 }, 0)]
        public void MaxPos_WhenInputIsValued_ShouldFindIndexMaxElement(int [] result, 
            int IndexExpected)
        {
            MyList<int> listResult = new MyList<int>(result);

            int IndexResult = listResult.GetMaxIndex();

            Assert.AreEqual(IndexExpected, IndexResult);
        }

        
        [TestCase(new int[] { })]
        public void GetMaxIndex_WhenInputIsNotValid_ShouldGenerateInvalidOperationExeption(int [] result)
        {
            MyList<int> listResult = new MyList<int>(result);

            Assert.Throws<InvalidOperationException>(() => listResult.GetMaxIndex());
        }
     
        [TestCase(null)]
        public void GetMaxIndex_WhenInputIsNotValid_ShouldGenerateNullReferenceExeption(int [] result)
        {
            MyList<int> listResult = new MyList<int>(result);
            Assert.Throws<NullReferenceException>(() => listResult.GetMaxIndex());
        }

        [TestCase(new int[] { 1, 2, 10, 4, 5, 6, 7, 8, 9, 6 }, 10)]
        [TestCase(new int[] { 1, 2, 10, 4, 5, 50 }, 50)]
        [TestCase(new int[] { 1 }, 1)]
        public void Max_WhenInputIsValued_ShouldFindMaxElement(int [] result, int posExpected)
        {
            MyList<int> listResult = new MyList<int>(result);
            int posResult = listResult.GetMax();

            Assert.AreEqual(posExpected, posResult);
        }
    }
}
