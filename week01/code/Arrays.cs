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

        double[]multiples = new double[length];

        //use a bucle to go 1 by 1
        for (int i = 0; i < length; i++)
        {
            //for each element in the array calculate the multiple
            multiples[i] = number * (i + 1);
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

        //verifi if the list is empty or have just one element
        if (data.Count <= 1)
            return;

        //reeduce the amount so that is into the list limits
        amount = amount % data.Count;

        //if amount is 0, then the list doesnt have to move
        if (amount == 0)
            return;
        
        //create two sublist, one with the last elements and the other one with the rest
        List<int> rightPart = data.GetRange(data.Count - amount, amount);
        List<int> leftPart = data.GetRange(0, data.Count - amount);

        //join the two sublist in the new order
        data.Clear(); //clean the original list
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
