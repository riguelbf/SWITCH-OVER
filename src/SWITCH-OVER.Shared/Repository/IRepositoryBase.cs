using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SWITCH_OVER.Shared.Entities;

namespace SWITCH_OVER.Shared.Repository
{
	public interface IRepositoryBase<TEntity, in TIdentity> : IDisposable where TEntity : IAggregateRoot
	{
		/// <summary>
		/// Include registers into database
		/// </summary>
		/// <param name="entity">entity</param>
		void Add(TEntity entity);

		/// <summary>
		/// Find a record entity into database from primary key
		/// </summary>
		/// <param name="id">Primary key value</param>
		/// <returns></returns>
		TEntity GetById(TIdentity id);

		/// <summary>
		/// Obtains all entity records of database
		/// </summary>
		/// <returns></returns>
		IEnumerable<TEntity> GetAll();

		/// <summary>
		/// Update register of data base
		/// </summary>
		/// <param name="entity">entity</param>
		void Update(TEntity entity);

		/// <summary>
		/// Delete record into database from primary key
		/// </summary>
		/// <param name="id"></param>
		void Remove(TIdentity id);

		/// <summary>
		/// Generic method for find records into database
		/// </summary>
		/// <param name="predicate">Clause that contains conditions to filter query</param>
		/// <returns></returns>
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
	}
}
