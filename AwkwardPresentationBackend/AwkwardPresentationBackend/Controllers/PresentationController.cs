using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;
using AwkwardPresentationBackend.Models;

namespace AwkwardPresentationBackend.Controllers
{
    public class PresentationController : ApiController
    {
        /// <summary>
        /// Start a new presentation and get the ID of it.
        /// </summary>
        /// <returns></returns>
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
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }

        [System.Web.Http.HttpPost]
        public void UploadSlideData([FromBody] TodoItem item)
        {
            //using (var db = new DatabaseContext())
            //{
            //    // Add this text to 
            //}

            //return GetSlideData(id);
        }
    }

    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
