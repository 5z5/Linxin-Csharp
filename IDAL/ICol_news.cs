using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface ICol_news
    {
        IEnumerable<Col_news> GetColNews();
        Col_news GetColNewsById(int? id);
        void RemoveColNews(Col_news colNews);
        void AddColNews(Col_news colNews);
        void EditColNews(Col_news colNews);
    }
}
