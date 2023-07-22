using System;
using System.Collections.Generic;

public class Technology
{
    public string Name { get; set; }
    public int DemandQuotient { get; set; }
}

    // the get accessor (or iterator method) in the iterator navigates through the iterator...it performs the custom iteration over the collection.
    public class Technologies
    {
        public System.Collections.Generic.IEnumerable<Technology> NextTechnology   // iterator
        {
            get   // accessor method of iterator
            {
                yield return new Technology { Name="C#", DemandQuotient=40 };
                yield return new Technology { Name="Python", DemandQuotient=25 };
                yield return new Technology { Name="R", DemandQuotient=30 };
                yield return new Technology { Name="Java", DemandQuotient=40 };
            }
        }
    }


public class ListExample
{
  // Collection Initializer
  static List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

  // Collection Initializer
  static List<Technology> TechnologyList = new List<Technology>
        {
            new Technology() { Name="C#", DemandQuotient=40},
            new Technology() { Name="Python", DemandQuotient=25},
            new Technology() { Name="R", DemandQuotient=30},
            new Technology() { Name="Java", DemandQuotient=40}
        };


  public static void Main()
  {
	// A lambda expression is placed in the ForEach method
	numbers.ForEach( number => Console.WriteLine(number + " "));

	TechnologyList.ForEach( x => Console.WriteLine(x.Name + " " + x.DemandQuotient.ToString()));
	
	// iterator using yield return
	ShowTechnologies();
  }

    // implements Iterator to use yeild return
    public static void ShowTechnologies()
    {
        var v_TechnologyList = new Technologies();
        foreach (Technology objTechnology in v_TechnologyList.NextTechnology)
        {
            Console.WriteLine(objTechnology.Name + " " + objTechnology.DemandQuotient.ToString());
        }
    }


}
