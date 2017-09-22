using SWITCH_OVER.Shared.Events;

namespace SWITCH_OVER.Shared.Commands
{
	/// <summary>
	/// Handle of specific command. CommandHandler is responsible to manipulate command request
	/// </summary>
	/// <typeparam name="T">Generic command</typeparam>
	public interface ICommandHandler<in T> : IHandler<T>  where T : Command
	{
	}
}
