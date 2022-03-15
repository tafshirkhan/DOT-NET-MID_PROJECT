using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIDTERMPROJECT.Models.ViewModels
{
    public class ReplyVM
    {
        [Required]
        public string ReplyComment { get; set; }
        public int CommentId { get; set; }
    }
}