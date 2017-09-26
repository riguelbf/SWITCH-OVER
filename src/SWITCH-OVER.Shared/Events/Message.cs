using System;

namespace SWITCH_OVER.Shared.Events
{
	public abstract class Message //: INotification
	{
		/// <summary>
		/// Type message for publish/subscribe
		/// </summary>
		public string MessageType { get; protected set; }

		/// <summary>
		/// Code for identify event in logger 
		/// </summary>
		public Guid AggregateId { get; protected set; }

		protected Message()
		{
			MessageType = GetType().Name;
		}
	}
}
