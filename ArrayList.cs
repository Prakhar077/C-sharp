using System;
using System.Collections;
public class SamplesArrayList  {

   public static void Main()  {

      // Creates and initializes a new ArrayList.
      ArrayList myAL = new ArrayList();
      myAL.Add("Hello");
      myAL.Add("World");
      myAL.Add("!");

      // Displays the properties and values of the ArrayList.
      Console.WriteLine( "myAL" );
      Console.WriteLine( "    Count:    {0}", myAL.Count );
      Console.WriteLine( "    Capacity: {0}", myAL.Capacity );
      Console.Write( "    Values:" );
      
	//for(int i = 0; i < myAL.Count; i++) { Console.WriteLine(myAL[i]); }
	
	myAL.RemoveAt(1);
      PrintValues( myAL );
 
      myAL.Remove("Hello");
      PrintValues( myAL );
 
      myAL.Add("Hello");
      myAL.Add("World");
      myAL.Add("!");
 
      myAL.RemoveRange(1, 3);






	PrintValues( myAL );
   }

   public static void PrintValues( IEnumerable myList )  {
      foreach ( Object obj in myList )
         Console.Write( "   {0}", obj );
      Console.WriteLine();
   }

}
