using MLearning.Core.Entities;
using MLearningDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace MLearning.Web.Models
{
    public class AdminPublisherViewModel
    {

        public List<Circle> Circles { get; set; }

        public List<LearningObject> LearningObjects { get; set; }
    }

    public class LearningObjectTagViewModel
    {
        public LearningObject LO { get; set; }

        public List<SelectableTag> AllTags { get; set; }
    }

    public class SelectableTag
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }

    public class LearningObjectPageViewModel
    {
        public LearningObject LO { get; set; }

        public List<Page> Pages { get; set; }

        public List<Quiz> Quizzes { get; set; }

    }

    public class PageTagViewModel
    {
        public List<tag_by_page> PageTags { get; set; }

        public List<Tag> AllTags { get; set; }
    }

    public class QuizQuestionsModel
    {
        public Quiz Quiz { get; set; }
        //public List<Question> Questions { get; set; }
        public ICollection<QuestionOptionsModel> QuestionsOptions { get; set; }
    }
    public class QuestionOptionsModel
    {
        public Question Question { get; set; }
        public ICollection<QuestionOption> Options { get; set; }
    }
}