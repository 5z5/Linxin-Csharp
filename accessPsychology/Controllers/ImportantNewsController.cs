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
    public class ImportantNewsController : Controller
    {
        // GET: ImportantNews
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetNewsArticles()
        {
            using (LinxinaccessEntities db = new LinxinaccessEntities())
            {
                List<Psy_news> list = new List<Psy_news>();
                foreach (var Art in db.Psy_news)
                {
                    Psy_news art = new Psy_news();
                    art.id = Art.id;
                    art.title = Art.title;
                    art.content = Art.content;
                    art.likes_num = Art.likes_num;
                    art.origin = Art.origin;
                    art.author = Art.author;
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