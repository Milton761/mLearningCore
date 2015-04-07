using Core.Security;
using MLearning.Core.Configuration;
using MLearning.Core.Entities;
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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Diagnostics;

namespace MLearning.Web.Controllers
{
    public class AdminController : MLController
    {
        //
        // GET: /Admin/

        
        IMLearningService _mLearningService;

        public AdminController() : base()
        {
            _mLearningService = ServiceManager.GetService();
        }

        [Authorize(Roles = Constants.SuperAdminRole)]
        public ActionResult Index()
        {
            //var list = await _mLearningService.GetHeads();
            //return View("HeadList",list);
            return View();
        }

        public ActionResult Institutions()
        {
            return View("Institutions");
        }

       
        public async Task<ActionResult> Institution_create([DataSourceRequest] DataSourceRequest request,head_by_institution inst)
        {
            if (inst != null && ModelState.IsValid)
            {
                Institution i = new Institution
                {
                    id = 0,
                    name = inst.institution_name,
                    country = inst.country,
                    region = inst.region,
                    city = inst.city,
                    postal_code = inst.postal_code,
                    telephone = inst.telephone,
                    email = inst.email,
                    website_address = inst.website_address,
                    notes = inst.notes
                };

                User u = new User
                {
                    id = 0,
                    name = inst.name,
                    lastname = inst.lastname,
                    username = inst.username,
                    password = EncryptionService.encrypt(inst.password)
                };


                int instId = await _mLearningService.CreateInstitution(i, new Head() {id = 0}, u);
                //inst = await _mLearningService.GetObjectWithId<head_by_institution>(instId);
                inst.id = instId;
                inst.fullname = inst.lastname+", "+inst.name;
            }
            return Json(new[] { inst }.ToDataSourceResult(request, ModelState));
        }

        public async Task<ActionResult> Institution_read([DataSourceRequest] DataSourceRequest request)
        {
            //IQueryable q = _mLearningService.repositoryService().GetAllQuery<Institution>()
            //var i = q.Count();
            //var data = q.ToDataSourceResult(request);
            var data = (await _mLearningService.GetHeads()).ToDataSourceResult(request);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> Institution_update([DataSourceRequest] DataSourceRequest request, head_by_institution inst)
        {
            if (inst != null && ModelState.IsValid)
            {
                User user = await _mLearningService.GetObjectWithId<User>(inst.id);
                //Head head = await _mLearningService.GetObjectWithId<Head>(head_id);
                Institution institution = await _mLearningService.GetObjectWithId<Institution>(inst.institution_id);

                user.name = inst.name;
                user.lastname = inst.lastname;
                user.username = inst.username;
                if(inst.password!=null)
                    user.password = EncryptionService.encrypt(inst.password);
               
                institution.name = inst.institution_name;
                institution.country = inst.country;
                institution.region = inst.region;
                institution.city = inst.city;
                institution.postal_code = inst.postal_code;
                institution.telephone = inst.telephone;
                institution.email = inst.email;
                institution.website_address = inst.website_address;
                institution.notes = inst.notes;

                //Update DB
                await _mLearningService.UpdateObject<User>(user);


                //_mLearningService.UpdateObject<Head>(adminObj.Head);


                await _mLearningService.UpdateObject<Institution>(institution);
            }
            return Json(new[] { inst }.ToDataSourceResult(request, ModelState));
        }

        public async Task<ActionResult> Institution_destroy([DataSourceRequest] DataSourceRequest request, head_by_institution inst)
        {
            if (inst != null)
            {
                await _mLearningService.DeleteObject<User>(new User { id = inst.id });
                await _mLearningService.DeleteObject<Head>(new Head { id = inst.head_id });
                await _mLearningService.DeleteObject<Institution>(new Institution { id = inst.institution_id });
            }
            return Json(new[] { inst }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult LearningObjects()
        {
            //ViewBag.circleId = testCircleId;
            return View();
        }

        public async Task<ActionResult> Units_read([DataSourceRequest] DataSourceRequest request)
        {
            //request.Filters
            var data = (await _mLearningService.GetLOsbyOwner()).ToDataSourceResult(request);
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Create()
        {
            return View("HeadCreate");
        }


        [AcceptVerbs(HttpVerbs.Post)]
        async public Task<ActionResult> Create(AdminViewModel adminObj)
        {
            try
            {
                adminObj.User.password = EncryptionService.encrypt(adminObj.User.password);

                await _mLearningService.CreateInstitution(adminObj.Inst, adminObj.Head, adminObj.User);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [Authorize(Roles = Constants.SuperAdminRole)]
        async public Task<ActionResult> Edit(int user_id,int head_id,int inst_id)
        {


          

            var user = await _mLearningService.GetObjectWithId<User>(user_id);
             var head = await _mLearningService.GetObjectWithId<Head>(head_id);
             var institution = await _mLearningService.GetObjectWithId<Institution>(inst_id);



            return View("HeadEdit", new AdminViewModel { User = user, Head = head, Inst = institution });


        }

        

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> Edit(int user_id,int head_id,int inst_id, AdminViewModel adminObj)
        {
            try
            {

                var user = await _mLearningService.GetObjectWithId<User>(user_id);
                var head = await _mLearningService.GetObjectWithId<Head>(head_id);
                var institution = await _mLearningService.GetObjectWithId<Institution>(inst_id);


                //Copy Ids
                adminObj.User.id = user_id;
                adminObj.Head.id = head_id;
                adminObj.Inst.id = inst_id;

                adminObj.User.password = EncryptionService.encrypt(adminObj.User.password);


                //Fields which doesn't update
                adminObj.User.email = user.email;
                adminObj.User.is_online = user.is_online;
                adminObj.User.social_id = user.social_id;
                adminObj.User.image_url = user.image_url;
                adminObj.User.updated_at = user.updated_at;
                adminObj.User.created_at = user.created_at;


                adminObj.Head.updated_at = head.updated_at;
                adminObj.Head.created_at = head.created_at;
                adminObj.Head.User_id = head.User_id;

                adminObj.Inst.created_at = institution.created_at;
                adminObj.Inst.updated_at = institution.updated_at;



              
                //Update DB
                _mLearningService.UpdateObject<User>(adminObj.User);
          

                _mLearningService.UpdateObject<Head>(adminObj.Head);
              

                _mLearningService.UpdateObject<Institution>(adminObj.Inst);


               return  RedirectToAction("Index");
            
            }
            catch
            {
                return View("Index");
            }
            
        }

        [Authorize(Roles = Constants.SuperAdminRole)]
        public async Task<ActionResult> Delete(int user_id, int head_id, int inst_id)
        {
            var user = await _mLearningService.GetObjectWithId<User>(user_id);
            var head = await _mLearningService.GetObjectWithId<Head>(head_id);
            var institution = await _mLearningService.GetObjectWithId<Institution>(inst_id);


            return View("HeadDelete", new AdminViewModel { User = user, Head = head, Inst = institution });
        }

        //
        // POST: /Default1/Delete/5
       [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete(int user_id, int head_id, int inst_id,FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                _mLearningService.DeleteObject<User>(new User { id = user_id });
                _mLearningService.DeleteObject<Head>(new Head { id = head_id });
                _mLearningService.DeleteObject<Institution>(new Institution { id = inst_id });

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View("HeadDelete");
            }
        }



	}
}