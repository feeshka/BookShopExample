using BookShop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Repositories
{
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity<long>
	{

		public Repository( ApplicationDbContext context )
		{
			_context = context;
		}

		protected readonly ApplicationDbContext _context;

		public async Task<long> InsertAndGetIdAsync( TEntity entity )
		{
			await _context.AddAsync( entity );
			await _context.SaveChangesAsync();
			return entity.Id;
		}

		public async Task<TEntity> UpdateAsync( TEntity entity )
		{
			_context.Entry( entity ).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<int> DeleteAsync( long id )
		{
			var entity = await _context.Set<TEntity>().FindAsync( id );
			_context.Set<TEntity>().Remove( entity );
			return await _context.SaveChangesAsync();
		}

		public async Task<TEntity> GetByIdAsync( long id )
		{
			return await _context.Set<TEntity>().FindAsync( id );
		}

		public IQueryable<TEntity> GetAll()
		{
			return _context.Set<TEntity>();
		}
	}
}
