using MLearning.Core.Configuration;
using MLearning.Core.Services;
using MLearning.Web.Models;
using MLearning.Web.Singleton;
using MLearningDB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MLearning.Core.Entities;
using MLearning.Core.Entities.json;

namespace MLearning.Web.Controllers
{
    [Authorize]
    public class PublisherController : MLController
    {


        //
        // GET: /Publisher/
        [Authorize(Roles = Constants.PublisherRole)]
        async public Task<ActionResult> Index(int? id)
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


            InstitutionID = await _mLearningService.GetPublisherInstitutionID(UserID);

            var list = await _mLearningService.GetPublishersByInstitution(InstitutionID);

            PublisherID = list.Where(p => p.id == UserID).ToList().FirstOrDefault().publisher_id;

            //var circlesList = await _mLearningService.GetCirclesByOwner(UserID);

            var loList = await _mLearningService.GetLOByUserOwner(UserID);
            //viewData["totalCircles"] = 
            //return View("ConsumerLOList", new AdminPublisherViewModel { Circles=circlesList, LearningObjects =loList});
            return View("AssignedCircles");
        }

        public async Task<ActionResult> Circle_Read([DataSourceRequest] DataSourceRequest request)
        {
            var circlesList = await _mLearningService.GetCirclesByOwner(UserID);
            var data = circlesList.ToDataSourceResult(request);
            return Json(data);
        }

        public ActionResult CircleConsumers(int id)
        {
            CircleID = id;
            return View();
        }

        public ActionResult LearningObjects(int id)
        {
            CircleID = ViewBag.CircleID = id;
            return View();
        }

        public async Task<ActionResult> LO(int? id, int? circleId)
        {
            if (id != null)
            {
                LOID = ViewBag.LOID = id ?? default(int);
                LearningObject model = await _mLearningService.GetObjectWithId<LearningObject>(LOID);
                ViewBag.CircleID = CircleID;
                //ViewBag.tagList = await _mLearningService.GetTagsByLO(LOID);
                ViewBag.tagList = await _mLearningService.GetLOTags(LOID);
                //ViewBag.tagList = tagList.Select(t => t.tag_id);
                return View(model);
            }
            if (circleId != null)
                CircleID = ViewBag.CircleID = circleId ?? default(int);



            return View();
        }

        public async Task<ActionResult> LOs_read([DataSourceRequest] DataSourceRequest request)
        {
            var los = await _mLearningService.GetLOByCircle(CircleID);
            return Json(los.ToDataSourceResult(request));
        }

