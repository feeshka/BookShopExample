using BookShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Repositories
{
	public interface IRepository<TEntity> where TEntity : BaseEntity<long>
	{
		Task<long> InsertAndGetIdAsync( TEntity entity );
		Task<TEntity> UpdateAsync( TEntity entity );
		Task<int> DeleteAsync( long id );
		IQueryable<TEntity> GetAll();
		Task<TEntity> GetByIdAsync( long id );
	}
}
