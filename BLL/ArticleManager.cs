using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;
using Model;

namespace BLL
{
    public class ArticleManager
    {
        IArticle iarticle = DataAccess.CreateArticle();
        public IEnumerable<Articles> GetArticles()
        {
            var articles = iarticle.GetArticles();
            return articles;
        }
        public Articles GetArticleById(int? id)
        {
            Articles article = iarticle.GetArticleById(id);
            return article;
        }
        public void RemoveArticle(Articles article)
        {
            iarticle.RemoveArticle(article);
        }
        public void AddArticle(Articles article)
        {
            iarticle.AddArticle(article);
        }
        public void EditArticle(Articles article)
        {
            iarticle.EditArticle(article);
        }
    }
}
