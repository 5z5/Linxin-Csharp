using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface IPsy_news
    {
        IEnumerable<Psy_news> GetPsyNews();
        Psy_news GetPsyNewsById(int? id);
        void RemovePsyNews(Psy_news psyNews);
        void AddLikesPsyNews(Psy_news psyNews);
        void EditLikesPsyNews(Psy_news psyNews);
    }
}
