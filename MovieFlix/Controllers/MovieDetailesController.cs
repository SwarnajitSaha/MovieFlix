using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieFlix.Controllers
{
    public class MovieDetailesController : Controller
    {
        // GET: MovieDetailes
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detailes()
        {

            return Content("1st call");
           

        }
        [HttpPost]
        public ActionResult Detailes([Bind(Include= "movieID")] MovieList id)
        {
            var movieId = id.movieID;
            ViewBag.movieId = movieId;
            return View();
        }
    }
}