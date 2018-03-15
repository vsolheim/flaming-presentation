using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AwkwardPresentationBackend.Models
{
    public class PresentationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Name { get; set; }

        public IList<string> PresentationText { get; set; }
        public IList<string> Urls { get; set; }
    }

}