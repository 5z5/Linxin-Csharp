using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface Ilikes_sci_comment
    {
        IEnumerable<likes_sci_comment> GetLikesSciComments();
        likes_sci_comment GetLikesSciCommentById(int? id);
        void RemoveLikesSciComment(likes_sci_comment likesSciComment);
        void AddLikesSciComment(likes_sci_comment likesSciComment);
        void EditLikesSciComment(likes_sci_comment likesSciComment);
    }
}
