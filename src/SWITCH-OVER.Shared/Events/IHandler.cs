﻿namespace SWITCH_OVER.Shared.Events
{
	public interface IHandler<in T> where T : class
	{
		void Handle(T message);
	}
}