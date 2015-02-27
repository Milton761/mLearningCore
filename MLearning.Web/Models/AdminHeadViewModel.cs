using MLearning.Core.Entities;
using MLearningDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLearning.Web.Models
{
    public class AdminHeadViewModel
    {
        public List<publisher_by_institution> Publishers { get; set; }

        public List<consumer_by_institution> Consumers { get; set; }
    }



    public class PublisherViewModel
    {

        public User User { get; set; }
        public Publisher Publisher { get; set; }
    }


    public class ConsumerViewModel
    {
        public User User { get; set; }
        public Consumer Consumer { get; set; }
    
    }


}