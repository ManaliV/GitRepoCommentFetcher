using NUnit.Framework;
using Util;

namespace Utility.Test
{
    public class CircularListTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddStringInCircularListAndVerifyAddedElementInListk()
        {
            CircularLinkList<string> circularList = new CircularLinkList<string>();
            circularList.add("This ");
            circularList.add("is ");
            circularList.add("Test ");
            circularList.add("Time");

            Assert.AreEqual("This is Test Time", circularList.display());
        }
        
    }
}