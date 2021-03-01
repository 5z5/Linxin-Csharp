using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using accessPsychology.Models;
using Model;

namespace accessPsychology.Controllers
{
    
    public class WritingController : Controller
    {
        LinxinaccessEntities linxinDb = new LinxinaccessEntities();
        // GET: Writing
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save()
        {
            Articles articles = new Articles();
            articles.title = Request["title"];
            articles.content = Request.Unvalidated().Form["content"].ToString();
            articles.users_id = Convert.ToInt32(Session["User_id"]);
            articles.like_num = 12;
            articles.comment_num = 12;
            articles.views_num = 100;
            articles.creat_time = DateTime.Now;
            linxinDb.Articles.Add(articles);
            linxinDb.SaveChanges();
            return Content("<script>;alert('发布成功!返回首页!');window.location.href='/Home/Index'</script>");
        }
    }
}