using MLearning.Core.Entities;
using MLearningDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLearning.Web.Models
{
    public class ManageCircleViewModel
    {
        public List<lo_in_circle> LOInCircle { get; set; }

        public List<LearningObject> LOPublic { get; set; }
        public List<consumer_by_circle> ConsumerInCircle { get; set; }
        public List<consumer_by_institution> ConsumerInInst { get; set; }

    }
}