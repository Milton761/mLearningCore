using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MLearning.Core.Entities.json;

namespace MLearning.Web.Controllers
{
    public class ResourcesController : MLController
    {

        // GET: Resources
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> UploadImage(IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                string result_url = null;
                if(files!=null && files.Count() > 0)
                {
                    var file = files.ElementAt(0);
                    if (file != null && file.ContentLength > 0)
                    {
                        using (MemoryStream target = new MemoryStream())
                        {
                            file.InputStream.CopyTo(target);
                            result_url = await _mLearningService.UploadResource(target, null);
                        }
                    }
                }
                return Json(new JsonActionResult() { errors = null, url = result_url });
            }
            catch(Exception e){
                return Json(new JsonActionResult() { errors = new String[]{e.Message}});
            }
        }

    }
}