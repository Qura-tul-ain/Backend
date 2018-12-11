using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace online.Models
{
    public class BidingDetails
    {
        public IEnumerable<RegisteredUser> user { get; set; }
        public IEnumerable<Product> pro { get; set; }
        public IEnumerable<YourAmount> bid { get; set; }

    }
}