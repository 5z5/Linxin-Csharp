using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface INews_Comment
    {
        IEnumerable<News_Comment> GetLikesNewsComments();
        News_Comment GetNewsCommentById(int? id);
        void RemoveNewsComment(News_Comment newsComment);
        void AddNewsComment(News_Comment newsComment);
        void EditNewsComment(News_Comment newsComment);
    }
}
