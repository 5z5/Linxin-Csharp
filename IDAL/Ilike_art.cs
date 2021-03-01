using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface Ilikes_art
    { 
        IEnumerable<likes_art> GetLikesArt();
        likes_art GetLikesArtById(int? id);
        void RemoveLikesArt(likes_art likesArt);
        void AddLikesArt(likes_art likesArt);
        void EditLikesArt(likes_art likesArt);
    }
}
