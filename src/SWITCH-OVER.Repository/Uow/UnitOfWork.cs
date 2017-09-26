using System;
using Microsoft.EntityFrameworkCore;
using SWITCH_OVER.Shared.Transactions;

namespace SWITCH_OVER.Repository.Uow
{
	public class UnitOfWork : IUnitOfWork
    {
	    private readonly DbContext _context;


	    public UnitOfWork(DbContext context)
	    {
		    _context = context;
	    }

		public void Dispose()
	    {
			_context.Dispose();
		}

	    public void Commit()
	    {
		    _context.SaveChanges();
	    }

	    public void Rollback()
	    {
		    throw new NotImplementedException();
	    }
    }
}
