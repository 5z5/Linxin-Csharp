using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace accessPsychology.ajaxClass
{
    public class Answer
    {
        public int users_id { set; get; }
        public int question_id { get; set; }
        public string answer_content { get; set; }
        public int likes_num { get; set; }
        public DateTime creat_time { get; set; }
    }
}