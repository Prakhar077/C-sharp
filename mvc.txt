using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudMVC;
using CrudMVC.Models;
using System.Data.Entity;



namespace CrudMVC.Controllers
{
public class CustomerController : Controller
{
// GET: Customer
public ActionResult Index()
{
using(MVCcrudEntities dbModel =new MVCcrudEntities())
{
return View(dbModel.Customers.ToList());
}
//return View();
}



// GET: Customer/Details/5
public ActionResult Details(int id)
{
using(MVCcrudEntities dbModel=new MVCcrudEntities())
{
return View(dbModel.Customers.Where(x => x.ID == id).FirstOrDefault());
}
//return View();
}



// GET: Customer/Create
public ActionResult Create()
{
return View();
}



// POST: Customer/Create
[HttpPost]
public ActionResult Create(Customer customer)
{
try
{
using (MVCcrudEntities dbModel = new MVCcrudEntities())
{
dbModel.Customers.Add(customer);
dbModel.SaveChanges();
}
// TODO: Add insert logic here



return RedirectToAction("Index");
}
catch
{
return View();
}
}



// GET: Customer/Edit/5
public ActionResult Edit(int id)
{
using (MVCcrudEntities dbModel = new MVCcrudEntities())
{
return View(dbModel.Customers.Where(x => x.ID == id).FirstOrDefault());
}



//return View();
}



// POST: Customer/Edit/5
[HttpPost]
public ActionResult Edit(int id, Customer customer)
{
try
{
using(MVCcrudEntities dbModel=new MVCcrudEntities())
{
dbModel.Entry(customer).State = EntityState.Modified;
dbModel.SaveChanges();
}
// TODO: Add update logic here



return RedirectToAction("Index");
}
catch
{
return View();
}
}



// GET: Customer/Delete/5
public ActionResult Delete(int id)
{
using (MVCcrudEntities dbModel = new MVCcrudEntities())
{
return View(dbModel.Customers.Where(x => x.ID == id).FirstOrDefault());
}
//return View();
}



// POST: Customer/Delete/5
[HttpPost]
public ActionResult Delete(int id, FormCollection collection)
{
try
{ using(MVCcrudEntities dbModel=new MVCcrudEntities())
{
Customer customer = dbModel.Customers.Where(x => x.ID == id).FirstOrDefault();
dbModel.Customers.Remove(customer);
dbModel.SaveChanges();
}
// TODO: Add delete logic here



return RedirectToAction("Index");
}
catch
{
return View();
}
}
}
}