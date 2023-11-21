using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyProductMvc.Models;

namespace PartyProductMvc.Controllers
{
    public class PartyController : Controller
    {
        private DbService db = new DbService();
        // GET: Party
        public ActionResult PartyList()
        {
            if (Session["Id"] != null)
            {
            var data = db.Parties.ToList();
            return View("PartyList",data);
                
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }

        public ActionResult PartyAddEdit()
        {
            return View(new Party{PartyId = 0});
        }

        public ActionResult SaveParty(Party party)
        {
            if (!ModelState.IsValid)
                return View("PartyAddEdit", party);

            if (party.PartyId == 0)
            {
                db.Parties.Add(party);
            }
            else
            {
                var partyFromDb = db.Parties.FirstOrDefault(e => e.PartyId == party.PartyId);
                if (partyFromDb == null)
                    return HttpNotFound();

                partyFromDb.PartyName = party.PartyName;
            }

            db.SaveChanges();
            return RedirectToAction("PartyList");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var party = db.Parties.FirstOrDefault(e => e.PartyId == id);
            if (party == null)
                return HttpNotFound();

            return View("PartyAddEdit", party);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var party = db.Parties.FirstOrDefault(e => e.PartyId == id);
            if (party == null)
                return HttpNotFound();

            db.Parties.Remove(party);
            db.SaveChanges();
            return RedirectToAction("PartyList");
        }
    }
}
