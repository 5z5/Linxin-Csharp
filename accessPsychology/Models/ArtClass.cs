using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace accessPsychology.Models
{
    public class ArtClass
    {
        public IEnumerable<Articles> articles { get; set; }
        public IEnumerable<Art_Comment> art_Comments { get; set; }
        public IEnumerable<Users> users { get; set; }
    }
}