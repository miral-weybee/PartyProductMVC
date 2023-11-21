using PartyProductMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMvc.Controllers
{
    public class UserController : Controller
    {
        private DbService db = new DbService();
        
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();

            db.Users.Add(user);
            db.SaveChanges();
            ModelState.Clear();

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userFromDb = db.Users.Single(u => u.UserName == user.UserName && u.Password == user.Password);
            if(userFromDb != null)
            {
                Session["Id"] = user.Id.ToString();
                Session["UserName"] = user.UserName.ToString();
                return RedirectToAction("PartyList","Party");
            }
            else
            {
                ModelState.AddModelError("", "Username or Password is wrong");
                return View();
            }
        }
       
    }
}
