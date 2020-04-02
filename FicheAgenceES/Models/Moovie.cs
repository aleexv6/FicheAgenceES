using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FicheAgenceES.Models
{
    public class Moovie    {
        public List<string> directors { get; set; }
        public string realease_date { get; set; }
        public string image_url { get; set; }
        public int rank { get; set; }
        public string running_time_secs { get; set; }
        public float rating { get; set; }
        public List<string> genres { get; set; }
        public string plot { get; set; }
        public string title { get; set; }
        public List<string> actors { get; set; }
        public int year { get; set; }
    }
}