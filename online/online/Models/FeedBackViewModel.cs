using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace online.Models
{
	public class FeedBackViewModel
	{
		[Required]
		[Display(Name = "Subject")]
		public string Subject { get; set; }

		[Required]
		[Display(Name = "Description")]
		public string Description { get; set; }
	}
}