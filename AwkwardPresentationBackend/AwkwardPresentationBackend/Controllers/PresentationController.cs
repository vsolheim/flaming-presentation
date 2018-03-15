using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using AwkwardPresentationBackend.Models;
using Newtonsoft.Json;

namespace AwkwardPresentationBackend.Controllers
{
    public class PresentationController : ApiController
    {
        [System.Web.Http.HttpGet]
        public int StartSession()
        {
            using (var db = new DatabaseContext())
            {
                var newPresentation = new PresentationModel();
                db.Presentations.Add(newPresentation);
                db.SaveChanges();

                var presentation = db.Presentations.Select(p => p).ToList().Last();

                return presentation.Id;
            }
        }
        
        /// <summary>
        /// Return the latest slide from the presentation with the ID <paramref name="id"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [System.Web.Http.HttpGet]
        public ActionResult GetSlideData(int id)
        {
            using (var db = new DatabaseContext())
            {
                var presentation = db.Presentations.Find(id);

                if (presentation == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return new JsonResult()
                {
                    ContentType = "application/json",
                    Data = presentation, 
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                };
            }
        }

        public void UploadSlideData(int id, string url, string text)
        {
            // Add this text to 
        }
    }
}
