using accessPsychology.Utilities;
using System.Web.Mvc;
using accessPsychology.Models;
using System.Collections.Generic;
using accessPsychology.ajaxClass;
using System;
using Newtonsoft.Json;
using System.Linq;
using Model;
using BLL;

namespace accessPsychology.Controllers
{
    public class HomeController : Controller
    {
        LinxinaccessEntities db = new LinxinaccessEntities();
        UserLinkArticleManager userLinkArticleManager = new UserLinkArticleManager();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CaptchaDemo()
        {
            return View();
        }
        public ContentResult GetRandomString()
        {
            string rndStr = CharacterUtility.GenerateRandomString().ToString();
            return Content(rndStr);
        }
        public ActionResult GetArticles()
        {
            List<UserLinkArticleData> list = new List<UserLinkArticleData>();
            var userArticle = userLinkArticleManager.GetUserLinkArticle();
            return NewMethod(list, userArticle);
        }

        private ActionResult NewMethod(List<UserLinkArticleData> list, IEnumerable<UserLinkArticleData> userArticle)
        {
            foreach (var UserArt in userArticle)
            {
                UserLinkArticleData userArt = new UserLinkArticleData();
                userArt.users_id = UserArt.users_id;
                userArt.title = UserArt.title;
                userArt.id = UserArt.id;
                userArt.content = UserArt.content;
                userArt.like_num = (int)UserArt.like_num;
                userArt.comment_num = (int)UserArt.comment_num;
                userArt.views_num = (int)UserArt.views_num;
                userArt.creat_time = (DateTime)UserArt.creat_time;
                userArt.user_photo = UserArt.user_photo;
                userArt.user_name = UserArt.user_name;
                list.Add(userArt);
            }
            return Content(JsonConvert.SerializeObject(list));
        }
    }
}