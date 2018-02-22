using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace stack_test
{
    [TestClass]
    public class FSUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            stack.Stack<string> stack = new stack.Stack<string>();
            stack.Push("Test");
            Assert.AreEqual(stack.Pop, "Test");
        }
    }
}
