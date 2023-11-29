using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;
using PartyProductMvc.Models;

namespace PartyProductMvc.Controllers
{
    public class InvoiceController : Controller
    {
        private DbService db = new DbService();

        public ActionResult GetInvoice()
        {
            var invoice = db.Invoices.Include(x=>x.Party).Include(x => x.Product);
            
            return Json(new {data = invoice}, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductList(int partyId)
        {
            var productList = db.AssignParties.Include(x => x.Product).Include(x => x.Party).Where(x => x.Party.PartyId == partyId).Select(p => p.Product);
            return Json(productList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProductRate(int productId)
        {
            var productRate = db.ProductRates.Include(a => a.ProductName)
                .Where(x => x.ProductName.ProductId == productId).Select(b => b.Rate);
            return Json(productRate, JsonRequestBehavior.AllowGet);
        }
        // GET: Invoice
        public ActionResult InvoiceAdd()
        {
            if (Session["Id"] != null)
            {
                var party = db.Parties.ToList();
                ViewBag.partyList = party;

                var total = db.Invoices.Sum(x => (int?)x.CurrentRate * (int?)x.Quantity) ?? 0;
                ViewBag.GrandTotal = total;
                return View();
            }
            else
            {
                return RedirectToAction("Login","User");
            }
            
        }

        public ActionResult SaveInvoice(Invoice invoice)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();

            int productId = invoice.ProductId;
            int partyId = invoice.PartyId;
            var product = db.Products.Single(e => e.ProductId == productId);
            var party = db.Parties.Single(e => e.PartyId == partyId);
            db.Invoices.Add(new Invoice()
            {
                ProductId = productId, PartyId = partyId, CurrentRate = invoice.CurrentRate,Quantity = invoice.Quantity
            });

            db.SaveChanges();
            
            return RedirectToAction("InvoiceAdd");
        }

        public ActionResult DeleteInvoice()
        {
            if (!ModelState.IsValid)
                return HttpNotFound();
            var invoices = db.Invoices.ToList();
            foreach (var record in invoices)
            {
                db.Invoices.Remove(record);
            }

            db.SaveChanges();
            return RedirectToAction("InvoiceAdd");
        }
    }
}