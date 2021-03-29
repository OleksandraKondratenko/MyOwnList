namespace MyLinkedList.Test
{
    public abstract class MyListBase
    {
        public abstract void AddByIndex_WhenInpuIsNotValid_ShouldThrowIndexOutOfRangeException(int index, int value, int[] result);
        public abstract void AddByIndex_WhenInputIsValid_ShouldAddItToCollection(int index, int valueToInsert, int[] inputArray, int[] expectedArray);
        public abstract void AddRangeByIndex_WhenInpuISValued_ShouldThrowArgumentException(int index, int[] insertCollection, int[] inputArray);
        public abstract void AddRangeByIndex_WhenInputIsValued_ShouldAddItToCollection(int index, int[] collectionToInsert, int[] inputArray, int[] expectedArray);
        public abstract void AddRangeStart_WhenInputIsValued_ShouldAddItToCollection(int[] collectionToInsert, int[] inputArray, int[] expectedArray);
        public abstract void AddRange_WhenInputIsValued_ShouldAddItToCollection(int[] collectionToInsert, int[] inputArray, int[] expectedArray);
        public abstract void Add_WhenInputIsValid_ShouldAddItToCollection(int valueToInsert, int[] inputArray, int[] expectedArray);
        public abstract void FindIndexByValue_WhenValidIndexPassed_ShouldReturnIndex(int valueToInsert, int expectedIndex, int[] inputArray);
        public abstract void GetMaxIndex_WhenInputIsNotValid_ShouldThrowInvalidOperationExeption(int[] inputArray);
        public abstract void GetMaxIndex_WhenInputIsValued_ShouldFindIndexMaxElement(int expectedIndex, int[] inputArray);
        public abstract void GetMax_WhenInputIsValued_ShouldFindMaxElement(int expectedMax, int[] inputArray);
        public abstract void GetMinIndex_WhenInputIsNotValid_ShouldThrowInvalidOperationInvalidOperationExeption(int[] inputArray);
        public abstract void GetMinIndex_WhenInputIsValid_ShouldFindIndexMinElement(int expectedIndex, int[] inputArray);
        public abstract void GetMin_WhenInputIsValued_ShouldFindMinElement(int expectedMin, int[] inputArray);
        public abstract void HalfReverse_WhenValidListPassed_ShouldReverseListByHalves(int[] inputArray, int[] expectedArray);
        public abstract void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowIndexOutOfRangeException(int index, int[] inputArray);
        public abstract void RemoveByIndex_WhenValidIndexPassed_ShouldDeleteElementByPosition(int index, int expectedValueToRemove, int[] inputArray, int[] expectedArray);
        public abstract void RemoveAllByValue_WhenValidIndexPassed_ShouldRemoveFirstValue(int valueToRemove, int expectedCounter, int[] inputArray, int[] expectedArray);
        public abstract void RemoveAllByValue_WhenValidIndexPassed_ShouldThrowNullReferenceException(int valueToRemove, int[] inputArray);
        public abstract void RemoveByValueFirst_WhenValidIndexPassed_ShouldRemoveFirstValue(int valueToRemove, int expectedIndex, int[] inputArray, int[] expectedArray);
        public abstract void RemoveRangeByIndex_WhenValidIndexPassed_ShouldRemoveRangeByIndex(int index, int quantity, int[] inputArray, int[] expectedArray);
        public abstract void RemoveRangeStart_WhenValidIndexPassed_ShouldRemoveRangeStart(int quantity, int[] inputArray, int[] expectedArray);
        public abstract void RemoveRange_WhenValidIndexPassed_ShouldRemoveRangeEnd(int quantity, int[] inputArray, int[] expectedArray);
        public abstract void RemoveStart_WhenListIsEmpty_ShouldThrowNullReferenceException();
        public abstract void RemoveStart_WhenListIsValid_ShouldDeleteFirstElement(int expectedValueToRemove, int[] inputArray, int[] expectedArray);
        public abstract void Remove_WhenListIsEmpty_ShouldThrowNullReferenceException();
        public abstract void Remove_WhenListIsValid_ShouldDeleteLastElement(int expectedValueToRemove, int[] inputArray, int[] expectedArray);
        public abstract void Reverse_WhenValidListPassed_ShouldReverseList(int[] inputArray, int[] expectedArray);
        public abstract void SortDesc_WhenCollectionIsUnsorted_ShouldSortCollectionInDescendingOrder(int[] inputArray, int[] expectedArray);
        public abstract void Sort_WhenCollectionIsUnsorted_ShouldSortCollectionInAscendingOrder(int[] inpuatArray, int[] expectedArray);
        public abstract void ToString_WhenCollectionIsValued_ShouldConvertCollectionToString(int[] inputArray, string expectedString);
    }
}