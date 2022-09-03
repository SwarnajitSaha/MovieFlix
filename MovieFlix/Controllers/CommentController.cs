using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

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
        public ActionResult Detailes([Bind(Include = "userId, userName ,movieId , openion")] Comment1 comment)
        {
            if(Variable.user_login==0)
            {
                return Content("You have not Login yet");
            }
            else if (ModelState.IsValid)
            {
                db.Comment1.Add(comment);
                db.SaveChanges();


                List<Comment1> com = db.Comment1.Where(x => x.movieId==comment.movieId).ToList();
                ViewBag.com = com;

                MovieList movieDetailes = db.MovieLists.Where(x => x.movieID == comment.movieId).FirstOrDefault();
                ViewBag.movieDetailes = movieDetailes;

                return View("~/Views/MovieDetailes/Detailes.cshtml");
            }
           
            return View("~/Views/MovieDetailes/Detailes.cshtml");
        }
    }
}