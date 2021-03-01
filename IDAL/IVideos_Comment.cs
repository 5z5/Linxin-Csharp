using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface IVideos_Comment
    {
        IEnumerable<Videos_Comment> GetVideosComments();
        Videos_Comment GetVideosCommentById(int? id);
        void RemoveVideosComment(Videos_Comment videosComment);
        void AddVideosComment(Videos_Comment videosComment);
        void EditVideosComment(Videos_Comment videosComment);
    }
}
