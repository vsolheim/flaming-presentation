using System.Linq;
using System.Web.Http;
using AwkwardPresentationBackend.Models;

namespace AwkwardPresentationBackend.Controllers
{
    public class PresentationController : ApiController
    {
        [HttpGet]
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
        

        public string GetSlideData(int id)
        {
            // return the latest slide
            return "text";
        }

        public void UploadSlideData(int id, string url, string text)
        {
            // Add this text to 
        }
    }
}
