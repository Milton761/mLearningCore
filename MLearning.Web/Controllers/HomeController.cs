
using Microsoft.Owin;
using MLearning.Core.Services;
using MLearning.Web.Singleton;
using MLearningDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MLearning.Web.Controllers
{
    public class HomeController : MLController
    {
        private IMLearningService _mLearningService;

        public HomeController() : base()
        {

            _mLearningService = ServiceManager.GetService();
        }

        public ActionResult Index()
        {
            /* (!Request.IsAuthenticated)
            {
                return 
            }*/
            var a = Request.IsAuthenticated;
            return View();
        }

        public ActionResult Index0()
        {
            return PartialView();
        }

        [Authorize]
        public async Task<ActionResult> editUser()
        {
            if(UserID == default(int)) return PartialView("profileForm");
            var user = await _mLearningService.GetObjectWithId<User>(UserID);
            return PartialView("profileForm",user);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView();
        }
    }
}