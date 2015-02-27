using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLearning.Core.Entities
{
    public class lo_comment_with_username
    {
        public int id { get; set; }
        public string text { get; set; }
        public int user_id { get; set; }
        public int lo_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        public string name { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }        
        public string email { get; set; }
        public string image_url { get; set; }
    }
}
