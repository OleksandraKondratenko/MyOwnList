using NUnit.Framework;
using System;
using MyLinkedList;

namespace MyLinkedList.Test
{
    public abstract class AbstractListTest <T> where T: IComparable
    {
        public IList<T> ListClass { get; set; }
        
        [TestCase(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public  void AddStart_WhenInputValue_ShouldAddItToCollection(
           int valueToInsert, int[] inputArray, int[] expectedArray)
        {

            var expectedList = Activator.CreateInstance(ListClass.GetType(), expectedArray);
            var actualList = Activator.CreateInstance(ListClass.GetType(), inputArray);

            
            //actualList.AddStart(valueToInsert);

            //CollectionAssert.AreEqual(expectedList, actualList);
        }

      

        //    [TestCase(-2, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        //[TestCase(25, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        //public override void AddByIndex_WhenInpuIsNotValid_ShouldThrowIndexOutOfRangeException(
        //    int index, int data, int[] result)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(result);

        //    Assert.Throws<IndexOutOfRangeException>(() => actualList.AddByIndex(index, data));
        //}

        //[TestCase(3, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 10, 4, 5, 6, 7, 8, 9, 10 })]
        //[TestCase(0, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        //[TestCase(6, 10, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 10 })]
        //[TestCase(0, 10, new int[] { }, new int[] { 10 })]
        //public override void AddByIndex_WhenInputIsValid_ShouldAddItToCollection(
        //    int index, int valueToInsert, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    actualList.AddByIndex(index, valueToInsert);

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(-3, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        //[TestCase(20, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        //public override void AddRangeByIndex_WhenInpuISValued_ShouldThrowArgumentException(
        //    int index, int[] insertCollection, int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    Assert.Throws<IndexOutOfRangeException>(() => actualList.AddRangeByIndex(index, insertCollection));
        //}

        //[TestCase(3, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 30, 40, 50, 4, 5, 6 })]
        //[TestCase(6, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 30, 40, 50 })]
        //[TestCase(0, new int[] { 30, 40, 50 }, new int[] { }, new int[] { 30, 40, 50 })]
        //public override void AddRangeByIndex_WhenInputIsValued_ShouldAddItToCollection(
        //   int index, int[] collectionToInsert, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    actualList.AddRangeByIndex(index, collectionToInsert);

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 30, 40, 50, 1, 2, 3, 4, 5, 6 })]
        //[TestCase(new int[] { 30, 40, 50 }, new int[] { }, new int[] { 30, 40, 50 })]
        //public override void AddRangeStart_WhenInputIsValued_ShouldAddItToCollection(
        //    int[] collectionToInsert, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    actualList.AddRangeStart(collectionToInsert);

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(new int[] { 90, 10, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 90, 10, 50 })]
        //[TestCase(new int[] { 90, 10, 50 }, new int[] { }, new int[] { 90, 10, 50 })]
        //public override void AddRange_WhenInputIsValued_ShouldAddItToCollection(
        //    int[] collectionToInsert, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    actualList.AddRange(collectionToInsert);

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}


        //[TestCase(10, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 10 })]
        //[TestCase(10, new int[] { }, new int[] { 10 })]
        //public override void Add_WhenInputIsValid_ShouldAddItToCollection(int valueToInsert, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    actualList.Add(valueToInsert);

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(-2, 0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //public override void FindIndexByValue_WhenValidIndexPassed_ShouldReturnIndex(
        //    int value, int expectedIndex, int[] inputArray)
        //{
        //    MyLinkedList<int> list = new MyLinkedList<int>(inputArray);
        //    int actualIndex = list.FindIndexByValue(value);

        //    Assert.AreEqual(expectedIndex, actualIndex);
        //}

        //[TestCase(2, new int[] { 1, 2, 10, 4, 5, 6 })]
        //[TestCase(5, new int[] { 1, 2, 10, 4, 5, 50 })]
        //[TestCase(0, new int[] { 1 })]
        //public override void GetMaxIndex_WhenInputIsValued_ShouldFindIndexMaxElement(
        //     int expectedIndex, int[] inputArray)
        //{
        //    MyLinkedList<int> acualList = new MyLinkedList<int>(inputArray);

        //    int actualIndex = acualList.GetMaxIndex();

        //    Assert.AreEqual(expectedIndex, actualIndex);
        //}

        //[TestCase(new int[] { })]
        //public override void GetMaxIndex_WhenInputIsNotValid_ShouldThrowInvalidOperationExeption(
        //   int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    Assert.Throws<InvalidOperationException>(() => actualList.GetMaxIndex());
        //}

        //[TestCase(10, new int[] { 1, 2, 10, 4, 5, 6, 7, 8, 9, 6 })]
        //[TestCase(50, new int[] { 1, 2, 10, 4, 5, 50 })]
        //[TestCase(1, new int[] { 1 })]
        //public override void GetMax_WhenInputIsValued_ShouldFindMaxElement(
        //    int expectedMax, int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    int actualMax = actualList.GetMax();

        //    Assert.AreEqual(expectedMax, actualMax);
        //}

        //[TestCase(new int[] { })]
        //public void GetMax_WhenInputIsNotValid_ShouldThrowInvalidOperationExeption(
        //   int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    Assert.Throws<InvalidOperationException>(() => actualList.GetMax());
        //}

        //[TestCase(3, new int[] { 1, 2, 10, 0, 4, 5, 6 })]
        //[TestCase(6, new int[] { 2, 2, 10, 3, 4, 5, 1 })]
        //[TestCase(0, new int[] { 1 })]
        //public override void GetMinIndex_WhenInputIsValid_ShouldFindIndexMinElement(
        //    int expectedIndex, int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    int actualIndex = actualList.GetMinIndex();

        //    Assert.AreEqual(expectedIndex, actualIndex);
        //}

        //[TestCase(new int[] { })]
        //public override void GetMinIndex_WhenInputIsNotValid_ShouldThrowInvalidOperationInvalidOperationExeption(
        //    int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    Assert.Throws<InvalidOperationException>(() => actualList.GetMinIndex());
        //}

        //[TestCase(0, new int[] { 1, 2, 10, 0, 4, 5, 6 })]
        //[TestCase(1, new int[] { 2, 2, 10, 3, 4, 5, 1 })]
        //[TestCase(1, new int[] { 1 })]
        //public override void GetMin_WhenInputIsValued_ShouldFindMinElement(
        //int expectedMin, int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    int actualMin = actualList.GetMin();

        //    Assert.AreEqual(expectedMin, actualMin);
        //}

        //[TestCase(new int[] { })]
        //public void GetMin_WhenInputIsNotValid_ShouldThrowInvalidOperationInvalidOperationExeption(
        //    int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    Assert.Throws<InvalidOperationException>(() => actualList.GetMin());
        //}

        //[TestCase(new int[] { -2, 34, 5, 57, 68, 65 }, new int[] { 57, 68, 65, -2, 34, 5 })]
        //[TestCase(new int[] { -2, 34, 5, 1057, 57, 68, 65 }, new int[] { 57, 68, 65, 1057, -2, 34, 5 })]
        //[TestCase(new int[] { }, new int[] { })]
        //public override void HalfReverse_WhenValidListPassed_ShouldReverseListByHalves(
        //    int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);

        //    actualList.HalfReverse();

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(-1, new int[] { -2, 34, 5, 6 })]
        //[TestCase(4, new int[] { -2, 34, 5, 6 })]
        //[TestCase(10, new int[] { -2, 34, 5, 6 })]
        //public override void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowIndexOutOfRangeException(
        //    int index, int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    Assert.Throws<IndexOutOfRangeException>(() => actualList.RemoveByIndex(index));
        //}

        //[TestCase(0, -2, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { 34, 5, 6, 57, 68, 65, -17 })]
        //[TestCase(1, 34, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -2, 5, 6, 57, 68, 65, -17 })]
        //[TestCase(6, 65, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -2, 34, 5, 6, 57, 68, -17 })]
        //[TestCase(7, -17, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -2, 34, 5, 6, 57, 68, 65 })]
        //public override void RemoveByIndex_WhenValidIndexPassed_ShouldDeleteElementByPosition(
        //    int index, int expectedValueToRemove, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);

        //    int actualValueToRemove = actualList.RemoveByIndex(index);

        //    Assert.AreEqual(expectedValueToRemove, actualValueToRemove);
        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(-2, 3, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 34, 5, 6, 57, 68, 65, -17 })]
        //[TestCase(34, 2, new int[] { -2, 34, 5, 6, -2, 57, 34, 68, 65, -2, -17 }, new int[] { -2, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(13, 0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(13, 0, new int[] { }, new int[] { })]
        //public override void RemoveAllByValue_WhenValidIndexPassed_ShouldRemoveFirstValue(
        //    int valueToRemove, int expectedCounter, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);

        //    int actualCounter = actualList.RemoveAllByValue(valueToRemove);

        //    Assert.AreEqual(expectedCounter, actualCounter);
        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(null, new int[] { })]
        //public override void RemoveAllByValue_WhenValidIndexPassed_ShouldThrowNullReferenceException(
        //    int valueToRemove, int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    Assert.Throws<NullReferenceException>(() => actualList.RemoveByIndex(valueToRemove));
        //}

        //[TestCase(-2, 0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(34, 1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(68, 6, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 65, -2, -17 })]
        //[TestCase(-17, 9, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2 })]
        //[TestCase(-10, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(-1, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(10, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(13, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(19, -1, new int[] { }, new int[] { })]
        //public override void RemoveByValueFirst_WhenValidIndexPassed_ShouldRemoveFirstValue(
        //    int valueToRemove, int expectedIndex, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);

        //    int actualIndex = actualList.RemoveByValueFirst(valueToRemove);

        //    Assert.AreEqual(expectedIndex, actualIndex);
        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(4, 3, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, 65, -2, -17 })]
        //[TestCase(0, 7, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 65, -2, -17 })]
        //[TestCase(6, 4, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57 })]
        //[TestCase(0, 10, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { })]
        //public override void RemoveRangeByIndex_WhenValidIndexPassed_ShouldRemoveRangeByIndex(
        //   int index, int quantity, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);

        //    actualList.RemoveRangeByIndex(index, quantity);

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(-3, 3, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(25, 7, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(100, 4, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(-1, 10, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //public  void RemoveRangeByIndex_WhenValidIndexNotPassed_ShouldGenerateIndexOutOfRange(
        //   int index, int quantity, int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    Assert.Throws<IndexOutOfRangeException>(() => actualList.RemoveRangeByIndex(index, quantity));
        //}

        //[TestCase(0, 3, new int[] { })]
        //public void RemoveRangeByIndex_WhenHeadIsNull_ShouldGenerateNullReferenceException(
        //    int index, int quantity, int[] inputArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    Assert.Throws<NullReferenceException>(() => actualList.RemoveRangeByIndex(index, quantity));
        //}

        //[TestCase(0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(4, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 57, 68, 65, -2, -17 })]
        //[TestCase(7, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 65, -2, -17 })]
        //[TestCase(10, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { })]
        //public override void RemoveRangeStart_WhenValidIndexPassed_ShouldRemoveRangeStart(
        //    int quantity, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);

        //    actualList.RemoveRangeStart(quantity);

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        //[TestCase(4, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57 })]
        //[TestCase(7, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5 })]
        //[TestCase(10, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { })]
        //public override void RemoveRange_WhenValidIndexPassed_ShouldRemoveRangeEnd(
        //    int quantity, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);

        //    actualList.RemoveRange(quantity);

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[Test]
        //public override void RemoveStart_WhenListIsEmpty_ShouldThrowNullReferenceException()
        //{
        //    MyLinkedList<int> inputList = new MyLinkedList<int>() { };

        //    Assert.Throws<NullReferenceException>(() => inputList.RemoveStart());
        //}

        //[TestCase(-2, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { 34, 5, 6, 57, 68, 65, -17 })]
        //[TestCase(34, new int[] { 34, 96 }, new int[] { 96 })]
        //[TestCase(-117, new int[] { -117 }, new int[] { })]
        //public override void RemoveStart_WhenListIsValid_ShouldDeleteFirstElement(
        //    int expectedValueToRemove, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);

        //    int actualValueToRemove = actualList.RemoveStart();

        //    Assert.AreEqual(expectedValueToRemove, actualValueToRemove);
        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[Test]
        //public override void Remove_WhenListIsEmpty_ShouldThrowNullReferenceException()
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>();

        //    Assert.Throws<NullReferenceException>(() => actualList.Remove());
        //}

        //[TestCase(-17, new int[] { 2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { 2, 34, 5, 6, 57, 68, 65 })]
        //[TestCase(34, new int[] { 2, 34 }, new int[] { 2 })]
        //[TestCase(2, new int[] { 2 }, new int[] { })]
        //public override void Remove_WhenListIsValid_ShouldDeleteLastElement(
        //    int expectedValueToRemove, int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);

        //    int actualValueToRemove = actualList.Remove();

        //    Assert.AreEqual(expectedValueToRemove, actualValueToRemove);
        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -17, 65, 68, 57, 6, 5, 34, -2 })]
        //[TestCase(new int[] { -2, 34, 5, 6, 57, 68, 65 }, new int[] { 65, 68, 57, 6, 5, 34, -2 })]
        //[TestCase(new int[] { }, new int[] { })]
        //public override void Reverse_WhenValidListPassed_ShouldReverseList(
        //    int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);

        //    actualList.Reverse();

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        //public override void SortDesc_WhenCollectionIsUnsorted_ShouldSortCollectionInDescendingOrder(
        //    int[] inputArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    actualList.Sort(false);

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        //public override void Sort_WhenCollectionIsUnsorted_ShouldSortCollectionInAscendingOrder(
        //    int[] inpuatArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> expectedList = new MyLinkedList<int>(expectedArray);
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inpuatArray);

        //    actualList.Sort();

        //    CollectionAssert.AreEqual(expectedList, actualList);
        //}

        //[TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 })]
        //[TestCase(new int[] { }, new int[] { })]
        //public void ToArray_WhenCollectionIsValied_ShouldConvertToArray(
        //    int[] collectionToArray, int[] expectedArray)
        //{
        //    MyLinkedList<int> listCollection = new MyLinkedList<int>(collectionToArray);

        //    int[] actualArray = listCollection.ToArray();

        //    CollectionAssert.AreEqual(expectedArray, actualArray);
        //}

        //[TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, "6 7 2 1 5 3 4 10 8 9")]
        //public override void ToString_WhenCollectionIsValued_ShouldConvertCollectionToString(
        //    int[] inputArray, string expectedString)
        //{
        //    MyLinkedList<int> actualList = new MyLinkedList<int>(inputArray);

        //    string actualString = actualList.ToString();

        //    Assert.AreEqual(expectedString, actualString);
        //}
    }
}