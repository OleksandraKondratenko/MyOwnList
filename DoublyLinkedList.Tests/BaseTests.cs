using NUnit.Framework;
using System;

namespace Lists.Tests
{
    public abstract class BaseTests
    {
        protected IList<int> actualList;
        protected IList<int> expectedList;

        public abstract void Create_Arrays(int[] input, int[] expected);
        public abstract void Create_Arrays(int[] input);
        public abstract void Create_Arrays(int input);

        [TestCase(17)]
        public void CreateWithOneArgument_WhenDataIsValid_ShouldCreateNewInstanse(
            int valueToSet)
        {
            Create_Arrays(valueToSet);

            Assert.AreEqual(1, actualList.Count);
        }

        [TestCase(0, 3, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        [TestCase(4, 7, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        [TestCase(7, -1, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        public void IndexatorGet_WhenValidIndexPassed_ShouldReturnValueByIndex(
            int index, int expectedValue, int[] inputArray)
        {
            Create_Arrays(inputArray);
            int actualValue = actualList[index];

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestCase(-10, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        [TestCase(-1, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        [TestCase(8, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        [TestCase(10, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        [TestCase(16, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        public void IndexatorGet_WhenWrongIndexPassed_ShouldThrowIndexOutOfRangeException(
            int index, int[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<IndexOutOfRangeException>(() => { var t = actualList[index]; });
        }

        [TestCase(0, 117, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 }, new int[] { 117, 4, 5, 6, 7, 88, 2434, -1 })]
        [TestCase(4, -10, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 }, new int[] { 3, 4, 5, 6, -10, 88, 2434, -1 })]
        [TestCase(7, 0, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 }, new int[] { 3, 4, 5, 6, 7, 88, 2434, 0 })]
        public void IndexatorSet_WhenValidIndexPassed_ShouldSetValueByIndex(
            int index, int valueToSet, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);
            actualList[index] = valueToSet;

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(-10, 4, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        [TestCase(-1, 4, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        [TestCase(8, 4, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        [TestCase(10, 4, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        [TestCase(16, 4, new int[] { 3, 4, 5, 6, 7, 88, 2434, -1 })]
        public void IndexatorSet_WhenWrongIndexPassed_ShouldThrowIndexOutOfRangeException(
            int index, int valueToInsert, int[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<IndexOutOfRangeException>(() => { actualList[index] = valueToInsert; });
        }

        [TestCase(new int[] { 4, 67, 8, 9, 9, -17 }, new int[] { })]
        [TestCase(new int[] { }, new int[] { })]
        public void Clear_WhenAllIsOk_ShouldClearTheList(
            int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.Clear();

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void AddStart_WhenInputValue_ShouldAddItToCollection(
           int valueToInsert, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);
            actualList.AddStart(valueToInsert);

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(3, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 1, 2, 3, 10, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(0, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(6, 10, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 10 })]
        [TestCase(0, 10, new int[] { }, new int[] { 10 })]
        public void AddByIndex_WhenInputIsValid_ShouldAddItToCollection(
             int index, int valueToInsert, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.AddByIndex(index, valueToInsert);

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(-2, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(25, 10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        public void AddByIndex_WhenInpuIsNotValid_ShouldThrowIndexOutOfRangeException(
            int index, int data, int[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<IndexOutOfRangeException>(() => actualList.AddByIndex(index, data));
        }

        [TestCase(10, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 10 })]
        [TestCase(-1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, -1 })]
        [TestCase(10, new int[] { }, new int[] { 10 })]
        public void Add_WhenInputIsValid_ShouldAddItToCollection(
            int valueToInsert, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.Add(valueToInsert);

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(0, -2, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { 34, 5, 6, 57, 68, 65, -17 })]
        [TestCase(1, 34, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -2, 5, 6, 57, 68, 65, -17 })]
        [TestCase(6, 65, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -2, 34, 5, 6, 57, 68, -17 })]
        [TestCase(7, -17, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -2, 34, 5, 6, 57, 68, 65 })]
        public void RemoveByIndex_WhenValidIndexPassed_ShouldDeleteElementByPosition(
            int index, int expectedValueToRemove, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            int actualValueToRemove = actualList.RemoveByIndex(index);

            Assert.AreEqual(expectedValueToRemove, actualValueToRemove);
            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(-1, new int[] { -2, 34, 5, 6 })]
        [TestCase(4, new int[] { -2, 34, 5, 6 })]
        [TestCase(10, new int[] { -2, 34, 5, 6 })]
        public void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowIndexOutOfRangeException(
            int index, int[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<IndexOutOfRangeException>(() => actualList.RemoveByIndex(index));
        }

        [TestCase(-2, new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { 34, 5, 6, 57, 68, 65, -17 })]
        [TestCase(34, new int[] { 34, 96 }, new int[] { 96 })]
        [TestCase(-117, new int[] { -117 }, new int[] { })]
        public void RemoveStart_WhenListIsValid_ShouldDeleteFirstElement(
            int expectedValueToRemove, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            int actualValueToRemove = actualList.RemoveStart();

            Assert.AreEqual(expectedValueToRemove, actualValueToRemove);
            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(-17, new int[] { 2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { 2, 34, 5, 6, 57, 68, 65 })]
        [TestCase(34, new int[] { 2, 34 }, new int[] { 2 })]
        [TestCase(2, new int[] { 2 }, new int[] { })]
        public void Remove_WhenListIsValid_ShouldDeleteLastElement(
            int expectedValueToRemove, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            int actualValueToRemove = actualList.Remove();

            Assert.AreEqual(expectedValueToRemove, actualValueToRemove);
            Assert.AreEqual(expectedList, actualList);
        }

        [Test]
        public void RemoveStart_WhenListIsEmpty_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => actualList.RemoveStart());
        }

        [Test]
        public void Remove_WhenListIsEmpty_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => actualList.Remove());
        }

        [TestCase(3, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 30, 40, 50, 4, 5, 6 })]
        [TestCase(6, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 30, 40, 50 })]
        [TestCase(0, new int[] { 30, 40, 50 }, new int[] { }, new int[] { 30, 40, 50 })]
        [TestCase(0, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 30, 40, 50, 1, 2, 3, 4, 5, 6 })]
        public void AddRangeByIndex_WhenInputIsValued_ShouldAddItToCollection(
          int index, int[] collectionToInsert, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.AddRangeByIndex(index, collectionToInsert);

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(-3, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(20, new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        public void AddRangeByIndex_WhenInpuISValued_ShouldThrowArgumentException(
            int index, int[] insertCollection, int[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<IndexOutOfRangeException>(() => actualList.AddRangeByIndex(index, insertCollection));
        }

        [TestCase(new int[] { 30, 40, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 30, 40, 50, 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { 30, 40, 50 }, new int[] { }, new int[] { 30, 40, 50 })]
        public void AddRangeStart_WhenInputIsValued_ShouldAddItToCollection(
            int[] collectionToInsert, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.AddRangeStart(collectionToInsert);

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(new int[] { 90, 10, 50 }, new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 90, 10, 50 })]
        [TestCase(new int[] { 90, 10, 50 }, new int[] { }, new int[] { 90, 10, 50 })]
        public void AddRange_WhenInputIsValued_ShouldAddItToCollection(
            int[] collectionToInsert, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.AddRange(collectionToInsert);

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(4, 3, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, 65, -2, -17 })]
        [TestCase(0, 7, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 65, -2, -17 })]
        [TestCase(6, 4, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57 })]
        [TestCase(0, 10, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { })]
        public void RemoveRangeByIndex_WhenValidIndexPassed_ShouldRemoveRangeByIndex(
                  int index, int quantity, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.RemoveRangeByIndex(index, quantity);

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(-3, 3, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(25, 7, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(100, 4, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(-1, 10, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        public void RemoveRangeByIndex_WhenValidIndexNotPassed_ShouldGenerateIndexOutOfRange(
           int index, int quantity, int[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<IndexOutOfRangeException>(() => actualList.RemoveRangeByIndex(index, quantity));
        }

        [TestCase(0, 3, new int[] { })]
        public void RemoveRangeByIndex_WhenHeadIsNull_ShouldGenerateNullReferenceException(
            int index, int quantity, int[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<NullReferenceException>(() => actualList.RemoveRangeByIndex(index, quantity));
        }

        [TestCase(0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(4, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 57, 68, 65, -2, -17 })]
        [TestCase(7, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 65, -2, -17 })]
        [TestCase(10, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { })]
        public void RemoveRangeStart_WhenValidIndexPassed_ShouldRemoveRangeStart(
           int quantity, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.RemoveRangeStart(quantity);

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(4, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57 })]
        [TestCase(7, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5 })]
        [TestCase(10, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { })]
        public void RemoveRange_WhenValidIndexPassed_ShouldRemoveRangeEnd(
            int quantity, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.RemoveRange(quantity);

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(-2, 0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(34, 1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(68, 6, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 65, -2, -17 })]
        [TestCase(-17, 9, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2 })]
        [TestCase(-10, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(-1, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(10, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(13, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(19, -1, new int[] { }, new int[] { })]
        public void RemoveByValueFirst_WhenValidIndexPassed_ShouldRemoveFirstValue(
           int valueToRemove, int expectedIndex, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            int actualIndex = actualList.RemoveByValueFirst(valueToRemove);

            Assert.AreEqual(expectedIndex, actualIndex);
            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(-2, 3, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { 34, 5, 6, 57, 68, 65, -17 })]
        [TestCase(34, 2, new int[] { -2, 34, 5, 6, -2, 57, 34, 68, 65, -2, -17 }, new int[] { -2, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(13, 0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 }, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(13, 0, new int[] { }, new int[] { })]
        public void RemoveAllByValue_WhenValidIndexPassed_ShouldRemoveFirstValue(
            int valueToRemove, int expectedCounter, int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            int actualCounter = actualList.RemoveByValueAll(valueToRemove);

            Assert.AreEqual(expectedCounter, actualCounter);
            Assert.AreEqual(expectedList, actualList);
        }


        [TestCase(-2, 0, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(68, 6, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        [TestCase(100, -1, new int[] { -2, 34, 5, 6, -2, 57, 68, 65, -2, -17 })]
        public void FindIndexByValue_WhenValidIndexPassed_ShouldReturnIndex(
            int value, int expectedIndex, int[] inputArray)
        {
            Create_Arrays(inputArray);
            int actualIndex = actualList.FindIndexByValue(value);

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase(2, new int[] { 1, 2, 10, 4, 5, 6 })]
        [TestCase(5, new int[] { 1, 2, 10, 4, 5, 50 })]
        [TestCase(0, new int[] { 1 })]
        public void GetMaxIndex_WhenInputIsValued_ShouldFindIndexMaxElement(
           int expectedIndex, int[] inputArray)
        {
            Create_Arrays(inputArray);

            int actualIndex = actualList.GetMaxIndex();

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase(new int[] { })]
        public void GetMaxIndex_WhenInputIsNotValid_ShouldThrowInvalidOperationExeption(
           int[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<InvalidOperationException>(() => actualList.GetMaxIndex());
        }

        [TestCase(10, new int[] { 1, 2, 10, 4, 5, 6, 7, 8, 9, 6 })]
        [TestCase(50, new int[] { 1, 2, 10, 4, 5, 50 })]
        [TestCase(1, new int[] { 1 })]
        public void GetMax_WhenInputIsValued_ShouldFindMaxElement(
            int expectedMax, int[] inputArray)
        {
            Create_Arrays(inputArray);

            int actualMax = actualList.GetMax();

            Assert.AreEqual(expectedMax, actualMax);
        }

        [TestCase(new int[] { })]
        public void GetMax_WhenInputIsNotValid_ShouldThrowInvalidOperationExeption(
           int[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<InvalidOperationException>(() => actualList.GetMax());
        }

        [TestCase(3, new int[] { 1, 2, 10, 0, 4, 5, 6 })]
        [TestCase(6, new int[] { 2, 2, 10, 3, 4, 5, 1 })]
        [TestCase(0, new int[] { 1 })]
        public void GetMinIndex_WhenInputIsValid_ShouldFindIndexMinElement(
            int expectedIndex, int[] inputArray)
        {
            Create_Arrays(inputArray);

            int actualIndex = actualList.GetMinIndex();

            Assert.AreEqual(expectedIndex, actualIndex);
        }

        [TestCase(new int[] { })]
        public void GetMinIndex_WhenInputIsNotValid_ShouldThrowInvalidOperationInvalidOperationExeption(
            int[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<InvalidOperationException>(() => actualList.GetMinIndex());
        }

        [TestCase(0, new int[] { 1, 2, 10, 0, 4, 5, 6 })]
        [TestCase(1, new int[] { 2, 2, 10, 3, 4, 5, 1 })]
        [TestCase(1, new int[] { 1 })]
        public void GetMin_WhenInputIsValued_ShouldFindMinElement(
        int expectedMin, int[] inputArray)
        {
            Create_Arrays(inputArray);

            int actualMin = actualList.GetMin();

            Assert.AreEqual(expectedMin, actualMin);
        }

        [TestCase(new int[] { })]
        public void GetMin_WhenInputIsNotValid_ShouldThrowInvalidOperationInvalidOperationExeption(
            int[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<InvalidOperationException>(() => actualList.GetMin());
        }

        [TestCase(new int[] { -2, 34, 5, 6, 57, 68, 65, -17 }, new int[] { -17, 65, 68, 57, 6, 5, 34, -2 })]
        [TestCase(new int[] { -2, 34, 5, 6, 57, 68, 65 }, new int[] { 65, 68, 57, 6, 5, 34, -2 })]
        [TestCase(new int[] { }, new int[] { })]
        public void Reverse_WhenValidListPassed_ShouldReverseList(
           int[] inputArray, int[] expectedArray)
        {

            Create_Arrays(inputArray, expectedArray);
            actualList.Reverse();

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(new int[] { -2, 34, 5, 57, 68, 65 }, new int[] { 57, 68, 65, -2, 34, 5 })]
        [TestCase(new int[] { -2, 34, 5, 1057, 57, 68, 65 }, new int[] { 57, 68, 65, 1057, -2, 34, 5 })]
        [TestCase(new int[] { }, new int[] { })]
        public void HalfReverse_WhenValidListPassed_ShouldReverseListByHalves(
            int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.HalfReverse();

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 })]
        [TestCase(new int[] { }, new int[] { })]
        public void ToArray_WhenCollectionIsValied_ShouldConvertToArray(
           int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray);

            int[] actualArray = actualList.ToArray();

            Assert.AreEqual(expectedArray, actualArray);
        }

        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, "6 7 2 1 5 3 4 10 8 9")]
        [TestCase(new int[] { }, "")]
        public void ToString_WhenCollectionIsValued_ShouldConvertCollectionToString(
            int[] inputArray, string expectedString)
        {
            Create_Arrays(inputArray);

            string actualString = actualList.ToString();

            Assert.AreEqual(expectedString, actualString);
        }

        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void SortDesc_WhenCollectionIsUnsorted_ShouldSortCollectionInDescendingOrder(
          int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.Sort(false);

            Assert.AreEqual(expectedList, actualList);
        }

        [TestCase(new int[] { 6, 7, 2, 1, 5, 3, 4, 10, 8, 9 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { }, new int[] {})]
        public void Sort_WhenCollectionIsUnsorted_ShouldSortCollectionInAscendingOrder(
            int[] inputArray, int[] expectedArray)
        {
            Create_Arrays(inputArray, expectedArray);

            actualList.Sort();

            Assert.AreEqual(expectedList, actualList);
        }
    }
}