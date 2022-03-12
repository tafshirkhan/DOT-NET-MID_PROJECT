using MIDTERMPROJECT.Models.Dataase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIDTERMPROJECT.Models.ViewModels
{
    public class postVM
    {
        //public List<Post> post = new List<Post>();
        
        [Required, MinLength(5)]
        public string User_Post { get; set; }
        [DisplayName("Upload File")]
        public string Image { get; set; }
        public DateTime? CreatedOn { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}