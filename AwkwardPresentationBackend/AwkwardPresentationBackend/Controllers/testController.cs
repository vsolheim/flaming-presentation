using AwkwardPresentationBackend.Models;
using AwkwardPresentationBackend.Services;
using Newtonsoft.Json;
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

            var a = "http://52.178.117.78/predict";
            var b = JsonConvert.SerializeObject(
                new { Message = "Test of concept with a few words" }
            );
            var data = await ImageProvider.RunAsync(b, a);
            return new JsonResult()
            {
                Data = new { Result = data},
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            }; 
        }

        public async Task<ActionResult> ClickerTest()
        {
            var dummy = new ClickerModel();
            dummy.Name = "test";
            dummy.Data = "DummyData" + new Random(10);
            dummy.Published_at = DateTime.Now;

            var result = await ImageProvider.RunAsync(dummy, "http://placeholder.no/api/clicker/inputdata");

            if (result != null && result is bool && (bool)result)
                return new JsonResult()
                {
                    Data = new { Result = "Success" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            else
                return new JsonResult()
                {
                    Data = new { Result = "Failure" },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
        }
    }
}