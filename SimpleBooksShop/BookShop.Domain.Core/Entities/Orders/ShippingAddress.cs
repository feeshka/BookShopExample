using BookShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Orders
{
	[Table("AppShippingAdresses")]
	public class ShippingAddress: BaseEntity<long>
	{
		[Required]
		public string Country { get; set; }

		public string PostCode { get; set; }

		[Required]
		public string Region { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public string Street { get; set; }

		[Required]
		public string House { get; set; }

		public string Flat { get; set; }
	}
}
