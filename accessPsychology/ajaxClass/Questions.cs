using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace accessPsychology.ajaxClass
{
    public class Questions
    {
        public int users_id { get; set; }
        public string question_content { get; set; }
        public string question_detail { get; set; }
        public DateTime creat_time { get;set; }
        public int askNum { get; set; }
    }
}