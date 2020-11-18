using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookShop
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
	{
		public ApplicationDbContext CreateDbContext( string[] args )
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
			.SetBasePath( Directory.GetCurrentDirectory() )
			.AddJsonFile( "appsettings.json" )
			.Build();
			var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
			optionsBuilder.UseNpgsql( configuration.GetConnectionString( "DefaultConnection" ) );

			return new ApplicationDbContext( optionsBuilder.Options );
		}
	}
}
