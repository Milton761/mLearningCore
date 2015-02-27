using MLearning.Core.Configuration;
using MLearning.Core.Services;
using MLearning.Web.Models;
using MLearning.Web.Singleton;
using MLearningDB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MLearning.Web.Controllers
{
    public class QuizController : MLController
    {
      

                
         private IMLearningService _mLearningService;
         public QuizController()
             : base()
        {
            _mLearningService = ServiceManager.GetService();
        }


         #region CRUD quiz
         public ActionResult Create(int LO_id)
         {
              LOID = LO_id;              
             return View("QuizCreate");
         }
        //
        // POST: /Quiz/Create
        [HttpPost]
        async public Task<ActionResult> Create(Quiz model)
        {
            try
            {
                model.LearningObject_id = LOID;
                model.created_at = DateTime.UtcNow;
                model.updated_at = DateTime.UtcNow;

                int quizId = await _mLearningService.CreateObject<Quiz>(model,q=>q.id);


                /*foreach (var question in model.Questions)
                {
                    question.Question.Quiz_id = quizId;
                    question.Question.created_at = DateTime.UtcNow;
                    question.Question.updated_at = DateTime.UtcNow;

                    int questionId = await _mLearningService.CreateObject<Question>(question.Question, q => q.id);


                    foreach (var option  in question.Options)
                    {
                        option.Question_id = questionId;
                        option.created_at = DateTime.UtcNow;
                        option.updated_at = DateTime.UtcNow;
                        await _mLearningService.CreateObject<QuestionOption>(option, o => o.id);
                    }
                }*/


               // return Json(Url.Action("EditLO", "Publisher", new { lo_id = LOID }));

                return RedirectToAction("EditLO", "Publisher");
            }
            catch
            {
                return View("QuizCreate");
            }
        }

        //
        // GET: /Quiz/Edit/5
        public async Task<ActionResult> Edit(int quiz_id)
        {
            var quiz = await _mLearningService.GetObjectWithId<Quiz>(quiz_id);
            var questions = await _mLearningService.GetQuestionsByQuiz(quiz_id);
            LOID = quiz.LearningObject_id;
            return View("QuizEdit", new QuizQuestionsModel { Quiz = quiz, Questions = questions});
        }

        //
        // POST: /Quiz/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int quiz_id, QuizQuestionsModel qqm)
        {

            try
            {
                await _mLearningService.UpdateObject<Quiz>(qqm.Quiz);
                return RedirectToAction("EditLO", "Publisher", new { lo_id = LOID });
            }
            catch(Exception e)
            {
                Debug.Print(e.Message);
            }
            var quiz = await _mLearningService.GetObjectWithId<Quiz>(quiz_id);
            var questions = await _mLearningService.GetQuestionsByQuiz(quiz_id);
            return View("QuizEdit", new QuizQuestionsModel { Quiz = quiz, Questions = questions });
        }

        //
        // GET: /Quiz/Delete/5
        public async Task<ActionResult> Delete(int quiz_id)
        {
            var todelete = await _mLearningService.GetObjectWithId<Quiz>(quiz_id);
            LOID = todelete.LearningObject_id;
            return View("QuizDelete",todelete);
        }

        //
        // POST: /Quiz/Delete/5
        [HttpPost]
        public ActionResult Delete(int quiz_id, Quiz todelete)
        {
            try
            {
                todelete.id = quiz_id;
                _mLearningService.DeleteObject<Quiz>(todelete);
                return RedirectToAction("EditLO", "Publisher", new { lo_id = LOID });
            }
            catch
            {
                return View("QuizDelete", todelete);
            }
        }
        #endregion

        #region CRUD question
        // GET: /Quiz/CreateQuestion
        public ActionResult CreateQuestion(int quiz_id)
        {
            QuizID = quiz_id;
            return View("QuestionCreate");
        }

        // POST: /Quiz/CreateQuestion
        [HttpPost]
        public async Task<ActionResult> CreateQuestion(int quiz_id, Question model)
        {
            try
            {
                model.Quiz_id = QuizID;
                model.created_at = DateTime.UtcNow;
                model.updated_at = DateTime.UtcNow;

                int quizId = await _mLearningService.CreateObject<Question>(model, q => q.id);

                return RedirectToAction("Edit", "Quiz", new { quiz_id = QuizID });
            }
            catch
            {
                return View("QuestionCreate");
            }
        }

        //
        // GET: /Quiz/EditQuestion/5
        public async Task<ActionResult> EditQuestion(int question_id)
        {
            var question = await _mLearningService.GetObjectWithId<Question>(question_id);
            var options = await _mLearningService.GetOptionsByQuestion(question_id);
            QuizID = question.Quiz_id;
            return View("QuestionEdit", new QuestionModel { Question = question, Options = options });
        }

        //
        // POST: /Quiz/EditQuestion/5
        [HttpPost]
        public async Task<ActionResult> EditQuestion(int question_id, QuestionModel qm)
        {

            try
            {
                await _mLearningService.UpdateObject<Question>(qm.Question);
                return RedirectToAction("Edit", "Quiz", new { quiz_id = QuizID });
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            var question = await _mLearningService.GetObjectWithId<Question>(question_id);
            var options = await _mLearningService.GetOptionsByQuestion(question_id);
            QuizID = question.Quiz_id;
            return View("QuestionEdit", new QuestionModel { Question = question, Options = options });
        }

        //
        // GET: /Quiz/DeleteQuestion/5
        public async Task<ActionResult> DeleteQuestion(int question_id)
        {
            var todelete = await _mLearningService.GetObjectWithId<Question>(question_id);
            QuizID = todelete.Quiz_id;
            return View("QuestionDelete", todelete);
        }

        //
        // POST: /Quiz/DeleteQuestion/5
        [HttpPost]
        public ActionResult DeleteQuestion(int question_id, Question todelete)
        {
            try
            {
                todelete.id = question_id;
                _mLearningService.DeleteObject<Question>(todelete);
                return RedirectToAction("Edit", "Quiz", new { quiz_id = QuizID });
            }
            catch
            {
                return View("QuestionDelete", todelete);
            }
        }

        #endregion

        #region CRUD q_option
        //
        // GET: /Quiz/CreateOption
        public ActionResult CreateOption(int question_id)
        {
            QuestionID = question_id;
            return View("OptionCreate");
        }

        //
        // POST: /Quiz/CreateOption
        [HttpPost]
        public async Task<ActionResult> CreateOption(int question_id, QuestionOption model)
        {
            try
            {
                model.Question_id = question_id;
                model.created_at = DateTime.UtcNow;
                model.updated_at = DateTime.UtcNow;

                int quizId = await _mLearningService.CreateObject<QuestionOption>(model, q => q.id);

                return RedirectToAction("EditQuestion", "Quiz", new { question_id = QuestionID });
            }
            catch
            {
                return View("OptionCreate");
            }
        }

        //
        // GET: /Quiz/EditQuestion/5
        public async Task<ActionResult> EditOption(int option_id)
        {
            var option = await _mLearningService.GetObjectWithId<QuestionOption>(option_id);
            QuestionID = option.Question_id;
            return View("OptionEdit", option);
        }

        //
        // POST: /Quiz/EditOption/5
        [HttpPost]
        public async Task<ActionResult> EditOption(int option_id, QuestionOption qo)
        {

            try
            {
                await _mLearningService.UpdateObject<QuestionOption>(qo);
                return RedirectToAction("EditQuestion", "Quiz", new { question_id = QuestionID });
            }
            catch (Exception e)
            {
                Debug.Print(e.Message);
            }
            var option = await _mLearningService.GetObjectWithId<QuestionOption>(option_id);
            QuestionID = option.Question_id;
            return View("OptionEdit", option);
        }

        //
        // GET: /Quiz/DeleteOption/5
        public async Task<ActionResult> DeleteOption(int option_id)
        {
            var todelete = await _mLearningService.GetObjectWithId<QuestionOption>(option_id);
            QuestionID = todelete.Question_id;
            return View("OptionDelete", todelete);
        }

        //
        // POST: /Quiz/DeleteOption/5
        [HttpPost]
        public ActionResult DeleteOption(int option_id, QuestionOption todelete)
        {
            try
            {
                todelete.id = option_id;
                _mLearningService.DeleteObject<QuestionOption>(todelete);
                return RedirectToAction("EditQuestion", "Quiz", new { question_id = QuestionID });
            }
            catch
            {
                return View("OptionDelete", todelete);
            }
        }
        #endregion
    }
}
