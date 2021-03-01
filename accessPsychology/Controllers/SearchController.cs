using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using accessPsychology.Models;
using Model;

namespace accessPsychology.Controllers
{
    public class SearchController : Controller
    {
        LinxinaccessEntities linxinDb = new LinxinaccessEntities();
        // GET: Search
        public ActionResult search()
        {
            var content = Request["search"];
            ViewBag.content = linxinDb.Articles.Where(n => n.title.Contains(content)).Select(n => n);
            return View("");
        }
    }
}