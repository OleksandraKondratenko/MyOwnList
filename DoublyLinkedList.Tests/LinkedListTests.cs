using NUnit.Framework;
using Lists;
using System;
using System.Collections.Generic;

namespace Lists.Tests
{
    public class LinkedListTests : BaseTests
    {
        IList<string> actualStringList;

        public override void Create_Arrays(int[] input, int[] expected)
        {
            actualList = MyLinkedList<int>.Create(input);
            expectedList = MyLinkedList<int>.Create(expected);
        }

        public override void Create_Arrays(int[] input)
        {
            actualList = MyLinkedList<int>.Create(input);
        }
        
        public override void Create_Arrays(int input)
        {
            actualList = MyLinkedList<int>.Create(input);
        }

        public void Create_Arrays(string[] input)
        {
            actualStringList = MyLinkedList<string>.Create(input);
        }

        [SetUp]
        public void Setup()
        {
            actualList = new MyLinkedList<int>();
            expectedList = new MyLinkedList<int>();
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
            Assert.Throws<ArgumentNullException>(() => { MyLinkedList<string>.Create(valueToSet); });
        }

        [TestCase(null)]
        public void CreateWithCollection_WhenDataIsNull_ShouldThrowArgumentNullException(
            IEnumerable<string> valueToSet)
        {
            Assert.Throws<ArgumentNullException>(() => { MyLinkedList<string>.Create(valueToSet); });
        }
    }
}
