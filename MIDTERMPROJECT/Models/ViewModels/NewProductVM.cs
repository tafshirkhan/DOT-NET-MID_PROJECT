using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MIDTERMPROJECT.Models.ViewModels
{
    public class NewProductVM
    {
        [Required]
        public string productName { get; set; }
        public string productPrice { get; set; }
        public string productImage { get; set; }
        public string productDescription { get; set; }
        public string productQuantity { get; set; }
        public int categoryId { get; set; }

        public HttpPostedFileBase ImageFiles { get; set; }
    }
}