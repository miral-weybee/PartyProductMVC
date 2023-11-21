using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyProductMvc.Models;

namespace PartyProductMvc.Controllers
{
    public class ProductController : Controller
    {
        private DbService db = new DbService();
        // GET: Product
        public ActionResult ProductList()
        {
            if (Session["Id"] != null)
            {
                var data = db.Products.ToList();
                return View("ProductList", data);

            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        public ActionResult ProductAddEdit()
        {
            return View(new Product { ProductId = 0 });
        }

        public ActionResult SaveProduct(Product product)
        {
            if (!ModelState.IsValid)
                return View("ProductAddEdit", product);

            if (product.ProductId == 0)
            {
                db.Products.Add(product);
            }
            else
            {
                var productFromDb = db.Products.FirstOrDefault(e => e.ProductId == product.ProductId);
                if (productFromDb == null)
                    return HttpNotFound();

                productFromDb.ProductName = product.ProductName;
            }

            db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var productFromDb = db.Products.FirstOrDefault(e => e.ProductId == id);
            if (productFromDb == null)
                return HttpNotFound();

            return View("ProductAddEdit", productFromDb);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var productFromDb = db.Products.FirstOrDefault(e => e.ProductId == id);
            if (productFromDb == null)
                return HttpNotFound();
            db.Products.Remove(productFromDb);
            db.SaveChanges();
            return RedirectToAction("ProductList");
        }
    }
}