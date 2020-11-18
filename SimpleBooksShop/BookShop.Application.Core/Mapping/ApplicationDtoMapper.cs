using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookShop.Books;
using BookShop.Books.Dto;

namespace BookShop.Mapping
{
	public class ApplicationDtoMapper: Profile
	{
		public ApplicationDtoMapper()
		{
			ConfigureBooksMapping();
		}

		private void ConfigureBooksMapping()
		{
			CreateMap<Book, BookDto>()
				.ForMember( e => e.IsAvailable, options => options.MapFrom( e => e.Quantity > 0 ? true : false ) );

			CreateMap<BookDto, Book>()
				.ForMember( e => e.Id, options => options.Ignore() );

			CreateMap<Book, BookInListDto>()
				.ForMember( e => e.IsAvailable, options => options.MapFrom( e => e.Quantity > 0 ? true : false ) );
		}
	}
}
