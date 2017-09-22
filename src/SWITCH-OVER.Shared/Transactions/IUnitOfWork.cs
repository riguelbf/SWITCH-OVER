using System;

namespace SWITCH_OVER.Shared.Transactions
{
    public interface IUnitOfWork : IDisposable
    {
	    void Commit();
	    void Rollback();
    }
}
