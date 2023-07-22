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
Console.WriteLine("---------------ESPIRE RESTURANT---------------");
Console.WriteLine("PLEASE PRESS '#' FOR BOOKING SEAT.");
Console.WriteLine("PLEASE PRESS ANY KEY FOR EXIT.");
String str = Console.ReadLine();
if(str.Equals("#"))
{
Demo ss = CustomerDetails();
MENU(ml);

Bill bb = new Bill();
bb.PrintBill(ml,ss);



}else{
Console.WriteLine("-------------THANK YOU !!!!----------");
}




}
private static Demo CustomerDetails()
{
Console.WriteLine("ENTER YOUR NAME : ");
String name = Console.ReadLine();

Console.WriteLine("ENTER YOUR MOBILE NUMBER : ");
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
Console.WriteLine("HERE IS OUR MENU========================");
List<Menu> menulist = new List<Menu>
{
new Menu() { DishName="BUTTER CHICKEN ", Price=320},
new Menu() { DishName="CHILLY CHICKEN ", Price=320},
new Menu() { DishName="GARLIC CHICKEN ", Price=320},
new Menu() { DishName="CHICKEN CURRY ", Price=320},
new Menu() { DishName="MUTTON CURRY ", Price=400},
new Menu() { DishName="MUTTON FRY ", Price=380}
};
//int d =1;
Console.WriteLine("----------------------------------PRICE-------------");
/*foreach(var x in menulist)
{
Console.WriteLine(d+" => " + x.DishName +" -------------------> "+x.Price+"/-");
d++;
}
*/
RESMENU rr = new RESMENU();
rr.ReadData();
Console.WriteLine("----------------------------------------------------") ;
Console.WriteLine("Enter The Number For That Specific Dish ");
Console.WriteLine("..........OR ENTER '0' FOR EXIT......... ");
int n = int.Parse( Console.ReadLine());
int i = 0;
if(n > 0)
{
while(n != 0 )
{
Console.WriteLine("ANYTHINGS ELSE SIR >>>>>>>>>>>>>");

if(n <= 6 )
{
ml.Add(menulist[n-1]);
i++;
}else{
Console.WriteLine("NOT AN ITEAM...>>.... THANK YOU.....>>>");
}
n = int.Parse(Console.ReadLine());

}
}else{
Console.WriteLine("<<<<<<<<<<<<THANK YOU SIR VISIT AGAIN>>>>>>>>>>>>>");
}

}catch(Exception ee){
Console.WriteLine("HERE IT IS "+ee.Message);
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
conn = new SqlConnection( "Data Source=LPCD-D1B82B3;Initial Catalog=RESTURANT;User ID=sa;Password=Espire123");
}
public void ReadData()
{
SqlDataReader rdr = null;

try
{
// Open the connection
conn.Open();

// 1. Instantiate a new command with a query and connection
SqlCommand cmd = new SqlCommand("select Cn , Dname, Prc from MENU", conn);

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
Console.WriteLine("THANK YOU MR. "+dd.Name.ToUpper() + " .");
Console.WriteLine("YOUR MOBILE NUMBER "+dd.MN + " .");
}
}




//Bill
public class Bill
{
public void PrintBill(List<Menu> ll,Demo dd)
{
Console.WriteLine("------------------------ BY ESPIRE RESTURANT-------------------");
Console.WriteLine("MR. "+dd.Name.ToUpper()+" ---------------YOUR BILL-----------------------");
Console.WriteLine("YOUR ORDER ITEM:-----------------------------------------------");
double total = 0;
int c = 1 ;
foreach(var x in ll)
{
Console.WriteLine(c+"=> "+x.DishName + " -------------------> "+x.Price +"/-");
total += x.Price;
c++;
}

Console.WriteLine("---------------------------------------------------------------------");
Console.WriteLine("SUB TOTAL : "+total+".00 /-");
double gst = (total*18)/100 + total;
Console.WriteLine(" GST: "+gst+" /-" );
Console.WriteLine("======================================================================");
Console.WriteLine(dd.Name.ToUpper() + " we will contact you in this number "+ dd.MN + " for feedback");
Console.WriteLine("======================THANK YOU COME AGAIN=============================");
}
}

}