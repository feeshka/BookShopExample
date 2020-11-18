using AutoMapper;
using BookShop.Dto;
using BookShop.Entities;
using BookShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop
{
	public abstract class CRUDAppService<TEntity, TEntityDto, TEntityInListDto, TQueryDto>
		where TEntity : BaseEntity<long>, new()
		where TEntityDto : EntityDto
	{
		#region ctor
		public CRUDAppService( IRepository<TEntity> repository, IMapper mapper )
		{
			_entityReository = repository;
			_mapper = mapper;
		}
		#endregion

		protected readonly IRepository<TEntity> _entityReository;
		protected readonly IMapper _mapper;

		protected async Task<long> CreateEntityAsync( TEntityDto dto )
		{
			TEntity entity = new TEntity();
			await MapFromDto( dto, entity );
			entity.CreationDateTime = DateTime.UtcNow;
			await ModifyNewEntity( entity );

			return await _entityReository.InsertAndGetIdAsync( entity );
		}

		protected async Task UpdateEntityAsync( TEntityDto dto )
		{
			var entity = await _entityReository.GetByIdAsync( dto.Id );
			if ( entity == null )
				throw new Exception( $"Entity {dto.Id} not found" );

			await MapFromDto( dto, entity );
			await _entityReository.UpdateAsync( entity );
		}

		protected async Task DeleteAsync( long id )
		{
			await _entityReository.DeleteAsync( id );
		}


		protected Task<List<TEntityInListDto>> GetEntitiesAsync( TQueryDto query )
		{
			return Task.Run( () =>
			{
				IQueryable<TEntity> entities = Filter( _entityReository.GetAll(), query );

				return entities.ToArray()
					.Select( e => MapToListDto( e ) )
					.ToList();
			} );
		}

		protected async Task<TEntityDto> GetEntityByIdAsync( long id )
		{
			var entity = await _entityReository.GetByIdAsync( id );
			if ( entity == null )
				throw new Exception( $"Entity {id} not found" );
			return await MapToDto( entity );
		}

		protected Task ModifyNewEntity( TEntity entity )
		{
			return Task.CompletedTask;
		}

		protected virtual Task MapFromDto( TEntityDto dto, TEntity entity )
		{
			return Task.Run(
				() => _mapper.Map( dto, entity ) );
		}

		protected virtual Task<TEntityDto> MapToDto( TEntity entity )
		{
			return Task.Run( () => _mapper.Map<TEntityDto>( entity ) );
		}

		protected virtual TEntityInListDto MapToListDto( TEntity entity )
		{
			return _mapper.Map<TEntityInListDto>( entity );
		}

		protected abstract IQueryable<TEntity> Filter( IQueryable<TEntity> collection, TQueryDto query );

	}
}
