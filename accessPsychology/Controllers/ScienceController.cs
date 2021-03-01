using accessPsychology.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace accessPsychology.Controllers
{
    public class ScienceController : Controller
    {
        // GET: Science
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSciArticles()
        {
            using (LinxinaccessEntities db = new LinxinaccessEntities())
            {
                List<ajaxClass.Sci_articles> list = new List<ajaxClass.Sci_articles>();
                foreach (var Art in db.Sci_articles)
                {
                    ajaxClass.Sci_articles art = new ajaxClass.Sci_articles();
                    art.id = Art.id;
                    art.title = Art.title;
                    art.content = Art.content;
                    art.origin = Art.origin;
                    art.author = Art.author;
                    art.likes_num = (int)Art.likes_num;
                    art.comment_num = (int)Art.comment_num;
                    art.views_num = (int)Art.views_num;
                    art.creat_time = (DateTime)Art.creat_time;
                    list.Add(art);
                }
                return Content(JsonConvert.SerializeObject(list));
            }
        }
    }
}