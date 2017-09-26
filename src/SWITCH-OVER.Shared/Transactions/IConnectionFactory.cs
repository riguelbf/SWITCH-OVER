namespace SWITCH_OVER.Shared.Transactions
{
    public interface IConnectionFactory<TTypeConnection>
    {

		/// <summary>
		/// Creates a unit to control the connection to database
		/// </summary>
		/// <returns></returns>
		IUnitOfWork Build();
    }
}
