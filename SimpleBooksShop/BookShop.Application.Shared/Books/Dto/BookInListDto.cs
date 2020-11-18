using BookShop.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Books.Dto
{
	public class BookInListDto: EntityDto
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
		public double Discount { get; set; }
		/// <summary>
		/// Дата окончания скидки
		/// </summary>
		public DateTime DiscountEndDate { get; set; }
		/// <summary>
		/// Цена без скидок
		/// </summary>
		public double Price { get; set; }
		/// <summary>
		/// Доступность на складе
		/// </summary>
		public bool IsAvailable { get; set; }
	}
}
