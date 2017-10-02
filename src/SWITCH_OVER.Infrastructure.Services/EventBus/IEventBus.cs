using SWITCH_OVER.Shared.Events;

namespace SWITCH_OVER.Infrastructure.Services.EventBus
{
	public interface IEventBus
	{
		/// <summary>
		/// Publish a domain event for integration between other service
		/// </summary>
		/// <param name="event"></param>
		void Publish(Event @event);

		/// <summary>
		/// To enroll in the event queue to listen when it happens
		/// </summary>
		/// <typeparam name="TEvent">Event type</typeparam>
		/// <param name="handler">Handler of event type</param>
		void Subscribe<TEvent>(IEventHandler<TEvent> handler) where TEvent : Event;

		/// <summary>
		/// unsubscribe from the event queue
		/// </summary>
		/// <typeparam name="TEvent">Event type</typeparam>
		/// <param name="handler">Handler of event type</param>
		void Unsubscribe<TEvent>(IEventHandler<Event> handler) where TEvent : Event;
	}
}