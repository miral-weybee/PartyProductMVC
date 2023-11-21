using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyProductMvc.Models;

namespace PartyProductMvc.Controllers
{
    public class ProductRateController : Controller
    {
        private DbService db = new DbService();
        // GET: ProductRate
        public ActionResult ProductRateList()
        {
            if (Session["Id"] != null)
            {
                
            return View(db.ProductRates.Include(x => x.ProductName).ToList());
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        public ActionResult ProductRateAddEdit()
        {
            var products = db.Products.ToList();
            ViewBag.product = products;
            return View(new ProductRate(){Id = 0, DateOfRate = DateTime.Now});
        }

        public ActionResult SaveProductRate(ProductRate productRate)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();

            if (productRate.Id == 0)
            {
                var productId = Convert.ToInt32(productRate.ProductName.ProductName);
                var product = db.Products.Single(e => e.ProductId == productId);

                ProductRate pr = new ProductRate()
                {
                    Rate = productRate.Rate,
                    DateOfRate = productRate.DateOfRate,
                    ProductName = product
                };
                db.ProductRates.Add(pr);
            }
            else
            {
                var assignPartyFromDb = db.ProductRates.FirstOrDefault(e => e.Id == productRate.Id);
                if (assignPartyFromDb == null)
                    return HttpNotFound();
                var prid = Convert.ToInt32(productRate.ProductName.ProductName);
                var product = db.Products.Single(e => e.ProductId == prid);
                assignPartyFromDb.ProductName = product;
                assignPartyFromDb.Rate = productRate.Rate;
                assignPartyFromDb.DateOfRate = productRate.DateOfRate;
            }
                
            db.SaveChanges();
            return RedirectToAction("ProductRateList");
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
                return HttpNotFound();

            var productRateFromDb = db.ProductRates.First(e => e.Id == id);
            if (productRateFromDb == null)
                return HttpNotFound();

            var product = db.Products;
            
            ViewBag.product = product;
            return View("ProductRateAddEdit", productRateFromDb);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var productRateFromDb = db.ProductRates.First(e => e.Id == id);
            if (productRateFromDb == null)
                return HttpNotFound();
            db.ProductRates.Remove(productRateFromDb);
            db.SaveChanges();
            return RedirectToAction("ProductRateList");
        }
    }
}