using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Entities
{
	public class BaseEntity<TPrimaryKey>
	{
		public TPrimaryKey Id { get; set; }

		public bool IsDeleted { get; set; }

		public DateTime CreationDateTime { get; set; }
	}
}
