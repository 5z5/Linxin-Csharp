using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using accessPsychology.ajaxClass;
using accessPsychology.Models;
using Model;

namespace accessPsychology.Controllers
{
    public class ArtdetailController : Controller
    {
        LinxinaccessEntities linxinDb = new LinxinaccessEntities();
        ArtClass artClass = new ArtClass();
        // GET: Artdetail
        public ActionResult detail(int? id)
        {
            artClass.articles = linxinDb.Articles.Where(n => n.id == id).Select(n => n);
            artClass.art_Comments = from n in linxinDb.Art_Comment
                                    where n.article_id == id
                                    where n.parent_comment_id == null
                                    select n;
            ViewBag.likenum = linxinDb.likes_art.Where(n => n.art_id == id).Count();
            return View(artClass);
        }

        public ActionResult Artcomment(int? id)
        {
            if (id != null)
            {
                ViewBag.Artcomment = from n in linxinDb.Art_Comment
                                     where n.parent_comment_id == id
                                     select n;
                int userid = linxinDb.Art_Comment.Where(n => n.id == id).Select(n => n.users_id).FirstOrDefault();
                ViewBag.parentName = linxinDb.Users.Where(n => n.id == userid).Select(n => n.user_name).FirstOrDefault();
            }
            else
            {
                ViewBag.Artcomment = null;
            }
            return View();
        }

        public ActionResult Name(int id)
        {
            var Name = linxinDb.Users.Where(n => n.id == id).Select(n => n.user_name).First(); ;
            return Content(Name);
        }

        public ActionResult photo(int id)
        {
            var img = linxinDb.Users.Where(n => n.id == id).Select(n => n.head_img).First();
            return Content(img);
        }

        public ActionResult Comment()
        {
            Art_Comment art_Comment = new Art_Comment();
            art_Comment.article_id = Convert.ToInt32(Request["article_id"]);
            art_Comment.users_id = Convert.ToInt32(Session["User_id"]);
            art_Comment.content = Request["comment"];
            int id = art_Comment.article_id;
            linxinDb.Art_Comment.Add(art_Comment);
            linxinDb.SaveChanges();
            artClass.articles = linxinDb.Articles.Where(n => n.id == id).Select(n => n);
            artClass.art_Comments = from n in linxinDb.Art_Comment
                                    where n.article_id == id
                                    where n.parent_comment_id == null
                                    select n;

            ViewBag.likenum = linxinDb.likes_art.Where(n => n.art_id == id).Count();
            return View("detail", artClass);
        }

        public ActionResult Collects(int id, int art_id)
        {
            ViewBag.collect = linxinDb.Collects.Where(n => n.users_id == id).Select(n => n);
            ViewBag.art_id = art_id;
            return View();
        }

        public ActionResult Col(int col_id,int art_id)
        {
            Col_art col_Art = new Col_art();
            col_Art.collects_id = col_id;
            col_Art.art_id = art_id;
            linxinDb.Col_art.Add(col_Art);
            linxinDb.SaveChanges();
            return Content("<script>;alert('操作成功!')</script>");
        }

        public ActionResult News()
        {
            ViewBag.news = linxinDb.Psy_news.Select(n => n);

            return View();
        }

        public ActionResult Sci()
        {
            ViewBag.sci = linxinDb.Sci_articles.Select(n => n);
            return View();
        }

        public ActionResult Art()
        {
            ViewBag.art = linxinDb.Articles.Select(n => n);
            return View();
        }

        public ActionResult replay()
        {
            Art_Comment art_Comment = new Art_Comment();
            art_Comment.article_id = Convert.ToInt32(Request["article_id"]);
            art_Comment.parent_comment_id = Convert.ToInt32(Request["comment_id"]);
            art_Comment.content = Request["content"];
            art_Comment.users_id = Convert.ToInt32(Session["User_id"]);
            linxinDb.Art_Comment.Add(art_Comment);
            linxinDb.SaveChanges();
            int id = art_Comment.article_id;
            artClass.articles = linxinDb.Articles.Where(n => n.id == id).Select(n => n);
            artClass.art_Comments = from n in linxinDb.Art_Comment
                                    where n.article_id == id
                                    where n.parent_comment_id == null
                                    select n;
            ViewBag.likenum = linxinDb.likes_art.Where(n => n.art_id == id).Count();
            return View("detail", artClass);
        }


        public ActionResult like(int id)
        {
            int userid = Convert.ToInt32(Session["User_id"]);
            int num = linxinDb.likes_art.Where(n => n.users_id == userid).Where(n => n.art_id == id).Count();
            if (num > 0)
            {
                likes_art likes = new likes_art();
                likes.id = linxinDb.likes_art.Where(n => n.users_id == userid).Where(n => n.art_id == id).Select(n => n.id).FirstOrDefault();
                var like = linxinDb.likes_art.Find(likes.id);
                linxinDb.likes_art.Remove(like);
                linxinDb.SaveChanges();
                
            }
            else 
            {
                likes_art likes = new likes_art();
                likes.art_id = id;
                likes.users_id = Convert.ToInt32(Session["User_id"]);
                linxinDb.likes_art.Add(likes);
                linxinDb.SaveChanges();
            }
            artClass.articles = linxinDb.Articles.Where(n => n.id == id).Select(n => n);
            artClass.art_Comments = from n in linxinDb.Art_Comment
                                    where n.article_id == id
                                    where n.parent_comment_id == null
                                    select n;
            ViewBag.likenum = linxinDb.likes_art.Where(n => n.art_id == id).Count();
            return View("detail",artClass);
        }

        public ActionResult Comlike(int id)//评论表的id，点赞评论关系表
        {
            int userid = Convert.ToInt32(Session["User_id"]);
            int num = linxinDb.likes_art_comment.Where(n => n.users_id == userid).Where(n => n.art_comment_id == id).Count();
            if (num > 0)
            {
                likes_art_comment likes = new likes_art_comment();
                likes.id = linxinDb.likes_art_comment.Where(n => n.users_id == userid).Where(n => n.art_comment_id == id).Select(n => n.id).FirstOrDefault();
                var like = linxinDb.likes_art_comment.Find(likes.id);
                linxinDb.likes_art_comment.Remove(like);
                linxinDb.SaveChanges();
            }
            else
            {
                likes_art_comment likes = new likes_art_comment();
                likes.art_comment_id = id;
                likes.users_id = userid;
                linxinDb.likes_art_comment.Add(likes);
                linxinDb.SaveChanges();
            }
            int artid = linxinDb.Art_Comment.Where(n => n.id == id).Select(n => n.article_id).FirstOrDefault();
            artClass.articles = linxinDb.Articles.Where(n => n.id == artid).Select(n => n);
            artClass.art_Comments = from n in linxinDb.Art_Comment
                                    where n.article_id == artid
                                    where n.parent_comment_id == null
                                    select n;
            ViewBag.likenum = linxinDb.likes_art.Where(n => n.art_id == artid).Count();
            return View("detail", artClass);
        }

        public ActionResult Num(int id)
        {
            int likesnum = linxinDb.likes_art_comment.Where(n => n.art_comment_id == id).Count();
            return Content(Convert.ToString(likesnum));
        }

    }
}