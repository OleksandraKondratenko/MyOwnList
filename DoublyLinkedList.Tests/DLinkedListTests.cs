using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Lists.Tests
{
    public class DLinkedListTests : BaseTests
    {
        IList<string> actualStringList;

        public override void Create_Arrays(int[] input, int[] expected)
        {
            actualList = MyDoublyLinkedList<int>.Create(input);
            expectedList = MyDoublyLinkedList<int>.Create(expected);
        }

        public override void Create_Arrays(int[] input)
        {
            actualList = MyDoublyLinkedList<int>.Create(input);
        }
        
        public override void Create_Arrays(int input)
        {
            actualList = MyDoublyLinkedList<int>.Create(input);
        }

        public void Create_Arrays(string[] input)
        {
            actualStringList = MyDoublyLinkedList<string>.Create(input);
        }

        [SetUp]
        public void Setup()
        {
            actualList = new MyDoublyLinkedList<int>();
            expectedList = new MyDoublyLinkedList<int>();
        }

        [TestCase(2, null, new string[] { "45", "434", "ass" })]
        public void IndextorSet_WhenWrongIndexPassed_ShouldThrowNullReferenceException(
            int index, string valueToSet, string[] inputArray)
        {
            Create_Arrays(inputArray);

            Assert.Throws<NullReferenceException>(() => { actualStringList[index] = valueToSet; });
        }

        [TestCase(null)]
        public void CreateWithOneArgument_WhenDataIsNull_ShouldThrowArgumentNullException(
            string valueToSet)
        {
            Assert.Throws<ArgumentNullException>(() => { MyDoublyLinkedList<string>.Create(valueToSet); });
        }

        [TestCase(null)]
        public void CreateWithCollection_WhenDataIsNull_ShouldThrowArgumentNullException(
            IEnumerable<string> valueToSet)
        {
            Assert.Throws<ArgumentNullException>(() => { MyDoublyLinkedList<string>.Create(valueToSet); });
        }
    }
}
