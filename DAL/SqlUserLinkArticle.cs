using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
    class SqlUserLinkArticle:IUserLinkArticle
    {
        LinxinaccessEntities db = DBContextFactory.CreateDbContext();
        public IEnumerable<UserLinkArticleData> GetUserLinkArticle()
        {
            var query = from a in db.Users
                        join c in db.Articles
                        on a.id equals c.users_id
                        select new
                        {
                            id = c.id,
                            users_id = c.users_id,
                            title = c.title,
                            content = c.content,
                            like_num = c.like_num,
                            comment_num = c.comment_num,
                            views_num = c.views_num,
                            creat_time = c.creat_time,
                            head_img = a.head_img,
                            user_name = a.user_name
                        };
            List<UserLinkArticleData> s = new List<UserLinkArticleData>();
            UserLinkArticleData rec = new UserLinkArticleData();
            foreach(var uA in query)
            {
                rec.id = uA.id;
                rec.users_id = uA.users_id;
                rec.title = uA.title;
                rec.content = uA.content;
                rec.like_num = (int)uA.like_num;
                rec.comment_num = (int)uA.comment_num;
                rec.views_num = (int)uA.views_num;
                rec.creat_time = (DateTime)uA.creat_time;
                rec.user_photo = uA.head_img;
                rec.user_name = uA.user_name;
                s.Add(rec);
            }
            var ans = s.ToList();
            return ans;
        }
    }
}
