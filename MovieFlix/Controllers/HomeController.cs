using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieFlix.Controllers
{
    public class HomeController : Controller
    {
        MovieFlixEntities db = new MovieFlixEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
           
            string sql = "select * from MovieList";
            List<MovieList> movielist = db.MovieLists.SqlQuery(sql).ToList();
            ViewBag.movielist = movielist;
            return View();
        }
    }
}