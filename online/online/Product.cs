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
    
    public partial class Product
    {
        public int ImageId { get; set; }
        public string Images { get; set; }
        public string ProductName { get; set; }
        public string ProductDescp { get; set; }
        public double BidAmount { get; set; }
        public System.DateTime AuctionDate { get; set; }
        public string Category { get; set; }
        public string FK_ID { get; set; }
    
        public virtual AspNetUser AspNetUser { get; set; }
    }
}
