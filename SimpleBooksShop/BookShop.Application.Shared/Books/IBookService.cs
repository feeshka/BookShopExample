using BookShop.Books.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Books
{
	public interface IBookService
	{
		Task<long> CreateAsync( BookDto entityDto );
		Task UpdateAsync( BookDto entityDto );
		Task DeleteAsync( BookDto entityDto );
		Task<IList<BookInListDto>> GetAsync( GetBookInput input );
		Task<BookDto> GetByIdAsync( long id );

	}
}
