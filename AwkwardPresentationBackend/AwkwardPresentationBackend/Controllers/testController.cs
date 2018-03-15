using AwkwardPresentationBackend.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AwkwardPresentationBackend.Controllers
{
    public class TestController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Test()
        {
            string a = "";
            using (var reader = new StreamReader(Request.InputStream))
                a = reader.ReadToEnd();
            if (a != null)
                return new JsonResult(){
                    Data = new { Result = "Yay!" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            else
                return new JsonResult()
                {
                    Data = new { Result = "Aaw!" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
        }

        public async Task<ActionResult> RunTest()
        {
            var data = await ImageProvider.RunAsync("");
            return new JsonResult()
            {
                Data = new { Result = data},
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            }; 
        }
    }
}