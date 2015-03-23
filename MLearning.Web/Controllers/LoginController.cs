using Core.Entities.json;
using Core.Repositories;
using Core.Security;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using MLearning.Core.Configuration;
using MLearning.Core.Services;
using MLearning.Web.Singleton;
using MLearningDBResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MLearning.Web.Controllers
{
    public class LoginController : MLController
    {


        IMLearningService _mLearningService;

        public LoginController()            
        {

            _mLearningService = ServiceManager.GetService();
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void SignIn( bool isPersistent,string username,UserType type)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.NameIdentifier, username), new Claim(ClaimTypes.Role,type.ToString()), new Claim(ClaimTypes.Name,username)}, DefaultAuthenticationTypes.ApplicationCookie, ClaimTypes.Name, ClaimTypes.Role);
                
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent}, identity);
        
        }


        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        async public Task<ActionResult> Login(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                string username = collection.Get("username");

                string password = EncryptionService.encrypt(collection.Get("password"));

                User user = new User { username = username, password =password };
               

                LoginOperationResult<User> result = await _mLearningService.ValidateLogin<User>(user, u => u.password == user.password && u.username == user.username, u => u.id, u => u.type);
                // LoginOperationResult result = await _mLearningService.ValidateConsumerLogin(user.username,user.password);
                UserID = result.id;
                if (result.successful)
                {
                   
                   UserType userType = (UserType)result.userType;
                    //Session Code HERE
                    SignIn(false, username,userType);


                    switch (userType)
                    {
                        case UserType.SuperAdmin:

                            return RedirectToAction("Index","Admin");
                            
                        case UserType.Head:

                            return RedirectToAction("Index", "Head", new { id=result.id});
                       
                        case UserType.Publisher:

                            return RedirectToAction("Index","Publisher", new { id=result.id});
                            
                         default:
                            return RedirectToAction("Index");
                          
                    }

                }
                else
                {
                    return RedirectToAction("Index");

                }


               
            }
            catch
            {
                return View();
            }
        
        }


        [HttpPost]        
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index");
        }
      
    }
}
