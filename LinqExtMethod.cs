using System;
using System.Collections;  
using System.Collections.Generic;
using System.Linq;  

namespace LinqEntMethodNS
{
public static class EnumerableExtension
{
    public static double Median(this IEnumerable<double>? source)  // ? -> nullable
    {
        if (source is null || !source.Any())
        {
            throw new InvalidOperationException("Cannot compute median for a null or empty set.");
        }

        var sortedList =
            source.OrderBy(number => number).ToList();

        int itemIndex = sortedList.Count / 2;

        if (sortedList.Count % 2 == 0)
        {
            // Even number of items.
            return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / 2;
        }
        else
        {
            // Odd number of items.
            return sortedList[itemIndex];
        }
    }
}
}
