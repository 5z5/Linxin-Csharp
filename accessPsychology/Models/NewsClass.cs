using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace accessPsychology.Models
{
    public class NewsClass
    {
        public IEnumerable<Psy_news> psy_News { get; set; }
        public IEnumerable<News_Comment> news_Comments { get; set; }
        public IEnumerable<Users> users { get; set; }
    }
}