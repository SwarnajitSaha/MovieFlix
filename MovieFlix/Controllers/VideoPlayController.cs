using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieFlix.Controllers
{
    public class VideoPlayController : Controller
    {
        // GET: VideoPlay
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VideoPlay()
        {
            return View();
        }
    }
}