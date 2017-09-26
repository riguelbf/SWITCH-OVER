using System;

namespace SWITCH_OVER.Shared.Transactions
{
	/// <summary>
	/// Class responsible for all transactions the database 
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		/// <summary>
		/// Persist all transactions into database
		/// </summary>
		void Commit();

		/// <summary>
		/// Cancel all transactions created
		/// </summary>
		void Rollback();
	}
}
