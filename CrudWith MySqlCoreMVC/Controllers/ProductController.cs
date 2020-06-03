using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudWith_MySqlCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudWith_MySqlCoreMVC.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private DataContext db = new DataContext();

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.products = db.Products.ToList();
            return View();
        }
        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            return View("Edit", db.Products.Find(id));
        }
        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id,Product product)
        {
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}