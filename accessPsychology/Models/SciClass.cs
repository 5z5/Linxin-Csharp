using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace accessPsychology.Models
{
    public class SciClass
    {
        public IEnumerable<Sci_articles> sci_Articles { get; set; }
        public IEnumerable<Sci_Comment> sci_Comments { get; set; }
        public IEnumerable<Users> users { get; set; }
    }
}