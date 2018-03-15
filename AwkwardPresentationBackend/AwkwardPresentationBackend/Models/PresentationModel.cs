using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AwkwardPresentationBackend.Models
{
    public class PresentationModel
    {
        public int Id { get; set; }

        public IList<string> PresentationText { get; set; }
        public IList<string> Urls { get; set; }
    }

}