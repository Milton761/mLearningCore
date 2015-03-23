using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLearning.Core.Entities
{
    public class circle_by_owner
    {
        public int id { get; set; }
        public string name { get; set; }
        public int type { get; set; }
        public int? owner_id { get; set; }
        public int institution_id { get; set; }
        public string code { get; set; }
        public string owner_fullname { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
