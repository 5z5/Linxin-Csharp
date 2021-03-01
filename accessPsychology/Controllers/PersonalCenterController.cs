using accessPsychology.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using accessPsychology.ajaxClass;
using Model;

namespace accessPsychology.Controllers
{
    public class PersonalCenterController : Controller
    {
        LinxinaccessEntities db = new LinxinaccessEntities();
        // GET: PersonalCenter
        public ActionResult Index(int id)
        {
            Session["select_nav"] = id;
            return View();
        }

        public ActionResult GetUsers()
        {
            using (LinxinaccessEntities db = new LinxinaccessEntities())
            {
                List<ajaxClass.Users> list = new List<ajaxClass.Users>();
                string username = Session["UserName"].ToString();
                var Use = db.Users.Where(o => o.user_name == username).FirstOrDefault();
                ajaxClass.Users use = new ajaxClass.Users();
                use.user_name = Use.user_name;
                use.sex = Use.sex;
                use.tel_phone = Use.tel_phone;
                use.head_img = Use.head_img;
                use.introduce = Use.introduce;
                use.user_type = Use.user_type;
                use.creat_time = Use.creat_time;
                list.Add(use);
                return Content(JsonConvert.SerializeObject(list));
            }
        }

        public ActionResult GetCollects()
        {
            List<ajaxClass.Collects> list = new List<ajaxClass.Collects>();
            int userId = (int)Session["User_id"];
            var Col1 = db.Collects.Where(o => o.users_id == userId);
            foreach (var Col in Col1)
            {
                ajaxClass.Collects col = new ajaxClass.Collects();
                int contentNumArt = db.Col_art.Where(o => o.collects_id == Col.id).Count();
                int contentNumSci = db.Col_sci.Where(o => o.collects_id == Col.id).Count();
                int contentNumNews = db.Col_news.Where(o => o.collects_id == Col.id).Count();
                int contentNum = contentNumArt + contentNumSci + contentNumNews;
                col.col_name = Col.col_name;
                col.introduces = Col.introduces;
                col.users_id = Col.users_id;
                col.id = Col.id;
                col.contentNum = contentNum;
                list.Add(col);
            }
            return Content(JsonConvert.SerializeObject(list));
        }

        public ActionResult GetCol_art(col_art accept)
        {
            List<col_art> list = new List<col_art>();
            var tableCol = db.Col_art.Where(o => o.collects_id == accept.collects_id);
            foreach (var Col_art in tableCol)
            {
                col_art col_art = new col_art();
                col_art.id = Col_art.id;
                col_art.collects_id = Col_art.collects_id;
                col_art.art_id = Col_art.art_id;
                list.Add(col_art);
            }
            return Content(JsonConvert.SerializeObject(list));
        }
        public ActionResult GetCol_sci(Col_sci accept)
        {
            List<Col_sci> list = new List<Col_sci>();
            var tableCol = db.Col_sci.Where(o => o.collects_id == accept.collects_id);
            foreach (var Col_sci in tableCol)
            {
                Col_sci col_sci = new Col_sci();
                col_sci.id = Col_sci.id;
                col_sci.collects_id = Col_sci.collects_id;
                col_sci.sci_id = Col_sci.sci_id;
                list.Add(col_sci);
            }
            return Content(JsonConvert.SerializeObject(list));
        }

        public ActionResult GetCol_news(col_news accept)
        {
            List<col_news> list = new List<col_news>();
            var tableCol = db.Col_news.Where(o => o.collects_id == accept.collects_id);
            foreach (var Col_news in tableCol)
            {
                col_news col_news = new col_news();
                col_news.id = Col_news.id;
                col_news.collects_id = Col_news.collects_id;
                col_news.news_id = Col_news.news_id;
                list.Add(col_news);
            }
            return Content(JsonConvert.SerializeObject(list));
        }

        public ActionResult GetArticles(Model.Articles accept)
        {
            List<ajaxClass.Articles> list = new List<ajaxClass.Articles>();
            var Arts = db.Articles.Where(o => o.users_id == accept.users_id);
            foreach (var Art in Arts)
            {
                ajaxClass.Articles art = new ajaxClass.Articles();
                art.id = Art.id;
                art.users_id = Art.users_id;
                art.title = Art.title;
                art.content = Art.content;
                art.like_num = (int)Art.like_num;
                art.comment_num = (int)Art.comment_num;
                art.views_num = (int)Art.views_num;
                art.creat_time = (DateTime)Art.creat_time;
                list.Add(art);
            }
            return Content(JsonConvert.SerializeObject(list));
        }

        public ActionResult GetQuestions(Model.Articles accept)
        {
            List<ajaxClass.Questions> list = new List<ajaxClass.Questions>();
            var Ques = db.Questions.Where(o => o.users_id == accept.users_id);
            foreach (var Que in Ques)
            {
                int askNum = db.Answers.Where(o => o.question_id == Que.id).Count();
                ajaxClass.Questions que = new ajaxClass.Questions();
                que.question_content = Que.quesition_content;
                que.creat_time = (DateTime)Que.creat_time;
                que.askNum = askNum;
            }
            return Content(JsonConvert.SerializeObject(list));
        }

        public void ModifyUserInfo(ajaxClass.Users accept)
        {

        }

        public ActionResult DeleteBlog(ajaxClass.Articles accept)
        {
            Model.Articles rec = db.Articles.Where(o => o.id == accept.id).FirstOrDefault();
            db.Articles.Remove(rec);
            db.SaveChanges();
            return Content("删除成功!");
        }
    }
}