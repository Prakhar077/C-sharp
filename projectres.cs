using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Practice
{
class Program
{
static void Main(string[] args)
{
List<Menu> ml = new List<Menu>();
Console.WriteLine("prakhar's inn");
Console.WriteLine(" PRESS $ FOR BOOKING .");
Console.WriteLine(" OR PRESS ANY KEY FOR EXIT.");
String str = Console.ReadLine();
if(str.Equals("$"))
{
Demo ss = CustomerDetails();
MENU(ml);

Bill bb = new Bill();
bb.PrintBill(ml,ss);



}else{
Console.WriteLine("thnku !!");
}




}
private static Demo CustomerDetails()
{
Console.WriteLine(" YOUR NAME SIR: ");
String name = Console.ReadLine();

Console.WriteLine(" YOUR MOBILE NUMBER SIR: ");
long a = long.Parse(Console.ReadLine());
Demo dd = new Demo
{
Name = name,
MN = a



};
return dd;
}
private static void MENU(List<Menu> ml)
{



try{
Console.WriteLine(" OUR MENU");
List<Menu> menulist = new List<Menu>
{
new Menu() { DishName="butter paneer", Price=300},
new Menu() { DishName="noodles", Price=100},
new Menu() { DishName="dosa", Price=150},
new Menu() { DishName="idli", Price=90},
new Menu() { DishName="fried rice ", Price=100}
};
//int d =1;
Console.WriteLine("price");
/*foreach(var x in menulist)
{
Console.WriteLine(d+" => " + x.DishName +" -------------------> "+x.Price+"/-");
d++;
}
*/
RESMENU rr = new RESMENU();
rr.ReadData();
Console.WriteLine("----------------------------------------------------") ;
Console.WriteLine("Enter The Number For the Dish ");
Console.WriteLine("or else enter '0' for exit");
int n = int.Parse( Console.ReadLine());
int i = 0;
if(n > 0)
{
while(n != 0 )
{
Console.WriteLine("anything else for u?");

if(n <= 6 )
{
ml.Add(menulist[n-1]);
i++;
}else{
Console.WriteLine("sorry no item  thanku");
}
n = int.Parse(Console.ReadLine());

}
}else{
Console.WriteLine("thanku sir , do visit again");
}

}catch(Exception ee){
Console.WriteLine("HERE"+ee.Message);
}

}




}

//RESMENU
public class RESMENU
{
SqlConnection conn;

public RESMENU()
{
// Instantiate the connection
conn = new SqlConnection( "Data Source=LPCD-JTNP4B3;Initial Catalog=Training;User ID=sa;Password=Espire123");
}
public void ReadData()
{
SqlDataReader rdr = null;

try
{
// Open the connection
conn.Open();

// 1. Instantiate a new command with a query and connection
SqlCommand cmd = new SqlCommand("select * from Food", conn);

// 2. Call Execute reader to get query results
rdr = cmd.ExecuteReader();

// print the CategoryName of each record
while (rdr.Read())
{
Console.WriteLine(rdr[0] + " => " + rdr[1] + " -----------------> " + rdr[2]+"/-");
}
}
finally
{
// close the reader
if (rdr != null)
{
rdr.Close();
}

// Close the connection
if (conn != null)
{
conn.Close();
}
}
}





}

//Menu
public class Menu
{

public string DishName { get; set; }
public double Price { get; set; }




}


//PersonDetail
public class Demo
{
public string Name { get; set; }
public long MN { get; set; }
//public string StateOfOrigin { get; set; }

//public List<Pet> Pets { get; set; }


public void m1(Demo dd)
{
Console.WriteLine("THANK YOU very much sir  "+dd.Name.ToUpper() + " .");
Console.WriteLine("YOUR NUMBER "+dd.MN + " .");
}
}




//Bill
public class Bill
{
public void PrintBill(List<Menu> ll,Demo dd)
{
Console.WriteLine(" BY prakhar");
Console.WriteLine("MR. "+dd.Name.ToUpper()+"YOUR BILL-");
Console.WriteLine("YOUR ORDER");
double total = 0;
int c = 1 ;
foreach(var x in ll)
{
Console.WriteLine(c+"=> "+x.DishName + " -------------------> "+x.Price +"/-");
total += x.Price;
c++;
}

Console.WriteLine("@##$@#$%%$##@!@#$%");
Console.WriteLine("SUB TOTAL : "+total+".00 /-");
double gst = (total*18)/100 + total;
Console.WriteLine(" GST: "+gst+" /-" );
Console.WriteLine("=$Y$@%^$%^$^%^#");




Console.WriteLine("THANK YOU COME AGAIN SIR");
}
}

}