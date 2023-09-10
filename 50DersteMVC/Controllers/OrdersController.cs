using _50DersteMVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _50DersteMVC.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Sales

        Entities entities= new Entities();
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult NewOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewOrder(Order order)
        {
            entities.Orders.Add(order);
            entities.SaveChanges();

            return View("Index");
        }
    }
}