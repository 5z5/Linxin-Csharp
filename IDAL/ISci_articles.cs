using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface ISci_articles
    {
        IEnumerable<Sci_articles> GetSciArticles();
        Sci_articles GetSciArticleById(int? id);
        void RemoveSciArticle(Sci_articles sciArticles);
        void AddSciArticle(Sci_articles sciArticles);
        void EditSciArticle(Sci_articles sciArticles);
    }
}
