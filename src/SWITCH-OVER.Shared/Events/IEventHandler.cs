namespace SWITCH_OVER.Shared.Events
{
	/// <summary>
	/// EventHandler is responsible to publish a change effect in domain
	/// </summary>
	/// <typeparam name="T">Event class object</typeparam>
	public interface IEventHandler<in T> : IHandler<T> where T : Event
	{
	}
}
