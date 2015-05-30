using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlWork1;

namespace Tests.ControlWork1
{
    [TestClass]
    public class QueuePriorityIntTest
    {
        private QueuePriority<int> queue;

        [TestInitialize]
        public void Initialize()
        {
            queue = new QueuePriority<int>();
        }

        [TestMethod]
        public void EnqueueTwiceDequeueTwiceTest()
        {
            queue.Enqueue(5, 1);
            queue.Enqueue(6, 2);
            Assert.AreEqual(6, queue.Dequeue());
            Assert.AreEqual(5, queue.Dequeue());
        }

        [TestMethod]
        [ExpectedException(typeof(EmptyQueueException))]
        public void DequeueEmpty()
        {
            queue.Dequeue();
        }
    }
}
