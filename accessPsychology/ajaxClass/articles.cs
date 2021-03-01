using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace accessPsychology.ajaxClass
{
    public class Articles
    {
        public int id { get; set; }
        public int users_id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int like_num { get; set; }
        public int comment_num { get; set; }
        public int views_num { get; set; }
        public DateTime creat_time { get; set; }
    }
}