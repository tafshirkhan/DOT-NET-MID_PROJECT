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
    
    public partial class Follow
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public int Follows_id { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
