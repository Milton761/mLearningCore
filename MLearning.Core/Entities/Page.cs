using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLearning.Core.Entities
{
    public class Page
    {
        public int id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string url_img { get; set; }
        public string content { get; set; }
        public int lo_id { get; set; }
        public int? LOsection_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }


    public class JsonPage
    {
        public string description { get; set; }
        public string title { get; set; }
        public string xml_content { get; set; }

        public string url_img { get; set; }
    }
}
