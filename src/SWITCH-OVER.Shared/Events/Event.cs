using System;

namespace SWITCH_OVER.Shared.Events
{
	public abstract class Event : Message
	{

		protected Event() => Timestamp = DateTime.Now;

		/// <summary>
		/// DateTime when event happen
		/// </summary>
		public DateTime Timestamp { get; }
		
	}
}
