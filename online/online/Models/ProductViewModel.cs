using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace online.Models
{
	public class ProductViewModel
	{

        
        public int ImageId { get; set; }

        public string Images { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Product Description")]
        public string ProductDescp { get; set; }

        [Required]
        [Display(Name = "Bid Amount")]
        public double BidAmount { get; set; }

        [Required(ErrorMessage ="This Field Is Required")]
        [Display(Name = "Auction Date")]
        [DataType(DataType.Date)]
        public System.DateTime AuctionDate { get; set; }

        [Required]
        public string Category { get; set; }
        public string YourAmount { get; set; }
    }
}