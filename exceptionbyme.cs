using System;

public class prakhar
{
public static void Main(string[] args)
{
int a = 34; 

try 
{
int b= a /int.Parse("0");
int Value= 4;
Console.WriteLine(Value);
Console.WriteLine(5);
}
catch(Exception ex)
{
Console.WriteLine(ex.Message);
}
Console.WriteLine("hello");
}
}
