using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieFlix.Controllers
{
    public class CommentController : Controller
    {
        MovieFlixEntities db = new MovieFlixEntities();
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Detailes([Bind(Include = "movieId ,userId , openion")] Comment comment)
        {

            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();


                List<Comment> com = db.Comments.Where(x => x.movieId==comment.movieId).ToList();
                ViewBag.com = com;

                MovieList movieDetailes = db.MovieLists.Where(x => x.movieID == comment.movieId).FirstOrDefault();
                ViewBag.movieDetailes = movieDetailes;

                return View("~/Views/MovieDetailes/Detailes.cshtml");
            }
            return View("~/Views/MovieDetailes/Detailes.cshtml");
        }
    }
}