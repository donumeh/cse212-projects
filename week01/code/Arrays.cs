public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Process:
        // Create an fixed array of 5 (int)
        // Write a LOOP 'length' amount of times
        // Inside loop multiply number by index and store in array

        double[] multiples = new double[length];
        for (double i = 1; i <= length; i++)
        {
            multiples[((int)i - 1)] = number * i;
        }

        return multiples; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Process
        // Calculate split index data.count - amount
        // store the first split up to the split index
        // store the second split upp to the split index
        // Clear data in data
        // append the second split on top of the first
        // store into data

        int splitIndex = data.Count - amount;
        List<int> part1 = data.GetRange(splitIndex, amount);
        List<int> part2 = data.GetRange(0, splitIndex);

        data.Clear();

        part1.AddRange(part2);
        data.AddRange(part1);
    }
}
