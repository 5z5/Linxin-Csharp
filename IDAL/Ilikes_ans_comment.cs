using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface Ilikes_ans_comment
    {
        IEnumerable<likes_ans_comment> GetLikesAnsComments();
        likes_ans_comment GetLikesAnsCommentById(int? id);
        void RemoveLikesAnsComment(likes_ans_comment likesAnsComment);
        void AddLikesAnsComment(likes_ans_comment likesAnsComment);
        void EditLikesAnsComment(likes_ans_comment likesAnsComment);
    }
}
