//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace online
{
    using System;
    using System.Collections.Generic;
    
    public partial class AspNetUserRole
    {
        public int UserId { get; set; }
        public string RoleId { get; set; }
    
        public virtual AspNetUserRole AspNetUserRoles1 { get; set; }
        public virtual AspNetUserRole AspNetUserRole1 { get; set; }
        public virtual RegisteredUser RegisteredUser { get; set; }
    }
}
