using BookShop.Books;
using BookShop.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShop.Orders
{
	[Table("AppOrders")]
	public class Order: BaseEntity<long>
	{
		/// <summary>
		/// Адрес доставки
		/// </summary>
		public ShippingAddress ShippingAddress { get; set; }
		/// <summary>
		/// Статус заказа
		/// </summary>
		public OrderState OrderState { get; set; }
		/// <summary>
		/// Сумма заказа
		/// </summary>
		public double OrderSum { get; set; }
		public ICollection<OrderBook> OrderBooks { get; set; }
	}
}
