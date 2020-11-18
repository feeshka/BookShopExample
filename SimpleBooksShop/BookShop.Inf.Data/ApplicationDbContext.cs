using BookShop.Books;
using BookShop.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BookShop
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options)
			:base(options)
		{

		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderBook> OrderBooks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder )
		{

			base.OnModelCreating( modelBuilder );

			modelBuilder.Entity<OrderBook>( b =>
			 {
				 b.HasIndex( e => e.OrderId );
			 } );

			foreach ( var entityType in modelBuilder.Model.GetEntityTypes() )
			{
				var isDelete = entityType.FindProperty( "IsDeleted" );
				if ( isDelete != null && isDelete.ClrType == typeof( bool ) )
				{
					var parameter = Expression.Parameter( entityType.ClrType, "p" );
					var filter = Expression.Lambda( Expression.Equal( Expression.Property( parameter, "IsDeleted" ), Expression.Constant( false, typeof( bool ) ) ), parameter );
					entityType.SetQueryFilter( filter );// to ignore this rule use IgnoreQueryFilters
				}
			}

		}

		public override int SaveChanges()
		{
			UpdateSoftDeleteStatuses();
			return base.SaveChanges();
		}

		public override Task<int> SaveChangesAsync( CancellationToken cancellationToken = default( CancellationToken ) )
		{
			UpdateSoftDeleteStatuses();
			return base.SaveChangesAsync( cancellationToken );
		}

		protected void UpdateSoftDeleteStatuses()
		{
			foreach ( var entry in ChangeTracker.Entries() )
			{
				switch ( entry.State )
				{
					case EntityState.Deleted:
						entry.State = EntityState.Modified;
						entry.CurrentValues["IsDeleted"] = true;
					break;
					case EntityState.Added:
						entry.CurrentValues["IsDeleted"] = false;
					break;
					default:
					break;
				}
			}
		}
	}
}
