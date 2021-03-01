using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface IAnswer_Comment
    {
        IEnumerable<Answer_Comment> GetAnswer_Comments();
        Answer_Comment GetAnswerCommentById(int? id);
        void RemoveAnswer_Comment(Answer_Comment answerComment);
        void AddAnswer_Comment(Answer_Comment answerComment);
        void EditAnswer_Comment(Answer_Comment answerComment);
    }
}
