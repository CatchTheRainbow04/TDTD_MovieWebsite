using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project02_MovieWebsite.Models;

namespace Project02_MovieWebsite.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        CompanyDbContext db = new CompanyDbContext();
        public ActionResult Index(string search = "", int page = 1)
        {
            List<Movies> movies = db.Movies.Where(i => i.Title.Contains(search)).ToList();
            ViewBag.Search = search;
            //Paging
            int NumOfRecordPerPage = 5;
            int NumOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(movies.Count) / Convert.ToDouble(NumOfRecordPerPage)));
            int NumOfRecordToSkip = (page - 1) * NumOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NumOfPages = NumOfPages;
            movies = movies.Skip(NumOfRecordToSkip).Take(NumOfRecordPerPage).ToList();
            return View(movies);
        }

        public ActionResult Detail(int id)
        {
            Movies mv = db.Movies.Where(i => i.MovieID == id).FirstOrDefault();
            return View(mv);
        }

        public ActionResult Create()
        {
            ViewBag.Genres = db.Genres.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movies movies)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Create");
            }
            
        }
        public ActionResult Edit(int id)
        {
            Movies mv = db.Movies.Where(i => i.MovieID == id).FirstOrDefault();
            ViewBag.Genres = db.Genres.ToList();
            return View(mv);
        }
        [HttpPost]
        public ActionResult Edit(Movies movies)
        {
            Movies mv = db.Movies.Where(i => i.MovieID == movies.MovieID).FirstOrDefault();
            mv.Title = movies.Title;
            mv.GenreID = movies.GenreID;
            mv.Description = movies.Description;
            mv.VideoURL = movies.VideoURL;
            mv.ThumbnailURL = movies.ThumbnailURL;
            mv.Duration = movies.Duration;
            mv.Rating = movies.Rating;
            mv.ReleaseYear = movies.ReleaseYear;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Movies mv = db.Movies.Where(i => i.MovieID == id).FirstOrDefault();
            return View(mv);
        }

        [HttpPost]
        public ActionResult Delete(Movies movie)
        {
            Movies mv = db.Movies.Where(i => i.MovieID == movie.MovieID).FirstOrDefault();
            db.Movies.Remove(mv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}