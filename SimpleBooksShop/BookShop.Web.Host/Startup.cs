using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BookShop.Infrastructure.IoC;
using BookShop.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookShop.Web.Host
{
	public class Startup
	{
		public Startup( IConfiguration configuration )
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices( IServiceCollection services )
		{
			RegisterServices( services );

			#region Mapper

			var mapperConfig = new MapperConfiguration( mc =>
			 {
				 mc.AddProfile( new ApplicationDtoMapper() );
			 } );

			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton( mapper );

			#endregion

			services.AddControllersWithViews();
			services.AddDbContext<ApplicationDbContext>( options =>
				 options.UseNpgsql( Configuration.GetConnectionString( "DefaultConnection" ) )
			);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
		{
			if ( env.IsDevelopment() )
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler( "/Home/Error" );
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints( endpoints =>
			 {
				 endpoints.MapControllerRoute(
					 name: "default",
					 pattern: "{controller=Home}/{action=Index}/{id?}" );
			 } );
		}

		private static void RegisterServices( IServiceCollection services )
		{
			DependencyContainer.RegisterServices( services );
		}
	}
}
