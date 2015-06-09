using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLearning.Core.Entities
{
    public class consumer_by_institution
    {

        public int id { get; set; }

        public int consumer_id { get; set; }
        
        public string name { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }

        public int institution_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
