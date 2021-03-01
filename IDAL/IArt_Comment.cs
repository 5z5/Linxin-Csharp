using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface IArt_Comment
    {
        IEnumerable<Art_Comment> GetArtComments();
        Art_Comment GetArtCommentById(int? id);
        void RemoveArtComment(Art_Comment artComment);
        void AddArtComment(Art_Comment artComment);
        void EditArtComment(Art_Comment artComment);
    }
}
