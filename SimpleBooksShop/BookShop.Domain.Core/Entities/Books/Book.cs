using BookShop.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShop.Books
{
	[Table("AppBooks")]
	public class Book : BaseEntity<long>
	{
		/// <summary>
		/// Автор
		/// </summary>
		public string Author { get; set; }
		/// <summary>
		/// Название книги
		/// </summary>
		public string Title { get; set; }
		/// <summary>
		/// Издательство
		/// </summary>
		public string PubHouse { get; set; }
		/// <summary>
		/// Год издания
		/// </summary>
		public string PubYear { get; set; }
		/// <summary>
		/// Скидка
		/// </summary>
		public double? Discount { get; set; }
		/// <summary>
		/// Дата окончания скидки
		/// </summary>
		public DateTime? DiscountEndDate { get; set; }
		/// <summary>
		/// Цена без скидок
		/// </summary>
		public double Price { get; set; }
		/// <summary>
		/// Количество
		/// </summary>
		public int Quantity { get; set; }
		/// <summary>
		/// Описание
		/// </summary>
		public string Description { get; set; }
	}
}
