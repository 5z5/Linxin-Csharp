using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    interface ISci_Comment
    {
        IEnumerable<Sci_Comment> GetSciComments();
        Sci_Comment GetSciCommentById(int? id);
        void RemoveSciComment(Sci_Comment sciComment);
        void AddSciComment(Sci_Comment sciComment);
        void EditSciComment(Sci_Comment sciComment);
    }
}
