using System;
using System.IO;

using ExcpSample;

  public class UsingCustomException
  {
    public static void Main(string[] args)
    {
        try
        { 
	  if (args[0] == "Error")
	  	throw new CustomException("Custom Exception raised");

            Console.WriteLine("Normal execution");
        }
        catch(CustomException ex)
        {
            Console.WriteLine("Exception raised: " + ex.ToString());
        }
        finally
        {}
    }
  }

