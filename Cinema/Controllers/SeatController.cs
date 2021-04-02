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
    public class SeatController : Controller
    {
        CinemaDbContext db = new CinemaDbContext();
        // GET: Seat
        [HttpGet]
        public ActionResult AddSeat()
        {
            List<Hall> hall = db.Halls.ToList();
            List<Seat> seats = db.Seats.ToList();

            AddSeatViewModel addSeatViewModel = new AddSeatViewModel()
            {
                Halls = hall,
                Seats = seats

            };
            return View(addSeatViewModel);
        }
        [HttpPost]
        public ActionResult AddSeat(Seat seat)
        {
            if (seat.HallId != 0 &&
               seat.Row != null &&
               seat.Column != 0)
            {

                List<Seat> seat1 = db.Seats.ToList();
                if (seat1.Count != 0)
                {
                    foreach (Seat item in seat1)
                    {
                        if (seat.Column == item.Column && seat.Row == item.Row)
                        {
                            return Content("Bu yer doludur");
                        }
                        else
                        {
                            db.Seats.Add(seat);
                            db.SaveChanges();
                            List<Seat> seats = db.Seats.ToList();
                            List<Hall> hall = db.Halls.ToList();
                            AddSeatViewModel addSeatViewModel = new AddSeatViewModel()
                            {
                                Halls = hall,
                                Seats = seats
                            };
                            return View(addSeatViewModel);
                        }
                    }
                }
                else
                {
                    db.Seats.Add(seat);
                    db.SaveChanges();
                    List<Seat> seats = db.Seats.ToList();
                    List<Hall> hall = db.Halls.ToList();
                    AddSeatViewModel addSeatViewModel = new AddSeatViewModel()
                    {
                        Halls = hall,
                        Seats = seats
                    };
                    return View(addSeatViewModel);
                }



            };
            return Content("Xanalari doldurun");
        }




        public ActionResult SeatDelete(int id)
        {
            Seat seat = db.Seats.Where(x => x.Id == id).FirstOrDefault();
            db.Seats.Remove(seat);
            db.SaveChanges();
            return RedirectToAction("AddSeat", "Seat");
        }

        public ActionResult SeatUpdate(int id)
        {
            List<Hall> halls = db.Halls.ToList();
            Seat seat = db.Seats.Where(x => x.Id == id).FirstOrDefault();

            SeatUpdateViewModel Update = new SeatUpdateViewModel()
            {
                Halls = halls,
                Seat = seat
            };

            return View(Update);
        }

        [HttpPost]
        public ActionResult SeatUpdate(Seat seat, int id)
        {
            if (seat.Row != null &&
               seat.Column != 0 &&
               seat.HallId != 0)
            {
                Seat seat1 = db.Seats.Where(x => x.Id == id).FirstOrDefault();
                seat1.HallId = seat.HallId;
                seat1.Row = seat.Row;
                seat1.Column = seat.Column;
                db.SaveChanges();
                List<Hall> halls = db.Halls.ToList();
                Seat seats = db.Seats.Where(x => x.Id == id).FirstOrDefault();
                SeatUpdateViewModel Update = new SeatUpdateViewModel()
                {
                    Halls = halls,
                    Seat = seats
                };
                return RedirectToAction("AddSeat", "Seat");
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