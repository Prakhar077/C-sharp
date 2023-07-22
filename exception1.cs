using System;

class dbzero
{
    static void Main()
    {
	try
	{
	    int value = 1 / int.Parse("0");
	    Console.WriteLine(value);
            Console.WriteLine(5);
	}
	catch (Exception ex)
	{
	    Console.WriteLine(ex.Message);
	}
       Console.WriteLine("hello");

    }

}
