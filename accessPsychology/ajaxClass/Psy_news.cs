using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace accessPsychology.ajaxClass
{
    public class Psy_news
    {
        public string title { get; set; }
        public string content { get; set; }
        public string origin { get; set; }
        public string author { get; set; }
        public int likes_num { get; set; }
        public int comment_num { get; set; }
        public int views_num { get; set; }
        public DateTime creat_time { get; set; }
    }
}