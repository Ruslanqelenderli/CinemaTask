using Cinema.Context;
using Cinema.Models;
using Cinema.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class ManageController : Controller
    {
        // GET: Manage
        CinemaDbContext db = new CinemaDbContext();

        [HttpPost]
        public ActionResult Login(string Email, string Password)
        {
            List<User> users = db.Users.ToList();
            if (users != null)
            {
                foreach (User item in users)
                {
                    if (item.Email == Email && Crypto.VerifyHashedPassword(item.Password, Password))
                    {
                        Session["Loginned"] = true;
                        Session["User"] = item;

                        return RedirectToAction("Index", "Home");
                    }
                }                
            }

            Session["Login"] = false;
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            return View();
        }



        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (user.Name != null &&
                user.Surname != null &&
                user.PhoneNumber != null &&
                user.Birthday != null &&
                user.Email != null &&
                user.Password !=null
                )
            {
                if (ModelState.IsValid)
                {
                    string hashed = Crypto.HashPassword(user.Password);
                    User user1 = new User()
                    {
                        Name = user.Name,
                        Surname = user.Surname,
                        Birthday = user.Birthday,
                        Email = user.Email,
                        PhoneNumber = user.PhoneNumber,
                        Password = hashed
                    };
                    db.Users.Add(user1);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Manage");
                }
                
            }
            return View();

        }
        public ActionResult Logout()
        {
            Session["Loginned"] = null;
            return RedirectToAction("Login", "Manage");

        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}