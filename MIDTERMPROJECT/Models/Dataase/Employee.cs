//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MIDTERMPROJECT.Models.Dataase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public System.DateTime JoiningDate { get; set; }
        public string Status { get; set; }
        public int User_id { get; set; }
    
        public virtual User User { get; set; }
    }
}
