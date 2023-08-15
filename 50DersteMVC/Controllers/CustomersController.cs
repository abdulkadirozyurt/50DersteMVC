using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _50DersteMVC.Models.Entity;

namespace _50DersteMVC.Controllers
{
    public class CustomersController : Controller
    {
        Entities entities = new Entities();
        public ActionResult Index()
        {
            var customers = entities.Customers.ToList();

            return View(customers);
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            entities.Customers.Add(customer);
            entities.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}