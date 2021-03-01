using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface Ilikes_news
    {
        IEnumerable<likes_news> GetLikesNews();
        likes_news GetLikesNewsById(int? id);
        void RemoveLikesNews(likes_news likesNews);
        void AddLikesNews(likes_news likesNews);
        void EditLikesNews(likes_news likesNews);
    }
}
