using System;

namespace SWITCH_OVER.Shared.Events
{
    public abstract class Event
    {
	    public DateTime Timestamp { get; private set; }

	    protected Event() => Timestamp = DateTime.Now;
    }
}
