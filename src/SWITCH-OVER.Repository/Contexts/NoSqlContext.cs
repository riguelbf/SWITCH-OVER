using SWITCH_OVER.Shared.Transactions;

namespace SWITCH_OVER.Repository.Contexts
{
	public class NoSqlContext : IUnitOfWork
	{
		public void Dispose()
		{
			throw new System.NotImplementedException();
		}

		public void Commit()
		{
			throw new System.NotImplementedException();
		}

		public void Rollback()
		{
			throw new System.NotImplementedException();
		}
	}
}