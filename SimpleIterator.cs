using System;
using System.Collections.Generic;


public class SimpleIterator
{
  static void Main()
  {
    foreach (int number in EvenSequence(5, 18))
    {
        Console.Write(number.ToString() + " ");
    }


    // Output: 6 8 10 12 14 16 18
    Console.ReadKey();
  }

  // EvenSequence is the iterator method
  //public static System.Collections.Generic.IEnumerable<int> EvenSequence(int firstNumber, int lastNumber)
  public static IEnumerable<int> EvenSequence(int firstNumber, int lastNumber)
  {
    // Yield even numbers in the range.
    for (int number = firstNumber; number <= lastNumber; number++)
    {
        if (number % 2 == 0)
        {
            yield return number;
        }
    }
  }
}