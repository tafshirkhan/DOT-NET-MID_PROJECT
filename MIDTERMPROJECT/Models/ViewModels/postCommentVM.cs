using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIDTERMPROJECT.Models.ViewModels
{
    public class postCommentVM
    {
        [Required]
        public string PostCommentBox { get; set; }
        [Required]
        public int PostId { get; set; }
    }
}