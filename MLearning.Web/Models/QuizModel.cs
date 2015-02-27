using MLearning.Core.Entities;
using MLearningDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MLearning.Web.Models
{
    public class QuizModel
    {
        public Quiz Quiz { get; set;}

        public IEnumerable<QuestionModel> Questions { get; set; }
    }

    public class QuestionModel
    {
        public Question Question { get; set; }

        public IEnumerable<QuestionOption> Options { get; set; }
    }
}