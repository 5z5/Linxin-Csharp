using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface Ilikes_sci
    {
        IEnumerable<likes_sci> GetLikesSci();
        likes_sci GetLikesSciById(int? id);
        void RemoveLikesSci(likes_sci likesSci);
        void AddLikesSci(likes_sci likesSci);
        void EditLikesSci(likes_sci likesSci);
    }
}
