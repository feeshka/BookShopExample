using BookShop.Books;
using BookShop.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookShop.Infrastructure.IoC
{
	public class DependencyContainer
	{
		public static void RegisterServices( IServiceCollection services )
		{
			services.AddScoped<IBookService, BookService>();

			services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
		}
	}
}
