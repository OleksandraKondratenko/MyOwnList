using NUnit.Framework;
using System;

namespace Lists.Tests
{
    public class ListTests : BaseTests
    {
        public override void Create_Arrays(int[] input, int[] expected)
        {
            actualList = MyList<int>.Create(input);
            expectedList = MyList<int>.Create(expected);
        }

        public override void Create_Arrays(int[] input)
        {
            actualList = MyList<int>.Create(input);
        }
        
        public override void Create_Arrays(int input)
        {
            actualList = new MyList<int>(input);
        }

        [SetUp]
        public void Setup()
        {
            actualList = new MyList<int>();
            expectedList = new MyList<int>();
        }

        [TestCase(null)]
        public void CreateWithOneArgument_WhenDataIsValid_ShouldCreateNewInstanse(
            int[] inputArray)
        {
            Assert.Throws<ArgumentNullException>(() => { MyList<int>.Create(inputArray); });
        }

        [Test]
        public void CreateWithOneArgument_WhenDataIsNull_ShouldThrowArgumentNullException()
        {
            MyList<int> inputArray = MyList<int>.Create(new int[] { 2, 3, 4, 5 });
            MyList<int> expectedArray = MyList<int>.Create(inputArray);

            Assert.AreEqual(expectedArray, MyList<int>.Create(inputArray));
        }

        [Test]
        public void CreateWithCollection_WhenDataIsNull_ShouldThrowArgumentNullException()
        {
            MyList<int> inputArray = null;

            Assert.Throws<ArgumentNullException>(() => { MyList<int>.Create(inputArray); });
        }

        [TestCase(457)]
        public void MyList_WhenValueIsValid_ShpouldCreateInstense(
            int inputValue)
        {
            expectedList = new MyList<int>(inputValue);

            Assert.AreEqual(expectedList, new int[] { inputValue });
        }
    }
}
