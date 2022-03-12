using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MIDTERMPROJECT.Models.ViewModels
{
    public class RegistrationVM
    {
        [Required, MinLength(5), Index(IsUnique = true)]
        public string Username { get; set; }
        [Required, MinLength(5), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Type { get; set; }
    }
}