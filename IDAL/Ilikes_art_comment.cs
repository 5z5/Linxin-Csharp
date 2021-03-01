using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface Ilikes_art_comment
    {
        IEnumerable<likes_art_comment> GetLikesArtComments();
        likes_art_comment GetLikesArtCommentById(int? id);
        void RemoveLikesArtComment(likes_art_comment likesArtComment);
        void AddLikesArtComment(likes_art_comment likesArtComment);
        void EditLikesArtComment(likes_art_comment likesArtComment);
    }
}
