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
    
    public partial class Feedbackss
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public int ID { get; set; }
        public string FK_ID { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
