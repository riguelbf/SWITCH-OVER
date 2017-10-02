using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;
using SWITCH_OVER.Shared.Events;
using Newtonsoft.Json;

namespace SWITCH_OVER.Infrastructure.Services.EventBus
{
	public class EventBusMQ : IEventBus, IDisposable
	{
		private string _connectionString;
		private string _brokerName;
		private object _handlers;

		public EventBusMQ()
		{
			ConfigureConnection();
		}

		private void ConfigureConnection()
		{

		}

		public void Publish(Event @event)
		{
			var eventName = @event.GetType().Name;
			var factory = new ConnectionFactory() { HostName = _connectionString };
			
			using (var connection = factory.CreateConnection())
			using (var channel = connection.CreateModel())
			{
				channel.ExchangeDeclare(exchange: _brokerName, type: "direct");

				var message = JsonConvert.SerializeObject(@event);

				var body = Encoding.UTF8.GetBytes(message);

				channel.BasicPublish(exchange: _brokerName, routingKey: eventName, basicProperties: null, body: body);
			}
		}

		public void Subscribe<TEvent>(IEventHandler<TEvent> handler, string queueName) where TEvent : Event
		{
			var eventName = typeof(TEvent).Name;

			if (_handlers.ContainsKey(eventName))
			{
				_handlers[eventName].Add(handler);
			}
			else
			{
				var channel = GetChannel();
				channel.QueueBind(queue: _queueName,
					exchange: _brokerName,
					routingKey: eventName);

				handlers.Add(eventName, new List<IEventHandler<TEvent>>());
				handlers[eventName].Add(handler);
				eventTypes.Add(typeof(T));
			}
		}

		public void Unsubscribe<TEvent>(IEventHandler<Event> handler) where TEvent : Event
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
