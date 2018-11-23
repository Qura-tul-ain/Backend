using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace online.Models
{
	public class ProductViewModel
	{    

		[Required]
		[Display (Name = "Product Name")]
		public string Product_Name { get; set; }

		[Required]
		[Display(Name = "Product Description")]
		public string Product_Description { get; set; }

		[Required]
		[Display(Name = "Minimum Bid Amount")]
		public Double Minimum_Bid_Amount { get; set; }

		[Required]
		[Display(Name = "Auction Time")]
		public TimeSpan Auction_Time { get; set; }

		[Required]
		[Display(Name = "Select Category")]
		public string Select_Category { get; set; }

		
	}
}