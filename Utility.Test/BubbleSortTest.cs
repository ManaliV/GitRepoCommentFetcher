using NUnit.Framework;

namespace Utility.Test
{
    public class BubbleSortTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SortSortedList()
        {
            BubbleSort<string> bubbleSort = new BubbleSort<string>();
            Assert.AreEqual(new string[] { "ABC", "DEF", "GHI" }, bubbleSort.Sort(new string[] {"ABC","DEF","GHI" }));
        }
        
        [Test]
        public void SortDescendingOrderedList()
        {
            BubbleSort<string> bubbleSort = new BubbleSort<string>();
            Assert.AreEqual(new string[] { "ABC", "DEF", "GHI" }, bubbleSort.Sort(new string[] { "GHI", "DEF", "ABC" }));
        }

        [Test]
        public void SortListofString()
        {
            BubbleSort<string> bubbleSort = new BubbleSort<string>();
            Assert.AreEqual(new string[] { "AA", "AB", "BA" }, bubbleSort.Sort(new string[] { "BA", "AB", "AA" }));
        }
    }
}