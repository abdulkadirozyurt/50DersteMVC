using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _50DersteMVC.Models.Entity;

namespace _50DersteMVC.Controllers
{
    public class ProductsController : Controller
    {
        private Entities entities = new Entities();
        // GET: Products
        public ActionResult Index()
        {
            var products = entities.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {

            List<SelectListItem> categories = (from i in entities.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = i.CategoryName,
                                                   Value = i.Id.ToString()

                                               }).ToList();



            // select new kısmı-- ilgili öğeleri başka bir tipe dönüştürmek için kullanılır.
            //select new kısmı, her bir i öğesini SelectListItem tipinde bir nesneye dönüştürür.

            ViewBag.Categories = categories;
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {

            var category = entities.Categories.Where(c => c.Id == product.Category.Id).FirstOrDefault();
            product.Category = category;

            entities.Products.Add(product);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var product = entities.Products.Find(id);

            entities.Products.Remove(product);
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var product = entities.Products.Find(id);

            List<SelectListItem> categories = (from item in entities.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = item.CategoryName,
                                                   Value = item.Id.ToString()
                                               }

                                               ).ToList();
            ViewBag.Categories = categories;
            return View(product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            var productToUpdate = entities.Products.Find(product.Id);

            var category = entities.Categories.Where(c => c.Id == product.Category.Id).FirstOrDefault();

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.Brand = product.Brand;

            productToUpdate.CategoryId = category.Id;

            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.StockAmount = product.StockAmount;
            entities.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}


