using MLearningDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLearning.Core.Entities
{
    public class LearningObjectTag
    {
        public int id { get; set; }
        public int lo_id { get; set; }
        public int tag_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

    public class tag_by_lo : Tag
    {
        public int lo_id { get; set; }
    }
}
