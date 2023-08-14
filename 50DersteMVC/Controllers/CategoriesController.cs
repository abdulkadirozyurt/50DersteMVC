using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _50DersteMVC.Models.Entity;

namespace _50DersteMVC.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Default
        Entities entities = new Entities();
        public ActionResult Index()
        {
            var categories = entities.Categories.ToList();
            return View(categories);
        }
    }
}