        public async Task<ActionResult> LODetail(int id)
        {
            LOID = ViewBag.LOID = id;
            LearningObject model = await _mLearningService.GetObjectWithId<LearningObject>(LOID);

            ViewBag.LOsections = await _mLearningService.GetSectionsByLO(LOID);

            return View(model);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        async public Task<ActionResult> Read_SectionPages(int id)
        {
            var pages = await _mLearningService.GetPagesByLOSection(id);
            return Json(pages);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        async public Task<ActionResult> Read_LOPages(int id)
        {
            var pages = await _mLearningService.GetPagesByLO(id);
            return Json(pages);
        }

        //Not used
        //Upload controller used instead
        [AcceptVerbs(HttpVerbs.Post)]
        async public Task<ActionResult> CreateLO(LearningObject obj, List<Tag> tags)
        {

            if (PublisherID == default(int))
                return Json(new JsonActionResult { errors = new String[] { "No publisher defined" } });
            try
            {
                //Create LO

                obj.created_at = DateTime.UtcNow;
                obj.updated_at = DateTime.UtcNow;

                obj.Publisher_id = PublisherID;

                int LO_id = await _mLearningService.CreateObject<LearningObject>(obj, lo => lo.id);

                await _mLearningService.PublishLearningObjectToCircle(CircleID, LO_id);

                foreach (Tag t in tags)
                {
                    await _mLearningService.AddTagToLO(t.id, LO_id);
                }

                return Json(new JsonActionResult { url = Url.Action("LODetail", new { id = LO_id }) });
            }
            catch (Exception e)
            {
                return Json(new { errors = new Object[] { e } });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        async public Task<ActionResult> UpdateLO(LearningObject obj, List<Tag> tags)
        {
            try
            {
                obj.updated_at = DateTime.UtcNow;
                await _mLearningService.UpdateObject<LearningObject>(obj);

                ///Update tag list
                if (tags != null)
                {
                    var curtags = await _mLearningService.GetLOTags(obj.id);
                    var curtagsids = curtags.Select(t => t.id);
                    var tagids = tags.Select(t => t.id);

                    var toDelete = curtagsids.Except(tagids).ToList();
                    var toAdd = tagids.Except(curtagsids).ToList();

                    foreach (int id in toDelete)
                    {
                        await _mLearningService.DeleteTagFromLO(id, obj.id);
                    }

                    foreach (int id in toAdd)
                    {
                        await _mLearningService.AddTagToLO(id, obj.id);
                    }
                }
                return Json(new JsonActionResult());
            }
            catch (Exception e)
            {
                return Json(new { errors = new String[] { e.Message } });
            }
        }

        async public Task<ActionResult> createLOSection(LOsection data)
        {
            String[] _errors;
            int id = default(int);
            try
            {
                id = await _mLearningService.CreateObject<LOsection>(data, o => o.id);
                _errors = new String[] { };
            }
            catch (Exception e)
            {
                _errors = new String[] { e.Message };
            }

            return Json(new { errors = _errors, result_id = id, url = Url.Action("", "Page", new { sectionId = id }) });
        }

        [HttpPost]
        async public Task<ActionResult> Upload(HttpPostedFileBase file, HttpPostedFileBase bg_file, LearningObject obj)
        {

            string cover_url = null;
            string bg_url = null;
            if (file != null && file.ContentLength > 0)
            {


                using (MemoryStream target = new MemoryStream())
                {

                    file.InputStream.CopyTo(target);

                    cover_url = await _mLearningService.UploadResource(target, null);
                }


            }

            if (bg_file != null && bg_file.ContentLength > 0)
            {


                using (MemoryStream target = new MemoryStream())
                {
                    bg_file.InputStream.CopyTo(target);

                    bg_url = await _mLearningService.UploadResource(target, null);
                }


            }


            obj.created_at = DateTime.UtcNow;
            obj.updated_at = DateTime.UtcNow;
            //obj.url_cover = cover_url;
            //obj.url_background = bg_url;

            obj.Publisher_id = PublisherID;


            int LO_id = await _mLearningService.CreateObject<LearningObject>(obj, lo => lo.id);

            return RedirectToAction("Index", new { id = UserID });
        }


        [Authorize(Roles = Constants.PublisherRole)]
        async public Task<ActionResult> EditLO(int? lo_id)
        {

            if (lo_id != null)
            {
                int nonull = lo_id ?? default(int);

                LOID = nonull;
            }
            else
            {
                if (LOID == default(int))
                {
                    return RedirectToAction("Index", "Home");
                }
            }


            var lo = await _mLearningService.GetObjectWithId<LearningObject>(LOID);

            var pages = await _mLearningService.GetPagesByLO(LOID);

            List<Quiz> quizzes = await _mLearningService.GetQuizzesByLO(LOID);


            return View("LOEdit", new LearningObjectPageViewModel { LO = lo, Pages = pages, Quizzes = quizzes });


        }

        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> EditLO(int lo_id, LearningObjectPageViewModel vm)
        {
            try
            {
                LearningObject obj = vm.LO;


                //Update DB
                await _mLearningService.UpdateObject<LearningObject>(obj);


                return RedirectToAction("Index", new { id = UserID });

            }
            catch
            {
                return RedirectToAction("Index", new { id = UserID });
            }

        }

        [Authorize(Roles = Constants.PublisherRole)]
        public async Task<ActionResult> DeleteLO(int lo_id)
        {
            var circle = await _mLearningService.GetObjectWithId<LearningObject>(lo_id);



            return View("LODelete", circle);
        }

        //
        // POST: /Default1/Delete/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteLO(int lo_id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here


                _mLearningService.DeleteObject<LearningObject>(new LearningObject { id = lo_id });



                return RedirectToAction("Index", new { id = UserID });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { id = UserID });
            }
        }

        /*********************************************************************************************************/
        #region OLD cruds
        // GET: /Publisher/CreateCircle
        [Authorize(Roles = Constants.PublisherRole)]
        public ActionResult CreateCircle()
        {
            return View("CircleCreate");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        async public Task<ActionResult> CreateCircle(Circle circleObj)
        {
            try
            {
                int circle_id = await _mLearningService.CreateCircle(UserID, circleObj.name, circleObj.type);

                //Register the Publisher as a user in a Circle
                await _mLearningService.CreateObject<CircleUser>(new CircleUser { Circle_id = circle_id, User_id = UserID, created_at = DateTime.UtcNow, updated_at = DateTime.UtcNow }, c => c.id);

                return RedirectToAction("Index", new { id = UserID });
            }
            catch
            {
                return RedirectToAction("Index", new { id = UserID });
            }
        }

        [Authorize(Roles = Constants.PublisherRole)]
        async public Task<ActionResult> ManageCircle(int circle_id)
        {


            CircleID = circle_id;

            var losInCircle = await _mLearningService.GetLOByCircle(circle_id);

            var consumersInCircle = await _mLearningService.GetConsumersByCircle(circle_id);

            var consumersInInst = await _mLearningService.GetConsumersByInstitution(InstitutionID);

            var lospublic = await _mLearningService.GetPublicLOs();

            return View("CircleManage", new ManageCircleViewModel { LOInCircle = losInCircle, LOPublic = lospublic, ConsumerInCircle = consumersInCircle, ConsumerInInst = consumersInInst });


        }



        [Authorize(Roles = Constants.PublisherRole)]
        async public Task<ActionResult> EditCircle(int circle_id)
        {

            var circle = await _mLearningService.GetObjectWithId<Circle>(circle_id);



            return View("CircleEdit", circle);


        }



        [AcceptVerbs(HttpVerbs.Post)]
        public async Task<ActionResult> EditCircle(int circle_id, Circle circleObj)
        {
            try
            {



                //Update DB
                await _mLearningService.UpdateObject<Circle>(circleObj);


                return RedirectToAction("Index", new { id = UserID });

            }
            catch
            {
                return RedirectToAction("Index", new { id = UserID });
            }

        }

        [Authorize(Roles = Constants.PublisherRole)]
        public async Task<ActionResult> DeleteCircle(int circle_id)
        {
            var circle = await _mLearningService.GetObjectWithId<Circle>(circle_id);



            return View("CircleDelete", circle);
        }

        //
        // POST: /Default1/Delete/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteCircle(int circle_id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here


                _mLearningService.DeleteObject<Circle>(new Circle { id = circle_id });



                return RedirectToAction("Index", new { id = UserID });
            }
            catch (Exception)
            {
                return RedirectToAction("Index", new { id = UserID });
            }
        }



        // GET: /Publisher/CreateLO
        [Authorize(Roles = Constants.PublisherRole)]
        public ActionResult CreateLO()
        {


            return View("LOCreate");
        }

        [Authorize(Roles = Constants.PublisherRole)]
        public async Task<ActionResult> Remove(int user_id)
        {


            if (CircleID != null)
            {
                await _mLearningService.UnSubscribeConsumerFromCircle(user_id, CircleID);
            }


            return RedirectToAction("ManageCircle", new { circle_id = CircleID });
        }

        [Authorize(Roles = Constants.PublisherRole)]
        public async Task<ActionResult> Add(int user_id)
        {


            if (CircleID != null)
            {
                await _mLearningService.AddUserToCircle(user_id, CircleID);
            }


            return RedirectToAction("ManageCircle", new { circle_id = CircleID });
        }



        [Authorize(Roles = Constants.PublisherRole)]
        public async Task<ActionResult> AddLOToCircle(int lo_id)
        {


            if (CircleID != null)
            {
                await _mLearningService.PublishLearningObjectToCircle(CircleID, lo_id);
            }


            return RedirectToAction("ManageCircle", new { circle_id = CircleID });
        }



    }
        #endregion
}