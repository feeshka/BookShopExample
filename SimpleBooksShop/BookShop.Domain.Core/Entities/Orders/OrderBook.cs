using BookShop.Books;
using BookShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Orders
{
	[Table("AppOrderBook")]
	public class OrderBook: BaseEntity<long>
	{
		public long OrderId { get; set; }
		public Book Book { get; set; }
		public long BookId { get; set; }
	}
}
