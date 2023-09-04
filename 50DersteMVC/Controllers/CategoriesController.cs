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

        [HttpGet]
        public ActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            entities.Categories.Add(category);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = entities.Categories.Find(id);

            entities.Categories.Remove(category);
            entities.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}