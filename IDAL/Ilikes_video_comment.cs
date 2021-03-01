using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface Ilikes_video_comment
    {
        IEnumerable<likes_video_comment> GetLikesVideoComments();
        likes_video_comment GetLikesVideoCommentById(int? id);
        void RemoveLikesVideoComment(likes_video_comment likesVideoComment);
        void AddLikesVideoComment(likes_video_comment likesVideoComment);
        void EditLikesVideoComment(likes_video_comment likesVideoComment);
    }
}
