using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface Ilikes_news_comment
    {
        IEnumerable<likes_news_comment> GetLikesNewsComments();
        likes_news_comment GetLikesNewsCommentById(int? id);
        void RemoveLikesNewsComment(likes_news_comment likesNewsComment);
        void AddLikesNewsComment(likes_news_comment likesNewsComment);
        void EditLikesNewsComment(likes_news_comment likesNewsComment);
    }
}
