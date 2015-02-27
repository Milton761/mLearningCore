using Core.Security;
using MLearning.Core.Configuration;
using MLearning.Core.Services;
using MLearning.Web.Models;
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
    public class HeadController : MLController
    {

                
         private IMLearningService _mLearningService;
		public HeadController() : base()
        {

           
            _mLearningService = ServiceManager.GetService();
        }


  



        //
        // GET: /Head/
         [Authorize(Roles=Constants.HeadRole)]
        async public Task<ActionResult> Index(int ?id)
        {


                if (id != null)
                {
                    int nonull_id = id ?? default(int);
                    UserID = nonull_id;

                }
                else
                {

                    if (UserID == default(int))
                    {
                        // NO user authenticated
                        return RedirectToAction("Index", "Home");
                    }

                }
            

                
                InstitutionID = await _mLearningService.GetHeadInstitutionID(UserID);

                var publisherList = await _mLearningService.GetPublishersByInstitution(InstitutionID);
                var consumersList = await _mLearningService.GetConsumersByInstitution(InstitutionID);


                return View("PublisherConsumerList", new AdminHeadViewModel { Publishers = publisherList, Consumers = consumersList });
          

            
        }

        //
        // GET: /Head/Details/5
         [Authorize(Roles = Constants.HeadRole)]
        public ActionResult DetailsPublisher(int id)
        {
            return View();
        }

        //
        // GET: /Head/CreatePublisher
         [Authorize(Roles = Constants.HeadRole)]
        public ActionResult CreatePublisher()
        {
            return View("PublisherCreate");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        async public Task<ActionResult> CreatePublisher(PublisherViewModel pubObj)
        {
            try
            {
                pubObj.User.password = EncryptionService.encrypt(pubObj.User.password);

                await _mLearningService.CreateAndRegisterPublisher(pubObj.User, pubObj.Publisher, InstitutionID);

                return RedirectToAction("Index", new { id = UserID });
            }
            catch
            {
                return RedirectToAction("Index", new {id = UserID });
            }
        }

         [Authorize(Roles = Constants.HeadRole)]
        async public Task<ActionResult> EditPublisher(int user_id, int publisher_id)
        {




            var user = await _mLearningService.GetObjectWithId<User>(user_id);
            var head = await _mLearningService.GetObjectWithId<Publisher>(publisher_id);
            



            return View("PublisherEdit", new PublisherViewModel { User = user, Publisher = head });


        }



        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> EditPublisher(int user_id, int publisher_id, PublisherViewModel pubObj)
        {
            try
            {

                var user = await _mLearningService.GetObjectWithId<User>(user_id);
                var head = await _mLearningService.GetObjectWithId<Publisher>(publisher_id);
                


                //Copy Ids
                pubObj.User.id = user_id;
                pubObj.Publisher.id = publisher_id;
                

                pubObj.User.password = EncryptionService.encrypt(pubObj.User.password);


                //Fields which doesn't update
                pubObj.User.email = user.email;
                pubObj.User.is_online = user.is_online;
                pubObj.User.social_id = user.social_id;
                pubObj.User.image_url = user.image_url;
                pubObj.User.updated_at = user.updated_at;
                pubObj.User.created_at = user.created_at;


                pubObj.Publisher.updated_at = head.updated_at;
                pubObj.Publisher.created_at = head.created_at;
                pubObj.Publisher.User_id = head.User_id;





                //Update DB
                _mLearningService.UpdateObject<User>(pubObj.User);


                _mLearningService.UpdateObject<Publisher>(pubObj.Publisher);




                return RedirectToAction("Index", new { id = UserID });

            }
            catch
            {
                return RedirectToAction("Index", new { id = UserID });
            }

        }

         [Authorize(Roles = Constants.HeadRole)]
        public async Task<ActionResult> DeletePublisher(int user_id, int publisher_id)
        {
            var user = await _mLearningService.GetObjectWithId<User>(user_id);
            var head = await _mLearningService.GetObjectWithId<Publisher>(publisher_id);



            return View("PublisherDelete", new PublisherViewModel { User = user, Publisher = head });
        }

        //
        // POST: /Default1/Delete/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeletePublisher(int user_id, int publisher_id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here


                _mLearningService.DeleteObject<Publisher>(new Publisher { id = publisher_id });
                _mLearningService.DeleteObject<User>(new User { id = user_id });


                return RedirectToAction("Index", new { id = UserID });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { id = UserID });
            }
        }





        //
        // GET: /Head/CreateConsumer
         [Authorize(Roles = Constants.HeadRole)]
        public ActionResult CreateConsumer()
        {
            return View("ConsumerCreate");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        async public Task<ActionResult> CreateConsumer(ConsumerViewModel consumerObj)
        {
            try
            {
                consumerObj.User.password = EncryptionService.encrypt(consumerObj.User.password);

                await _mLearningService.CreateAndRegisterConsumer(consumerObj.User,InstitutionID);

                return RedirectToAction("Index", new { id = UserID });
            }
            catch
            {
                return RedirectToAction("Index", new { id = UserID });
            }
        }


         [Authorize(Roles = Constants.HeadRole)]
        async public Task<ActionResult> EditConsumer(int user_id, int consumer_id)
        {




            var user = await _mLearningService.GetObjectWithId<User>(user_id);
            var consumer = await _mLearningService.GetObjectWithId<Consumer>(consumer_id);




            return View("ConsumerEdit", new ConsumerViewModel { User = user, Consumer = consumer });


        }



        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> EditConsumer(int user_id, int consumer_id, ConsumerViewModel consumerObj)
        {
            try
            {

                var user = await _mLearningService.GetObjectWithId<User>(user_id);
                var consumer = await _mLearningService.GetObjectWithId<Consumer>(consumer_id);



                //Copy Ids
                consumerObj.User.id = user_id;
                consumerObj.Consumer.id = consumer_id;


                consumerObj.User.password = EncryptionService.encrypt(consumerObj.User.password);


                //Fields which doesn't update
                consumerObj.User.is_online = user.is_online;
                consumerObj.User.social_id = user.social_id;                
                consumerObj.User.updated_at = user.updated_at;
                consumerObj.User.created_at = user.created_at;


                consumerObj.Consumer.updated_at = consumer.updated_at;
                consumerObj.Consumer.created_at = consumer.created_at;
                consumerObj.Consumer.User_id = consumer.User_id;





                //Update DB
                _mLearningService.UpdateObject<User>(consumerObj.User);


                _mLearningService.UpdateObject<Consumer>(consumerObj.Consumer);




                return RedirectToAction("Index", new { id = UserID });

            }
            catch
            {
                return RedirectToAction("Index", new { id = UserID });
            }

        }

         [Authorize(Roles = Constants.HeadRole)]
        public async Task<ActionResult> DeleteConsumer(int user_id, int consumer_id)
        {
            var user = await _mLearningService.GetObjectWithId<User>(user_id);
            var consumer = await _mLearningService.GetObjectWithId<Consumer>(consumer_id);



            return View("ConsumerDelete", new ConsumerViewModel { User = user, Consumer = consumer });
        }

        //
        // POST: /Default1/Delete/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteConsumer(int user_id, int consumer_id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here


                _mLearningService.DeleteObject<Consumer>(new Consumer { id = consumer_id });
                _mLearningService.DeleteObject<User>(new User { id = user_id });


                return RedirectToAction("Index", new { id = UserID });
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { id = UserID });
            }
        }

       
    }
}
