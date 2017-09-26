namespace SWITCH_OVER.Shared.Events
{
	/// <summary>
	/// Generic interface for aggregated and specification handler class 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IHandler<in T> where T : class
	{
		/// <summary>
		/// Event method after changes in application
		/// </summary>
		/// <param name="message"></param>
		void Handle(T message);
	}
}
