using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface IArticle
    {
        IEnumerable<Articles> GetArticles();
        Articles GetArticleById(int? id);
        void RemoveArticle(Articles article);
        void AddArticle(Articles article);
        void EditArticle(Articles article);
    }
}
