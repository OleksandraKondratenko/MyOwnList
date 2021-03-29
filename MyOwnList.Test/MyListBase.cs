namespace MyOwnList.Test
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
        public abstract void GetMaxIndex_WhenInputIsNotValid_ShouldThrowInvalidOperationExeption(int[] inputArray);
        public abstract void GetMaxIndex_WhenInputIsNotValid_ShouldThrowNullReferenceExeption(int[] inputArray);
        public abstract void GetMaxIndex_WhenInputIsValued_ShouldFindIndexMaxElement(int expectedIndex, int[] inputArray);
        public abstract void GetMax_WhenInputIsValued_ShouldFindMaxElement(int expectedMax, int[] inputArray);
        public abstract void GetMinIndex_WhenInputIsNotValid_ShouldThrowInvalidOperationInvalidOperationExeption(int[] inputArray);
        public abstract void GetMinIndex_WhenInputIsNotValid_ShouldThrowNullReferenceExeption(int[] inputArray);
        public abstract void GetMinIndex_WhenInputIsValid_ShouldFindIndexMinElement(int expectedIndex, int[] inputArray);
        public abstract void GetMin_WhenInputIsValued_ShouldFindMaxElement(int expectedMin, int[] inputArray);
        public abstract void HalfReverse_WhenValidListPassed_ShouldReverseListByHalves(int[] inputArray, int[] expectedArray);
        public abstract void HalfReverse_WhenValidListPassed_ShouldReverseListByHalves(int[] inputArray);
        public abstract void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException(int index, int[] inputArray);
        public abstract void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowIndexOutOfRangeException(int index, int quantity, int[] inputArray);
        public abstract void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowInvalidOperationException(int index, int quantity, int[] inputArray);
        public abstract void RemoveByIndex_WhenIndexOutOfRange_ShouldThrowInvalidOperationException(int quantity, int[] inputArray);
        public abstract void RemoveByIndex_WhenValidIndexPassed_ShouldDeleteElementByPosition(int index, int expectedValueToRemove, int[] inputArray, int[] expectedArray);
        public abstract void RemoveByValueAll_WhenValidIndexPassed_ShouldRemoveFirstValue(int valueToRemove, int expectedCounter, int[] inputArray, int[] expectedArray);
        public abstract void RemoveByValueFirst_WhenValidIndexPassed_ShouldRemoveFirstValue(int valueToRemove, int expectedIndex, int[] inputArray, int[] expectedArray);
        public abstract void RemoveRangeByIndex_WhenValidIndexPassed_ShouldRemoveRangeByIndex(int index, int quantity, int[] inputArray, int[] expectedArray);
        public abstract void RemoveRangeStart_WhenValidIndexPassed_ShouldRemoveRangeStart(int quantity, int[] inputArray, int[] expectedArray);
        public abstract void RemoveStart_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException();
        public abstract void RemoveStart_WhenValidIndexPassed_ShouldDeleteFirstElement(int expectedValueToRemove, int[] inputArray, int[] expectedArray);
        public abstract void Remove_WhenIndexOutOfRange_ShouldThrowArgumentOutOfRangeException();
        public abstract void Remove_WhenValidIndexPassed_ShouldDeleteLastElement(int expectedValueToRemove, int[] inputArray, int[] expectedArray);
        public abstract void Reverse_WhenValidListPassed_ShouldReverseList(int[] inputArray, int[] expectedArray);
        public abstract void SortDesc_WhenCollectionIsUnsorted_ShouldSortCollectionInDescendingOrder(int[] inputArray, int[] expectedArray);
        public abstract void Sort_WhenCollectionIsUnsorted_ShouldSortCollectionInAscendingOrder(int[] inpuatArray, int[] expectedArray);
        public abstract void ToString_WhenCollectionIsValued_ShouldConvertCollectionToString(int[] inputArray, string expectedString);
    }
}