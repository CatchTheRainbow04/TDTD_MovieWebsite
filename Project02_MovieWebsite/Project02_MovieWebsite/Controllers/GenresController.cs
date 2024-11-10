using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02_MovieWebsite.Models;

namespace Project02_MovieWebsite.Controllers
{
    public class GenresController : Controller
    {
        // GET: Genres
        CompanyDbContext db = new CompanyDbContext();
        public ActionResult Index()
        {
            List<Genres> genre = db.Genres.ToList();
            return View(genre);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Genres genres)
        {
            db.Genres.Add(genres);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Genres genres = db.Genres.Where(i => i.GenreID == id).FirstOrDefault();
            return View(genres);
        }

        [HttpPost]
        public ActionResult Delete(Genres genres)
        {
            Genres genre = db.Genres.Where(i => i.GenreID == genres.GenreID).FirstOrDefault();

            if (genre != null)
            {
                var relatedMovies = db.Movies.Where(m => m.GenreID == genres.GenreID).ToList();
                db.Movies.RemoveRange(relatedMovies);
                db.Genres.Remove(genre);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}