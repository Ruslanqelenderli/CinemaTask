﻿using Cinema.Context;
using Cinema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        CinemaDbContext db = new CinemaDbContext();
        public ActionResult Index()
        {

            List<Film> films = db.Films.ToList();
            List<Country> countries = db.Countries.ToList();
            List<Janre> janres = db.Janres.ToList();
            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Films = films,
                Countries = countries,
                Janres = janres
            };

            return View(indexViewModel);
        }

        [HttpGet]
        public ActionResult Search(DateTime FromDate, DateTime ToDate)
        {
            var film = db.Films.ToList();
            List<Film> list = new List<Film>();
            foreach (var item in film)
            {
                if (item.PublicationDate > FromDate && item.PublicationDate < ToDate)
                {
                    list.Add(item);
                };
            }


            return View(list);


        }
        [HttpPost]
        public ActionResult Add(Film film)
        {

            db.Films.Add(film);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Details(int id)
        {
            var f = db.Films.Where(x => x.Id == id)
                                            .Include(x => x.Janre)
                                            .Include(x => x.Country)
                                            .FirstOrDefault();
            return View(f);
        }
    }
}