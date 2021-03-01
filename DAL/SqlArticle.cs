using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using Model;

namespace DAL
{
    class SqlArticle:IArticle
    {
        LinxinaccessEntities db = new LinxinaccessEntities();
        public IEnumerable<Articles> GetArticles()
        {
            var articles = db.Articles.ToList();
            return articles;
        }
        public Articles GetArticleById(int? id)
        {
            var article = db.Articles.Find(id);
            return article;
        }
        public void RemoveArticle(Articles article)
        {
            db.Articles.Remove(article);
            db.SaveChanges();
        }
        public void AddArticle(Articles article)
        {
            db.Articles.Add(article);
            db.SaveChanges();
        }
        public void EditArticle(Articles article)
        {
            db.Entry(article).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
