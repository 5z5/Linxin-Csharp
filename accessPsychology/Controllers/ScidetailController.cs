using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using accessPsychology.Models;
using Newtonsoft.Json;
using Model;

namespace accessPsychology.Controllers
{
    public class ScidetailController : Controller
    {
        LinxinaccessEntities linxinDb = new LinxinaccessEntities();
        SciClass SciClass = new SciClass();
        // GET: Scidetail
        public ActionResult sci_article(int id)//科普文章id
        {
            SciClass.sci_Articles = linxinDb.Sci_articles.Where(n => n.id == id).Select(n => n);
            SciClass.sci_Comments = from n in linxinDb.Sci_Comment
                                    where n.article_id == id
                                    where n.parent_comment_id == null
                                    select n;
            ViewBag.likenum = linxinDb.likes_sci.Where(n => n.sci_id == id).Count();
            //HttpContext.Session["article_id"] = id;
            return View(SciClass);
        }

        public ActionResult userphoto(int id)
        {
            var src = linxinDb.Users.Where(n => n.id == id).Select(n => n.head_img).First();

            return Content(src);
        }

        public ActionResult nickname(int id)
        {
            var src = linxinDb.Users.Where(n => n.id == id).Select(n => n.user_name).First();

            return Content(src);
        }

        public ActionResult Comment(int? id)
        {
            if (id != null)
            {
                ViewBag.comment = from n in linxinDb.Sci_Comment
                                  where n.parent_comment_id == id
                                  select n;
                int userid = linxinDb.Sci_Comment.Where(n => n.id == id).Select(n => n.users_id).FirstOrDefault();
                ViewBag.parentName = linxinDb.Users.Where(n => n.id == userid).Select(n => n.user_name).FirstOrDefault();
            }
            else
            {
                ViewBag.comment = null;
            }
            return View();
        }

        //评论
        public ActionResult sciComment()
        {
            Sci_Comment sci_Comment = new Sci_Comment();
            sci_Comment.article_id = Convert.ToInt32(Request["article_id"]);
            sci_Comment.users_id = Convert.ToInt32(Session["User_id"]);
            sci_Comment.content = Request["comment"];
            int id  = sci_Comment.article_id;
            linxinDb.Sci_Comment.Add(sci_Comment);
            linxinDb.SaveChanges();
            SciClass.sci_Articles = linxinDb.Sci_articles.Where(n => n.id == id).Select(n => n);
            SciClass.sci_Comments = from n in linxinDb.Sci_Comment
                                    where n.article_id == id
                                    where n.parent_comment_id == null
                                    select n;
            ViewBag.likenum = linxinDb.likes_sci.Where(n => n.sci_id == id).Count();
            return View("sci_article",SciClass);
        }

        public ActionResult replay()
        {
            Sci_Comment sci_Comment = new Sci_Comment();
            sci_Comment.article_id = Convert.ToInt32(Request["article_id"]);
            sci_Comment.parent_comment_id = Convert.ToInt32(Request["comment_id"]);
            sci_Comment.content = Request["content"];
            sci_Comment.users_id = Convert.ToInt32(Session["User_id"]);
            linxinDb.Sci_Comment.Add(sci_Comment);
            linxinDb.SaveChanges();
            int id = sci_Comment.article_id;
            SciClass.sci_Articles = linxinDb.Sci_articles.Where(n => n.id == id).Select(n => n);
            SciClass.sci_Comments = from n in linxinDb.Sci_Comment
                                    where n.article_id == id
                                    where n.parent_comment_id == null
                                    select n;
            ViewBag.likenum = linxinDb.likes_sci.Where(n => n.sci_id == id).Count();
            return View("sci_article", SciClass);
        }

        public ActionResult like(int id)
        {
            int userid = Convert.ToInt32(Session["User_id"]);
            int num = linxinDb.likes_sci.Where(n => n.users_id == userid).Where(n => n.sci_id == id).Count();
            if (num > 0)
            {
                likes_sci likes = new likes_sci();
                likes.id = linxinDb.likes_sci.Where(n => n.users_id == userid).Where(n => n.sci_id == id).Select(n => n.id).FirstOrDefault();
                var like = linxinDb.likes_sci.Find(likes.id);
                linxinDb.likes_sci.Remove(like);
                linxinDb.SaveChanges();
            }
            else
            {
                likes_sci likes = new likes_sci();
                likes.sci_id = id;
                likes.users_id = userid;
                linxinDb.likes_sci.Add(likes);
                linxinDb.SaveChanges();
            }
            SciClass.sci_Articles = linxinDb.Sci_articles.Where(n => n.id == id).Select(n => n);
            SciClass.sci_Comments = from n in linxinDb.Sci_Comment
                                    where n.article_id == id
                                    where n.parent_comment_id == null
                                    select n;
            ViewBag.likenum = linxinDb.likes_sci.Where(n => n.sci_id == id).Count();
            return View("sci_article",SciClass);
        }

        public ActionResult Comlike(int id)//评论表的id，点赞评论关系表
        {
            int userid = Convert.ToInt32(Session["User_id"]);
            int num = linxinDb.likes_sci_comment.Where(n => n.users_id == userid).Where(n => n.sci_comment_id == id).Count();
            if (num > 0)
            {
                likes_sci_comment likes = new likes_sci_comment();
                likes.id = linxinDb.likes_sci_comment.Where(n => n.users_id == userid).Where(n => n.sci_comment_id == id).Select(n => n.id).FirstOrDefault();
                var like = linxinDb.likes_sci_comment.Find(likes.id);
                linxinDb.likes_sci_comment.Remove(like);
                linxinDb.SaveChanges();
            }
            else
            {
                likes_sci_comment likes = new likes_sci_comment();
                likes.sci_comment_id = id;
                likes.users_id = userid;
                linxinDb.likes_sci_comment.Add(likes);
                linxinDb.SaveChanges();
            }
            int artid = linxinDb.Sci_Comment.Where(n => n.id == id).Select(n => n.article_id).FirstOrDefault();
            SciClass.sci_Articles = linxinDb.Sci_articles.Where(n => n.id == artid).Select(n => n);
            SciClass.sci_Comments = from n in linxinDb.Sci_Comment
                                    where n.article_id == artid
                                    where n.parent_comment_id == null
                                    select n;
            ViewBag.likenum = linxinDb.likes_sci.Where(n => n.sci_id == artid).Count();
            return View("sci_article", SciClass);
        }

        public ActionResult Num(int id)
        {
            int likesnum = linxinDb.likes_sci_comment.Where(n => n.sci_comment_id == id).Count();
            return Content(Convert.ToString(likesnum));
        }
    }
}