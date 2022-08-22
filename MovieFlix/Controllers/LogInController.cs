using MovieFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieFlix.Controllers
{
    public class LogInController : Controller
    {
        MovieFlixEntities db = new MovieFlixEntities();
        // GET: LogIn
        public ActionResult Index()
        {
            return View("Home");
        }
        public ActionResult LoginPage()
        {
            ViewBag.error = "";
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage([Bind(Include = "email , passwords, userType")] User user)
        {
            ViewBag.person = "nobody";
            if (ModelState.IsValid)
            {
                User admin = db.Users.Where(x => x.email == user.email && x.passwords == user.passwords && x.userType == "admin").FirstOrDefault();
                User user1 = db.Users.Where(x => x.email == user.email && x.passwords == user.passwords && x.userType == "user").FirstOrDefault();
                string sql = "select * from MovieList";
                List<MovieList> movielist = db.MovieLists.SqlQuery(sql).ToList();
                ViewBag.movielist = movielist;


                if (user1 != null)
                {
                    ViewBag.error = "";
                    ViewBag.person = "user";

                    Session["login"] = "yes";
                    Session["userId"] = user1.userId;

                    // ID_pass ids = new ID_pass { userId = user.userId };

                    return View("~/Views/Home/Home.cshtml");
                    //return RedirectToAction("Home", "HomeController", new { userId = user.userId });

                }
                else if (admin != null)
                {
                    ViewBag.person = "admin";
                    ViewBag.error = "";
                    return View("~/Views/Home/Home.cshtml");
                  //  return RedirectToAction("Home", "HomeController");
                }

            }
            return View();

        }


        public ActionResult RegisterPage()
        {
            ViewBag.notMatch = "";
            return View();
        }
        [HttpPost]
        public ActionResult RegisterPage([Bind(Include = "email ,name, passwords, confirmPass")] User1 user1)
        {
            ViewBag.notMatch = "";
            if (user1.passwords!=user1.confirmPass)
            {
                ViewBag.notMatch = "Password Did't Match, Try Again.";
                return View();
            }
            else if(user1.email!=""&& user1.name != "" && user1.passwords != "" && user1.confirmPass != "" )
            {
                if (ModelState.IsValid)
                {
                    User user = new User();
                    user.email = user1.email;
                    user.name = user1.name; 
                    user.passwords = user1.passwords;

                    db.Users.Add(user);
                    db.SaveChanges();
                    ViewBag.notMatch = "Account Registation Done.";
                    return View();
                }
            }
            else
            {
                
                return View();
            }
            return View();
        }
    }
}