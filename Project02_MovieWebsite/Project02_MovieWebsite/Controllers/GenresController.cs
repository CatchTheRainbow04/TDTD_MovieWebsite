using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Project02_MovieWebsite.Models;

namespace Project02_MovieWebsite.Controllers
{
    public class GenresController : Controller
    {
        // GET: Genres
        CompanyDbContext db = new CompanyDbContext();
        public ActionResult Index(string search = "" , int page = 1)
        {
            List<Genres> gen = db.Genres.Where(i => i.Name.Contains(search)).ToList();
            ViewBag.Search = search;
            int NumOfRecordPerPage = 4;
            int NumOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(gen.Count) / Convert.ToDouble(NumOfRecordPerPage)));
            int NumOfRecordToSkip = (page - 1) * NumOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NumOfPages = NumOfPages;
            gen = gen.Skip(NumOfRecordToSkip).Take(NumOfRecordPerPage).ToList();
            return View(gen);
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

        public ActionResult Edit(int id)
        {
            Genres genre = db.Genres.Where(i => i.GenreID == id).FirstOrDefault();
            return View(genre);
        }
        [HttpPost]
        public ActionResult Edit(Genres genres)
        {
            Genres genres1 = db.Genres.Where(i => i.GenreID == genres.GenreID).FirstOrDefault();
            genres1.Name = genres.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}