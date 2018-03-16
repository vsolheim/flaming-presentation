using AwkwardPresentationBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AwkwardPresentationBackend.Controllers
{
    public class ClickerController : ApiController
    {
        [HttpPost]
        public bool InputData([FromBody]ClickerModel model)
        {
            if (model != null && model is ClickerModel)
            {
                using (var db = new DatabaseContext())
                {
                    db.ClickerData.Add(model);
                    try
                    {
                        db.SaveChanges();
                    }
                    catch(Exception e)
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}