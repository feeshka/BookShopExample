using AutoMapper;
using BookShop.Books.Dto;
using BookShop.Repositories;
using Linq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Books
{
	public class BookService : CRUDAppService<Book, BookDto, BookInListDto, GetBookInput>, IBookService
	{

		#region ctor

		public BookService( IRepository<Book> bookRepository, IMapper mapper )
			:base (bookRepository, mapper)
		{

		}

		#endregion

		#region IBookService

		public async Task<long> CreateAsync( BookDto entityDto )
		{
			return await CreateEntityAsync( entityDto );
		}

		public async Task DeleteAsync( BookDto entityDto )
		{
			await DeleteAsync( entityDto.Id );
		}

		public Task UpdateAsync( BookDto entityDto )
		{
			return UpdateEntityAsync( entityDto ); 
		}

		public async Task<IList<BookInListDto>> GetAsync( GetBookInput input )
		{
			return await GetEntitiesAsync( input );
		}

		public async Task<BookDto> GetByIdAsync( long id )
		{
			return await GetEntityByIdAsync( id );
		}

		protected override IQueryable<Book> Filter( IQueryable<Book> collection, GetBookInput query )
		{
			return collection
				.WhereIf( query.Author != null, b => b.Author.Contains( query.Author ) )
				.WhereIf( query.Title != null, b => b.Title.Contains( query.Title ) );
		}

		#endregion
	}
}
