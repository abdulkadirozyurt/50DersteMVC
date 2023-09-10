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
        public ActionResult Index(string p)
        {
            //var customers = entities.Customers.ToList();

            //return View(customers);

            var customers = (from item in entities.Customers select item);
            if (!string.IsNullOrEmpty(p))
            {
                customers = customers.Where(x => x.FirstName.StartsWith(p));
            }

            return View(customers.ToList());
        }

        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("AddCustomer");
            }

            entities.Customers.Add(customer);
            entities.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteCustomer(int id)
        {
            var customer = entities.Customers.Find(id);
            entities.Customers.Remove(customer);
            entities.SaveChanges();


            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult UpdateCustomer(int id)
        {
            var customer = entities.Customers.Find(id);


            return View(customer);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            var customerToUpdate = entities.Customers.Find(customer.Id);
            customerToUpdate.FirstName = customer.FirstName;
            customerToUpdate.LastName = customer.LastName;

            entities.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}