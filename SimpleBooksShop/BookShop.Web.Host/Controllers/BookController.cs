using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.Books;
using BookShop.Books.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Host.Controllers
{
	[Route( "api/Book" )]
	[ApiController]
	public class BookController : Controller
	{
		public BookController( IBookService bookService )
		{
			_bookSevice = bookService;
		}

		IBookService _bookSevice;
		public IActionResult Index()
		{

			return View();
		}

		[HttpGet]
		public async Task<IList<BookInListDto>> GetBooks([FromBody]GetBookInput input)
		{
			var books = await _bookSevice.GetAsync( input );
			return books;
		}

		[HttpGet( "{id}" )]
		public async Task<BookDto> GetBook( long id )
		{
			var books = await _bookSevice.GetByIdAsync( id );
			return books;
		}

		[HttpPost]
		public async Task<long> CreateBook([FromBody]BookDto dto )
		{
			return await _bookSevice.CreateAsync( dto );
		}
	}
}
