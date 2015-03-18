using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLearning.Core.Entities
{
    public class publisher_by_institution
    {

        public int id { get; set; }
        public int publisher_id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string fullname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }

        public string title { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public int telephone { get; set; }


        public int institution_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
