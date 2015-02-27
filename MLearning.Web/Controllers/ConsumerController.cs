using Core.Repositories;
using Core.Security;
using MLearning.Core.Configuration;
using MLearning.Core.Services;
using MLearningDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MLearning.Web.Controllers
{
    public class ConsumerController : MLController
    {
        //
        IMLearningService ml;

        public ConsumerController():base()
        {
            IRepositoryService repo = new WAMSRepositoryService();
             ml = new MLearningAzureService(repo);
        }
        // GET: /Consumer/

        [Authorize(Roles = Constants.ConsumerRole)]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = Constants.ConsumerRole)]
        async public Task<ActionResult> Consumer()
        {
           
            List<user_by_circle> list   = await ml.GetUsersInCircle(1);

            return View(list);
        }

        [Authorize(Roles = Constants.ConsumerRole)]
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        async public Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                User user = new User();
                user.name = collection.Get("name");
                user.lastname = collection.Get("lastname");
                user.username = collection.Get("username");
                user.password = EncryptionService.encrypt(collection.Get("password"));
                user.email = collection.Get("email");
                // TODO: Add insert logic here
                await ml.CreateAccount<User>(user, u => u.id, UserType.Consumer);

                await ml.AddUserToCircle(user.id, Convert.ToInt32(collection.Get("Circle_id")));

                return RedirectToAction("Consumer");
            }
            catch
            {
                return View();
            }
        }

        [Authorize(Roles = Constants.ConsumerRole)]
       async  public Task<ActionResult> Edit(int id)
        {
            user_by_circle user = await ml.GetObjectWithId<user_by_circle>(id);
            return View(user);
        }

         // POST: /Customer/Edit/5

         [AcceptVerbs(HttpVerbs.Post)]
         public async Task<ActionResult> Edit(int id, FormCollection collection)
         {
             try
             {
                 User user = await ml.GetObjectWithId<User>(id);
                 user.name = collection.Get("name");
                 user.lastname = collection.Get("lastname");
                 user.username = collection.Get("username");
                 user.password = EncryptionService.encrypt(collection.Get("password"));
                 user.email = collection.Get("email");

                 await ml.UpdateObject<User>(user);
                 // TODO: Add update logic here

                 return RedirectToAction("Consumer");
             }
             catch
             {
                 return View();
             }
         }
	}
}