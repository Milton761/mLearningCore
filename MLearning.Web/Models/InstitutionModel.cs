using MLearning.Core.Entities;
using MLearningDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLearning.Web.Models
{
    public class InstitutionModel
    {
        public Institution Inst { get; set; }
        public User User { get; set; }
        public Head Head { get; set; }
    }
}