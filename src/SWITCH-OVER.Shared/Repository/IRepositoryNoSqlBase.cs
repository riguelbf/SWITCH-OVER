using SWITCH_OVER.Shared.Entities;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SWITCH_OVER.Shared.Repository
{
	public interface IRepositoryNoSqlBase<TDocument,TIdentity> where TDocument : Document<TIdentity>
	{
		Task<IEnumerable<TDocument>> FindAsync(Expression<Func<TDocument, bool>> predicate);

		Task Insert(TDocument document);

		Task<IEnumerable<TDocument>> InsertManyAsync(IEnumerable<TDocument> documents);

		Task UpdateAsync(TDocument document);

		Task RemoveAsync(TIdentity identity);
	}
}