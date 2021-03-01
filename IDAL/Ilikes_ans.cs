using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface Ilikes_ans
    {
        IEnumerable<likes_ans> GetLikesAns();
        likes_ans GetLikesAnsById(int? id);
        void RemoveLikesAns(likes_ans likesAns);
        void AddLikesAns(likes_ans likesAns);
        void EditLikesAns(likes_ans likesAns);
    }
}
