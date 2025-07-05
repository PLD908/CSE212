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
        // Plan for MultiplesOf:
        // 1. Create a double array of size 'length' to store the multiples.
        // 2. For each index i from 0 to length-1, calculate the multiple as number * (i + 1).
        // 3. Store each multiple in the array at index i.
        // 4. Return the array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
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
        // Plan for RotateListRight:
        // 1. Handle edge cases: if data is null, empty, or amount is 0, return without changes.
        // 2. Normalize amount using modulo (amount % data.Count) to handle cases where amount equals data.Count.
        // 3. Create a temporary list to store original values.
        // 4. For each index i, place the element at index i in the position (i + amount) % data.Count.
        // 5. Copy the rotated elements back to the original list.

        if (data == null || data.Count == 0 || amount == 0)
        {
            return;
        }

        amount = amount % data.Count;
        if (amount == 0)
        {
            return;
        }

        List<int> temp = new List<int>(data);
        for (int i = 0; i < data.Count; i++)
        {
            int newIndex = (i + amount) % data.Count;
            data[newIndex] = temp[i];
        }
    }
}
