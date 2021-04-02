using Cinema.Context;
using Cinema.Filter;
using Cinema.Models;
using Cinema.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cinema.Controllers
{
    [Auth]
    public class HomeController : Controller
    {
        // GET: Home
        CinemaDbContext db = new CinemaDbContext();
        public ActionResult Index(string orderBy, User userInSession)
        {

            List<Film> films = db.Films.Include(x=>x.User).ToList();

            List<Country> countries = db.Countries.ToList();
            List<Janre> janres = db.Janres.ToList();
            User user = Session["User"] as User;


            IndexViewModel indexViewModel = new IndexViewModel()
            {
                Films = films,
                Countries = countries,
                Janres = janres,
                Users = user
            };

            if (orderBy == null || orderBy == "name")
            {
                indexViewModel.Films = indexViewModel.Films.OrderBy(x => x.Name).ToList();
            }
            return View(indexViewModel);
        }

        [HttpGet]
        public ActionResult Search(DateTime? FromDate, DateTime? ToDate)
        {
            var film = db.Films.ToList();
            List<Film> list = new List<Film>();
            if (FromDate != null && ToDate != null)
            {
                foreach (var item in film)
                {
                    if (item.PublicationDate > FromDate && item.PublicationDate <= ToDate)
                    {
                        list.Add(item);
                    };
                }


                return View(list);
            }
            return Content("Xanalari doldurun");


        }








        [HttpPost]
        public ActionResult Add(Film filmModel, int[] countryIds, int[] janreIds)
        {
            if (filmModel.Name != null &&
               filmModel.PublicationDate != null &&
               filmModel.Link != null &&
               janreIds != null &&
               countryIds != null &&
               filmModel.Duration != 0)
            {


                Film film = filmModel;
                User user = Session["User"] as User;
                film.UserId = user.Id;

                db.Films.Add(film);

                foreach (int countryId in countryIds)
                {
                    db.FilmCountries.Add(new FilmCountry(countryId, film.Id));
                }
                foreach (int janreId in janreIds)
                {
                    db.FilmJanres.Add(new FilmJanre(janreId, film.Id));
                }

                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return Content("Xanalari doldurun");
        }


        public ActionResult Details(int id)
        {
            Film film = db.Films.FirstOrDefault(x => x.Id == id);
            List<FilmJanre> filmJanres = db.FilmJanres.Where(fj => fj.FilmId == id).Include(fj => fj.Janre).ToList();
            List<FilmCountry> filmCountries = db.FilmCountries.Where(fc => fc.FilmId == id).Include(fj => fj.Country).ToList();
            DetailsViewModel details = new DetailsViewModel()
            {
                FilmJanres = filmJanres,
                FilmCountries = filmCountries,
                Film=film
            };


            return View(details);
        }

        public ActionResult Delete(int id)
        {
            Film films = db.Films.Where(x => x.Id == id).FirstOrDefault();
            db.Films.Remove(films);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }




        public ActionResult Update(int id)
        {
            Film film = db.Films.Include(x => x.FilmJanres).Include(x => x.FilmCountries).Where(x => x.Id == id).FirstOrDefault();
            List<Janre> janres = db.Janres.ToList();
            List<Country> countries = db.Countries.ToList();

            UpdateViewModel indexViewModel = new UpdateViewModel()
            {
                Films = film,
                Janres = janres,
                Countries = countries

            };


            return View(indexViewModel);
        }
        [HttpPost]
        public ActionResult Update(Film films, int[] countryIds, int[] janreIds)
        {
            if (films.Name != null &&
               films.PublicationDate != null &&
               films.Link != null &&
               janreIds != null &&
               countryIds != null &&
               films.Duration != 0)
            {
                User user = Session["User"] as User;
                films.UserId = user.Id;
                db.Entry(films).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                DeleteRelations(films.Id);
                foreach (int item in countryIds)
                {
                    FilmCountry filmCountry = new FilmCountry()
                    {
                        FilmId = films.Id,
                        CountryId = item
                    };
                    db.FilmCountries.Add(filmCountry);
                    db.SaveChanges();
                }

                foreach (int item in janreIds)
                {
                    FilmJanre filmGenre = new FilmJanre()
                    {
                        FilmId = films.Id,
                        JanreId = item
                    };
                    db.FilmJanres.Add(filmGenre);
                    db.SaveChanges();
                }

                return RedirectToAction("Index","Home");
            }
            return Content("Xanalai doldurun");
        }
        private void DeleteRelations(int id)
        {
            foreach (FilmJanre item in db.FilmJanres.Where(x => x.FilmId == id).ToList())
            {
                db.FilmJanres.Remove(item);
                db.SaveChanges();
            }
            foreach (FilmCountry item in db.FilmCountries.Where(x => x.FilmId == id).ToList())
            {
                db.FilmCountries.Remove(item);
                db.SaveChanges();
            }
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