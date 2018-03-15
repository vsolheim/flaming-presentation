using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AwkwardPresentationBackend.Models;

namespace AwkwardPresentationBackend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string test2 = "";

            using (var db = new DatabaseContext())
            {
                var presentation = new PresentationModel();

                db.Presentations.Add(presentation);
                db.SaveChanges();

                var test = db.Presentations.Select(p => p);

                foreach (var testItem in test)
                {

                    if (testItem != null && testItem.PresentationText != null)
                    {
                        foreach (var str in testItem.PresentationText)
                        {

                            test2 = test2 + str;
                        } 
                    }
                }
            }


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}