using Cinema.Context;
using Cinema.Filter;
using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    [Auth]
    public class HallController : Controller
    {
        CinemaDbContext db = new CinemaDbContext();
        // GET: Hall
        [HttpPost]
        public ActionResult AddHall(Hall hall)
        {
            if (hall.Name != null)
            {
                bool r = false;
                List<Hall> halls = db.Halls.ToList();
                foreach (var item in halls)
                {
                    if (item.Name == hall.Name)
                    {
                        r = true;
                    }
                }
                if (r)
                {
                    return Content("Bu ad islenilib");
                }
                else
                {

                    db.Halls.Add(hall);
                    db.SaveChanges();
                    List<Hall> hal = db.Halls.ToList();
                    return View(hal);
                }
            }
            return Content("Ad daxil et");

        }
        public ActionResult AddHall()
        {
            List<Hall> halls = db.Halls.ToList();
            return View(halls);
        }


        public ActionResult HallDelete(int id)
        {
            Hall hall = db.Halls.Where(x => x.Id == id).FirstOrDefault();
            db.Halls.Remove(hall);
            db.SaveChanges();

            return RedirectToAction("AddHall", "Hall");
        }
        public ActionResult HallUpdate(int id)
        {
            Hall hall = db.Halls.Where(x => x.Id == id).FirstOrDefault();



            return View(hall);
        }
        [HttpPost]
        public ActionResult HallUpdate(int id, Hall hall)
        {
            if (hall.Name != null)
            {


                Hall halls = db.Halls.Where(x => x.Id == id).FirstOrDefault();

                halls.Name = hall.Name;
                db.SaveChanges();

                return RedirectToAction("AddHall", "Hall");


            }
            return Content("Xanalari doldurun");
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