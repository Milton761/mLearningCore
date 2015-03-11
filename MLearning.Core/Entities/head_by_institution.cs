using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLearning.Core.Entities
{
    public class head_by_institution
    {

        public int id { get; set; }
        public int head_id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }

        public string password { get; set; }

        public int institution_id { get; set; }

        public string institution_name { get; set; }

        public DateTime icreated_at { get; set; }
        public DateTime iupdated_at { get; set; }

        public string country { get; set; }
        public string region { get; set; }
        public string address_line_1 { get; set; }
        public string city { get; set; }
        public int postal_code { get; set; }
        public int telephone { get; set; }
        public string email { get; set; }
        public string website_address { get; set; }
        public string notes { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
