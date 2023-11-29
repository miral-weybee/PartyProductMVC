using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using PartyProductMvc.Models;

namespace PartyProductMvc.Controllers
{
    public class AssignPartyController : Controller
    {
        private DbService db = new DbService();
        // GET: AssignPart
        public ActionResult AssignPartyList()
        {
            if (Session["Id"] != null)
            {
                return View(db.AssignParties.Include(e => e.Party).Include(x => x.Product).ToList());
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
            
        }

        public ActionResult AssignPartyAddEdit()
        {
            var party = db.Parties;
            var product = db.Products;
            ViewBag.partyList = party;
            ViewBag.productList = product;
            AssignParty ap = new AssignParty()
            {
                AssignPartyId = 0
            };
            return View(ap);
        }

        public ActionResult SaveAssign(AssignParty assignParty)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();
            if (assignParty.AssignPartyId == 0)
            {
                int partyId = assignParty.PartyId;
                int productId = assignParty.ProductId;
                var party = db.Parties.Single(e => e.PartyId == partyId);
                var product = db.Products.Single(e => e.ProductId == productId);
                db.AssignParties.Add(new AssignParty() { Party = party, Product = product });
            }
            else
            {
                var assignFromDb = db.AssignParties.FirstOrDefault(e => e.AssignPartyId == assignParty.AssignPartyId);
                if (assignFromDb == null)
                    return HttpNotFound();

                var partyId = assignParty.PartyId;
                var productId = assignParty.ProductId;
                var party = db.Parties.Single(e => e.PartyId == partyId);
                var product = db.Products.Single(e => e.ProductId == productId);

                assignFromDb.Party = party;
                assignFromDb.Product = product;
            }
           

            db.SaveChanges();
            return RedirectToAction("AssignPartyList");
        }
        public ActionResult Edit(int? id)
        {
           
            if (id == null)
                return HttpNotFound();

            var assignPartyFromDb = db.AssignParties.First(e => e.AssignPartyId == id);
            if (assignPartyFromDb == null)
                return HttpNotFound();
            
            var party = db.Parties;
            var product = db.Products;
            ViewBag.partyList = party;
            ViewBag.productList = product;
            return View("AssignPartyAddEdit",assignPartyFromDb);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var assignPartyFromDb = db.AssignParties.First(e => e.AssignPartyId == id);
            if (assignPartyFromDb == null)
                return HttpNotFound();
            db.AssignParties.Remove(assignPartyFromDb);
            db.SaveChanges();
            return RedirectToAction("AssignPartyList");
        }
    }
}