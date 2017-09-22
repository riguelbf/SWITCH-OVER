using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SWITCH_OVER.Shared.Entities;

namespace SWITCH_OVER.Shared.Repository
{
	public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
	{
		void Add(TEntity entity);
		TEntity GetById(Guid id);
		IEnumerable<TEntity> GetAll();
		void Update(TEntity entity);
		void Remove(Guid id);
		IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
	}
}
