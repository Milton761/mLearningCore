﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLearning.Core.Entities
{
    public class lo_owner
    {
        public int id {get; set;}
        public string title {get; set;}
        public string description {get; set;}
        public string url_cover {get; set;}
        public string created_at {get; set;}
        public string lo_type {get; set;}
        public string fullname {get; set;}
        public string email { get; set; }
    }
}
