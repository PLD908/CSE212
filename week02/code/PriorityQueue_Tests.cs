using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue "A" (1), "B" (3), "C" (2), dequeue highest priority
    // Expected Result: "B" (priority 3) is dequeued first, then "C", then "A"
    // Defect(s) Found: Dequeue misses last item and doesn’t remove it
    public void TestPriorityQueue_DifferentPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue "A" (2), "B" (2), "C" (1), dequeue by priority and FIFO
    // Expected Result: "A" (first 2), "B" (second 2), "C" (1)
    // Defect(s) Found: Dequeue doesn’t follow FIFO for equal priorities
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 1);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue
    // Expected Result: Exception with "The queue is empty."
    // Defect(s) Found: No defects found
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }
}