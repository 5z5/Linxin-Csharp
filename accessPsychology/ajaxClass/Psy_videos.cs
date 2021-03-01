using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace accessPsychology.ajaxClass
{
    public class Psy_videos
    {
        public string title { get; set; }
        public string route { get; set; }
        public int likes_num { get; set; }
        public int comment_num { get; set; }
        public DateTime creat_time { get; set; }
    }
}