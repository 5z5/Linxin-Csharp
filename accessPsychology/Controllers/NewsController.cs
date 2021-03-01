using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using accessPsychology.Models;
using Model;

namespace accessPsychology.Controllers
{
    public class NewsController : Controller
    {
        LinxinaccessEntities linxinDb = new LinxinaccessEntities();
        NewsClass newsClass = new NewsClass();
        // GET: News
        public ActionResult News_article(int id)
        {
            newsClass.psy_News = linxinDb.Psy_news.Where(n => n.id == id).Select(n => n);
            newsClass.news_Comments = from n in linxinDb.News_Comment
                                    where n.article_id == id
                                    where n.parent_comment_id == null
                                    select n;
            ViewBag.likenum = linxinDb.likes_news.Where(n => n.news_id == id).Count();
            return View(newsClass);
        }

        public ActionResult Comment(int? id)
        {
            if (id != null)
            {
                ViewBag.comment = from n in linxinDb.News_Comment
                                  where n.parent_comment_id == id
                                  select n;
                int userid = linxinDb.News_Comment.Where(n => n.id == id).Select(n => n.users_id).FirstOrDefault();
                ViewBag.parentName = linxinDb.Users.Where(n => n.id == userid).Select(n => n.user_name).FirstOrDefault();
            }
            else
            {
                ViewBag.comment = null;
            }
            return View();
        }


        public ActionResult Newscomment()
        {
            News_Comment news_Comment = new News_Comment();
            news_Comment.article_id = Convert.ToInt32(Request["article_id"]);
            news_Comment.users_id = Convert.ToInt32(Session["User_id"]);
            news_Comment.content = Request["comment"];
            int id = news_Comment.article_id;
            linxinDb.News_Comment.Add(news_Comment);
            linxinDb.SaveChanges();
            newsClass.psy_News = linxinDb.Psy_news.Where(n => n.id == id).Select(n => n);
            newsClass.news_Comments = from n in linxinDb.News_Comment
                                      where n.article_id == id
                                      where n.parent_comment_id == null
                                      select n;
            ViewBag.likenum = linxinDb.likes_news.Where(n => n.news_id == id).Count();
            return View("News_article",newsClass);
        }

        public ActionResult replay()
        {
            News_Comment news_Comment = new News_Comment();
            news_Comment.article_id = Convert.ToInt32(Request["article_id"]);
            news_Comment.parent_comment_id = Convert.ToInt32(Request["comment_id"]);
            news_Comment.content = Request["content"];
            news_Comment.users_id = Convert.ToInt32(Session["User_id"]);
            linxinDb.News_Comment.Add(news_Comment);
            linxinDb.SaveChanges();
            int id = news_Comment.article_id;
            newsClass.psy_News = linxinDb.Psy_news.Where(n => n.id == id).Select(n => n);
            newsClass.news_Comments = from n in linxinDb.News_Comment
                                      where n.article_id == id
                                      where n.parent_comment_id == null
                                      select n;
            ViewBag.likenum = linxinDb.likes_news.Where(n => n.news_id == id).Count();
            return View("News_article", newsClass);
        }

        public ActionResult like(int id)
        {
            int userid = Convert.ToInt32(Session["User_id"]);
            int num = linxinDb.likes_news.Where(n => n.users_id == userid ).Where(n => n.news_id == id).Count();
            if (num > 0)
            {
                likes_news likes = new likes_news();
                likes.id = linxinDb.likes_news.Where(n => n.users_id == userid).Where(n => n.news_id == id).Select(n => n.id).FirstOrDefault();
                var like = linxinDb.likes_news.Find(likes.id);
                linxinDb.likes_news.Remove(like);
                linxinDb.SaveChanges();
            }
            else
            {
                likes_news likes = new likes_news();
                likes.news_id = id;
                likes.users_id = userid;
                linxinDb.likes_news.Add(likes);
                linxinDb.SaveChanges();
            }
            newsClass.psy_News = linxinDb.Psy_news.Where(n => n.id == id).Select(n => n);
            newsClass.news_Comments = from n in linxinDb.News_Comment
                                      where n.article_id == id
                                      where n.parent_comment_id == null
                                      select n;
            ViewBag.likenum = linxinDb.likes_news.Where(n => n.news_id == id).Count();
            return View("News_article", newsClass);
        }

        public ActionResult Comlike(int id)
        {
            int userid = Convert.ToInt32(Session["User_id"]);
            int num = linxinDb.likes_news_comment.Where(n => n.users_id == userid).Where(n => n.news_comment_id == id).Count();
            if (num > 0)
            {
                likes_news_comment likes = new likes_news_comment();
                likes.id = linxinDb.likes_news_comment.Where(n => n.users_id == userid).Where(n => n.news_comment_id == id).Select(n => n.id).FirstOrDefault();
                var like = linxinDb.likes_news_comment.Find(likes.id);
                linxinDb.likes_news_comment.Remove(like);
                linxinDb.SaveChanges();
            }
            else
            {
                likes_news_comment likes = new likes_news_comment();
                likes.news_comment_id = id;
                likes.users_id = userid;
                linxinDb.likes_news_comment.Add(likes);
                linxinDb.SaveChanges();
            }
            int artid = linxinDb.News_Comment.Where(n => n.id == id).Select(n => n.article_id).FirstOrDefault();
            newsClass.psy_News = linxinDb.Psy_news.Where(n => n.id == artid).Select(n => n);
            newsClass.news_Comments = from n in linxinDb.News_Comment
                                      where n.article_id == artid
                                      where n.parent_comment_id == null
                                      select n;
            ViewBag.likenum = linxinDb.likes_news.Where(n => n.news_id == artid).Count();
            return View("News_article", newsClass);
        }

        public ActionResult Num(int id)
        {
            int likesnum = linxinDb.likes_news_comment.Where(n => n.news_comment_id == id).Count();
            return Content(Convert.ToString(likesnum));
        }
    }
}