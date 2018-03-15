using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AwkwardPresentationBackend.Controllers
{
    public class PresentationController : ApiController
    {
        public int StartSession()
        {
            // return a new session ID for a new presentation
            return 0;
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
