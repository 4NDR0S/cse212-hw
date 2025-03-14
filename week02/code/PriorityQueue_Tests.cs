using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: enqueue an element in an empty queue and dequeue it.
    // Expected Result: the element should be returned when dequeued.
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        // Assert.Fail("Implement the test case and then remove this.");
        priorityQueue.Enqueue("Item1", 1);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result);
    }

    [TestMethod]
    // Scenario: enqueue multiple elements with different priorities and dequeue the highest priority element.
    // Expected Result: the element with the highest priority should be dequeued.
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        // Assert.Fail("Implement the test case and then remove this.");
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 3);
        priorityQueue.Enqueue("Item3", 2);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item2", result);  // "Item2" has the most prio
    }

    // Add more test cases as needed below.

     [TestMethod]
    // Scenario: enqueue multiple elements with the same priority and dequeue the first one.
    // Expected Result: the first element with the same priority should be dequeued.
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 2);
        priorityQueue.Enqueue("Item3", 2);
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result);  // El primero en la cola
    }

    [TestMethod]
    // Scenario: try to remove from an empty queue.
    // Expected Result: an InvalidOperationException should be thrown.
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

}