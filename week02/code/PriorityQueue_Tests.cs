using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items with different priorities (low, high, medium) to ensure 
    // the highest priority is removed. This also tests if the loop checks the very last item.
    // Expected Result: The item with priority 10 should be removed first.
    // Defect(s) Found: The loop in Dequeue stopped at `_queue.Count - 1`, failing to check the last item.
    // Also, the item was not actually removed from the list, causing the queue to never empty.
    public void TestPriorityQueue_HighestPriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("High", 10); // Located at the end to test loop limit
        priorityQueue.Enqueue("Medium", 5);

        // First dequeue should be "High" (10)
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("High", result, "Did not get the highest priority item.");
    }

    [TestMethod]
    // Scenario: Add multiple items with the SAME highest priority.
    // Expected Result: Following FIFO, the first item added (Item1) should be removed first.
    // Defect(s) Found: The comparison used `>=` instead of `>`, which updated the index 
    // even for equal priorities, selecting the LAST item instead of the FIRST (LIFO instead of FIFO).
    public void TestPriorityQueue_FIFO_Tie()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 5);
        priorityQueue.Enqueue("Item2", 5);
        priorityQueue.Enqueue("Item3", 1);

        // Both Item1 and Item2 have priority 5. Item1 was added first.
        var result = priorityQueue.Dequeue();
        Assert.AreEqual("Item1", result, "Tie-breaking did not follow FIFO (First-In, First-Out).");
        
        result = priorityQueue.Dequeue();
        Assert.AreEqual("Item2", result, "Second item of the tie should come next.");
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Should throw InvalidOperationException.
    // Defect(s) Found: No defects found in this specific logic, but good to verify.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}