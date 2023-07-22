using System;
using System.Collections;  
using System.Linq;  

using LinqEntMethodNS;

public static class EnumerableExtensionImpl
{
    public static void Main()
    {
	double[] numbers = { 1.9, 2, 8, 4, 5.7, 6, 7.2, 0 };
	var query = numbers.Median();

	Console.WriteLine($"double: Median = {query}");
    }
}