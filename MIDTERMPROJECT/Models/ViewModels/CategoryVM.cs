using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIDTERMPROJECT.Models.ViewModels
{
    public class CategoryVM
    {
        [Required, MinLength(4)]
        public string categoryName { get; set; }
    }
}